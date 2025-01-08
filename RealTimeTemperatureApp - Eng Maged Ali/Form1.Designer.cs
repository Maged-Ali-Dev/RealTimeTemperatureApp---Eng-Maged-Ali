namespace RealTimeTemperatureApp___Eng_Maged_Ali
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCity = new TextBox();
            btnGetTemperature = new Button();
            lblTemperature = new Label();
            comboCountries = new ComboBox();
            comboCities = new ComboBox();
            SuspendLayout();
            // 
            // txtCity
            // 
            txtCity.Location = new Point(319, 213);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 0;
            // 
            // btnGetTemperature
            // 
            btnGetTemperature.Location = new Point(291, 135);
            btnGetTemperature.Name = "btnGetTemperature";
            btnGetTemperature.Size = new Size(141, 54);
            btnGetTemperature.TabIndex = 1;
            btnGetTemperature.Text = "Get Temperature";
            btnGetTemperature.UseVisualStyleBackColor = true;
            btnGetTemperature.Click += btnGetTemperature_Click_1;
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Location = new Point(348, 296);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(10, 15);
            lblTemperature.TabIndex = 2;
            lblTemperature.Text = " ";
            // 
            // comboCountries
            // 
            comboCountries.FormattingEnabled = true;
            comboCountries.Location = new Point(298, 26);
            comboCountries.Name = "comboCountries";
            comboCountries.Size = new Size(121, 23);
            comboCountries.TabIndex = 3;
            // 
            // comboCities
            // 
            comboCities.FormattingEnabled = true;
            comboCities.Location = new Point(302, 86);
            comboCities.Name = "comboCities";
            comboCities.Size = new Size(121, 23);
            comboCities.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboCities);
            Controls.Add(comboCountries);
            Controls.Add(lblTemperature);
            Controls.Add(btnGetTemperature);
            Controls.Add(txtCity);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Real-Time Weather Forecast";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCity;
        private Button btnGetTemperature;
        private Label lblTemperature;
        private ComboBox comboCountries;
        private ComboBox comboCities;
    }
}
