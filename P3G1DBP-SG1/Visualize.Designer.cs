﻿namespace Project3Groep1
{
    partial class Visualize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.MaandButton = new System.Windows.Forms.Button();
            this.barChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.WeatherButton = new System.Windows.Forms.Button();
            this.RainButton = new System.Windows.Forms.Button();
            this.FrostButton = new System.Windows.Forms.Button();
            this.WeekButton = new System.Windows.Forms.Button();
            this.SubGroupButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sunButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MaandButton
            // 
            this.MaandButton.Location = new System.Drawing.Point(148, 349);
            this.MaandButton.Name = "MaandButton";
            this.MaandButton.Size = new System.Drawing.Size(75, 23);
            this.MaandButton.TabIndex = 0;
            this.MaandButton.Text = "Maand";
            this.MaandButton.UseVisualStyleBackColor = true;
            this.MaandButton.Click += new System.EventHandler(this.maandButton_Click);
            // 
            // barChart
            // 
            chartArea2.AxisX.Maximum = 365D;
            chartArea2.AxisX.Minimum = 1D;
            chartArea2.AxisX.ScaleBreakStyle.Spacing = 5D;
            chartArea2.Name = "ChartArea1";
            this.barChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.barChart.Legends.Add(legend2);
            this.barChart.Location = new System.Drawing.Point(148, 21);
            this.barChart.Name = "barChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Fietsendiefstallen";
            this.barChart.Series.Add(series2);
            this.barChart.Size = new System.Drawing.Size(614, 322);
            this.barChart.TabIndex = 1;
            this.barChart.Text = "ShowData";
            title2.Name = "Fietsendiefstallen";
            this.barChart.Titles.Add(title2);
            // 
            // WeatherButton
            // 
            this.WeatherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.WeatherButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WeatherButton.Location = new System.Drawing.Point(12, 231);
            this.WeatherButton.Name = "WeatherButton";
            this.WeatherButton.Size = new System.Drawing.Size(130, 77);
            this.WeatherButton.TabIndex = 2;
            this.WeatherButton.Text = "☁";
            this.WeatherButton.UseVisualStyleBackColor = true;
            this.WeatherButton.Click += new System.EventHandler(this.WeatherButton_Click);
            // 
            // RainButton
            // 
            this.RainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.RainButton.Location = new System.Drawing.Point(80, 314);
            this.RainButton.Name = "RainButton";
            this.RainButton.Size = new System.Drawing.Size(62, 58);
            this.RainButton.TabIndex = 3;
            this.RainButton.Text = "☔";
            this.RainButton.UseVisualStyleBackColor = true;
            this.RainButton.Click += new System.EventHandler(this.RainButton_Click);
            // 
            // FrostButton
            // 
            this.FrostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.FrostButton.Location = new System.Drawing.Point(12, 314);
            this.FrostButton.Name = "FrostButton";
            this.FrostButton.Size = new System.Drawing.Size(62, 58);
            this.FrostButton.TabIndex = 4;
            this.FrostButton.Text = "❄";
            this.FrostButton.UseVisualStyleBackColor = true;
            this.FrostButton.Click += new System.EventHandler(this.FrostButton_Click);
            // 
            // WeekButton
            // 
            this.WeekButton.Location = new System.Drawing.Point(229, 349);
            this.WeekButton.Name = "WeekButton";
            this.WeekButton.Size = new System.Drawing.Size(75, 23);
            this.WeekButton.TabIndex = 5;
            this.WeekButton.Text = "Week";
            this.WeekButton.UseVisualStyleBackColor = true;
            // 
            // SubGroupButton
            // 
            this.SubGroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.SubGroupButton.ForeColor = System.Drawing.Color.Black;
            this.SubGroupButton.Location = new System.Drawing.Point(712, 364);
            this.SubGroupButton.Name = "SubGroupButton";
            this.SubGroupButton.Size = new System.Drawing.Size(76, 74);
            this.SubGroupButton.TabIndex = 8;
            this.SubGroupButton.Text = "🚲";
            this.SubGroupButton.UseVisualStyleBackColor = true;
            this.SubGroupButton.Click += new System.EventHandler(this.SubGroupButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.button1.Location = new System.Drawing.Point(369, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 74);
            this.button1.TabIndex = 9;
            this.button1.Text = "update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sunButton
            // 
            this.sunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.sunButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sunButton.Location = new System.Drawing.Point(12, 148);
            this.sunButton.Name = "sunButton";
            this.sunButton.Size = new System.Drawing.Size(130, 77);
            this.sunButton.TabIndex = 10;
            this.sunButton.Text = "☀";
            this.sunButton.UseVisualStyleBackColor = true;
            this.sunButton.Click += new System.EventHandler(this.sunButton_Click);
            // 
            // Visualize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sunButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SubGroupButton);
            this.Controls.Add(this.WeekButton);
            this.Controls.Add(this.FrostButton);
            this.Controls.Add(this.RainButton);
            this.Controls.Add(this.WeatherButton);
            this.Controls.Add(this.barChart);
            this.Controls.Add(this.MaandButton);
            this.Name = "Visualize";
            this.Text = "Fietsenfiefstallen & het Weer";
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MaandButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChart;
        private System.Windows.Forms.Button WeatherButton;
        private System.Windows.Forms.Button RainButton;
        private System.Windows.Forms.Button FrostButton;
        private System.Windows.Forms.Button WeekButton;
        private System.Windows.Forms.Button SubGroupButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button sunButton;
    }
}

