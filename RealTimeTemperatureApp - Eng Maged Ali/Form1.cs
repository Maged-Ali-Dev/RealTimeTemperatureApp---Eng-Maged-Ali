using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace RealTimeTemperatureApp___Eng_Maged_Ali
{
    public partial class Form1 : Form
    {
        private const string ApiKey = "Your_Api_Key"; // Replace with your API key
        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric";

        // Static dictionary for countries and their cities
        private List<KeyValuePair<string, List<string>>> countryCityMap = new List<KeyValuePair<string, List<string>>>()
        {
            new KeyValuePair<string, List<string>>("United Kingdom", new List<string> { "London", "Manchester", "Birmingham" }),
            new KeyValuePair<string, List<string>>("Egypt", new List<string> { "Cairo", "Alexandria", "Giza" }),
            new KeyValuePair<string, List<string>>("United States", new List<string> { "New York", "Los Angeles", "Chicago" }),
            new KeyValuePair<string, List<string>>("France", new List<string> { "Paris", "Marseille", "Lyon" }),
            new KeyValuePair<string, List<string>>("Japan", new List<string> { "Tokyo", "Osaka", "Kyoto" })
        };

        public Form1()
        {
            InitializeComponent();
            ApplyDesign();
            PopulateControls();
        }

        private void ApplyDesign()
        {
            // Form styling
            this.Text = "Real-Time Weather Forecast";
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Size = new Size(600, 700);

            // GroupBox for location selection
            GroupBox groupLocation = new GroupBox
            {
                Text = "Select Location",
                ForeColor = Color.FromArgb(0, 122, 204),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(550, 150),
                Location = new Point(20, 20)
            };

            // ComboBox for countries
            comboCountries.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCountries.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            comboCountries.Size = new Size(200, 30);
            comboCountries.Location = new Point(20, 30);

            // ComboBox for cities
            comboCities.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCities.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            comboCities.Size = new Size(200, 30);
            comboCities.Location = new Point(250, 30);

            // Add controls to the GroupBox
            groupLocation.Controls.Add(comboCountries);
            groupLocation.Controls.Add(comboCities);

            // GroupBox for manual city input
            GroupBox groupManualCity = new GroupBox
            {
                Text = "Or Enter City Manually",
                ForeColor = Color.FromArgb(0, 122, 204),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(550, 80),
                Location = new Point(20, 180)
            };

            // TextBox for manual city input
            txtCity.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtCity.Size = new Size(200, 30);
            txtCity.Location = new Point(20, 30);

            // Add controls to the GroupBox
            groupManualCity.Controls.Add(txtCity);

            // Button for fetching weather
            btnGetTemperature.Text = "Get Temperature";
            btnGetTemperature.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnGetTemperature.BackColor = Color.FromArgb(0, 122, 204);
            btnGetTemperature.ForeColor = Color.White;
            btnGetTemperature.FlatStyle = FlatStyle.Flat;
            btnGetTemperature.FlatAppearance.BorderSize = 0;
            btnGetTemperature.Size = new Size(150, 40);
            btnGetTemperature.Location = new Point(200, 280);
            btnGetTemperature.Click += btnGetTemperature_Click_1;

            // Label for displaying weather info
            lblTemperature.AutoSize = false;
            lblTemperature.Size = new Size(550, 250);
            lblTemperature.Location = new Point(20, 340);
            lblTemperature.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblTemperature.BackColor = Color.White;
            lblTemperature.BorderStyle = BorderStyle.FixedSingle;
            lblTemperature.Padding = new Padding(10);

            // Add controls to the form
            this.Controls.Add(groupLocation);
            this.Controls.Add(groupManualCity);
            this.Controls.Add(btnGetTemperature);
            this.Controls.Add(lblTemperature);
        }

        private void PopulateControls()
        {
            // Populate the countries ComboBox
            comboCountries.DataSource = countryCityMap;
            comboCountries.DisplayMember = "Key"; // Display country names

            // Set up event handler for country selection change
            comboCountries.SelectedIndexChanged += ComboCountries_SelectedIndexChanged;

            // Populate cities ComboBox based on the default selected country
            ComboCountries_SelectedIndexChanged(null, null);
        }

        private void ComboCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected country's cities
            var selectedCountry = (KeyValuePair<string, List<string>>)comboCountries.SelectedItem;
            comboCities.DataSource = selectedCountry.Value;
        }

        private async void btnGetTemperature_Click_1(object sender, EventArgs e)
        {
            string city;

            // Check if the user entered a city manually
            if (!string.IsNullOrEmpty(txtCity.Text))
            {
                city = txtCity.Text;
            }
            else
            {
                city = comboCities.SelectedItem?.ToString();
            }

            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Please select a city or enter a city name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = string.Format(ApiUrl, city, ApiKey);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(json);

                        // Extract data from the JSON response
                        string cityName = (string)data["name"];
                        double temperature = (double)data["main"]["temp"];
                        double feelsLike = (double)data["main"]["feels_like"];
                        double tempMin = (double)data["main"]["temp_min"];
                        double tempMax = (double)data["main"]["temp_max"];
                        int pressure = (int)data["main"]["pressure"];
                        int humidity = (int)data["main"]["humidity"];
                        double windSpeed = data["wind"]?["speed"]?.ToObject<double>() ?? 0;
                        int windDeg = data["wind"]?["deg"]?.ToObject<int>() ?? 0;
                        string weatherDescription = (string)data["weather"][0]["description"];

                        // Format the data into a readable string
                        string weatherInfo = $@"
City: {cityName}
Temperature: {temperature}°C
Feels Like: {feelsLike}°C
Min Temperature: {tempMin}°C
Max Temperature: {tempMax}°C
Pressure: {pressure} hPa
Humidity: {humidity}%
Wind Speed: {windSpeed} m/s
Wind Direction: {windDeg}°
Weather: {weatherDescription}
";

                        // Display the weather information in the label
                       // lblTemperature.Visible = true;
                        lblTemperature.Text = weatherInfo;
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API Error: {response.StatusCode}\n{errorResponse}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}