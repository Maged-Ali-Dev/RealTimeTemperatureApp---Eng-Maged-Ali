 Real-Time Temperature App - Detailed Explanation

This project is a Windows Forms Application built using C# and the .NET Framework. It provides a user-friendly interface to fetch and display real-time weather information for a selected city using the OpenWeatherMap API. Below is a detailed breakdown of the project:

![1](https://github.com/user-attachments/assets/07499416-e7bd-4e67-9f76-6963eef22176)

![2](https://github.com/user-attachments/assets/0639b660-58c7-4deb-bfc9-d1b2971479b3)


 1. Project Overview
The application allows users to:
- Select a country and city from predefined lists.
- Manually enter a city name.
- Fetch and display real-time weather data (temperature, humidity, wind speed, etc.) for the selected city.

The app uses the OpenWeatherMap API to retrieve weather data and displays it in a clean and organized manner.



 2. Key Components
The project consists of the following key components:

 2.1. User Interface (UI)
The UI is built using Windows Forms and includes the following controls:
- ComboBoxes: For selecting a country and city.
- TextBox: For manually entering a city name.
- Button: To trigger the weather data fetch.
- Label: To display the fetched weather information.
- GroupBoxes: To group related controls (e.g., location selection and manual city input).

 2.2. Data Source
- Country-City Mapping: A static dictionary (`countryCityMap`) is used to store a list of countries and their corresponding cities. This data is used to populate the ComboBoxes.
- OpenWeatherMap API: The app fetches real-time weather data using the OpenWeatherMap API.

 2.3. API Integration
- The app uses the HttpClient class to send HTTP requests to the OpenWeatherMap API.
- The API response is in JSON format, which is parsed using the Newtonsoft.Json.Linq library.

 2.4. Event Handling
- ComboBox Selection Change: When the user selects a country, the corresponding cities are populated in the cities ComboBox.
- Button Click: When the user clicks the "Get Temperature" button, the app fetches and displays weather data for the selected or manually entered city.



 3. Code Walkthrough

 3.1. Class and Variables

public partial class Form1 : Form
{
    private const string ApiKey = "Your_Api_Key"; // Replace with your API key
    private const string ApiUrl = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric";

    private List<KeyValuePair<string, List<string>>> countryCityMap = new List<KeyValuePair<string, List<string>>>()
    {
        new KeyValuePair<string, List<string>>("United Kingdom", new List<string> { "London", "Manchester", "Birmingham" }),
        new KeyValuePair<string, List<string>>("Egypt", new List<string> { "Cairo", "Alexandria", "Giza" }),
        new KeyValuePair<string, List<string>>("United States", new List<string> { "New York", "Los Angeles", "Chicago" }),
        new KeyValuePair<string, List<string>>("France", new List<string> { "Paris", "Marseille", "Lyon" }),
        new KeyValuePair<string, List<string>>("Japan", new List<string> { "Tokyo", "Osaka", "Kyoto" })
    };
}

- ApiKey: Stores the API key for OpenWeatherMap.
- ApiUrl: The base URL for the API request. It includes placeholders for the city name (`{0}`) and API key (`{1}`).
- countryCityMap: A list of key-value pairs where each key is a country and the value is a list of cities in that country.



 3.2. Constructor and Initialization

public Form1()
{
    InitializeComponent();
    ApplyDesign();
    PopulateControls();
}

- InitializeComponent(): Initializes the form and its controls.
- ApplyDesign(): Applies styling and layout to the form and controls.
- PopulateControls(): Populates the ComboBoxes with data from `countryCityMap`.



 3.3. UI Design and Styling

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

- Form Styling: Sets the form's title, background color, font, and size.
- GroupBoxes: Used to group related controls (e.g., location selection and manual city input).
- ComboBoxes: For selecting countries and cities.
- TextBox: For manually entering a city name.
- Button: Triggers the weather data fetch.
- Label: Displays the fetched weather information.



 3.4. Populating Controls

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

- Populates the `comboCountries` ComboBox with country names.
- Sets up an event handler for the `SelectedIndexChanged` event of `comboCountries`.



 3.5. Handling Country Selection Change

private void ComboCountries_SelectedIndexChanged(object sender, EventArgs e)
{
    // Get the selected country's cities
    var selectedCountry = (KeyValuePair<string, List<string>>)comboCountries.SelectedItem;
    comboCities.DataSource = selectedCountry.Value;
}

- Updates the `comboCities` ComboBox with the cities of the selected country.



 3.6. Fetching Weather Data

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

- Fetches weather data for the selected or manually entered city.
- Parses the JSON response and extracts relevant weather information.
- Displays the weather information in the `lblTemperature` label.



 4. How It Works
1. The user selects a country and city or enters a city name manually.
2. The user clicks the "Get Temperature" button.
3. The app sends an HTTP request to the OpenWeatherMap API.
4. The API responds with weather data in JSON format.
5. The app parses the JSON response and displays the weather information.



 5. Dependencies
- Newtonsoft.Json: For parsing JSON data.
- OpenWeatherMap API: For fetching real-time weather data.



 6. Improvements
- Add error handling for invalid city names.
- Implement caching to reduce API calls.
- Add support for more countries and cities.
- Improve UI with icons and animations.



This project is a great example of how to build a real-time data-driven application using C# and Windows Forms. It demonstrates key concepts such as API integration, JSON parsing, and event-driven programming.
