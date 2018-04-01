﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Project3Groep1
{
    public partial class Visualize : Form
    {
        DBConnect myConnection = new DBConnect();
        /// <summary>
        /// The master config class used to store all our variables
        /// </summary>
        ChartConfig MasterChartConfig = new ChartConfig();
        public Visualize()
        {
            InitializeComponent();
            myConnection.updateDatabase();
            GroepeerBox.SelectedItem = 5;
            GroepeerBox.Text = "5";
        }


        private void maandButton_Click(object sender, EventArgs e)
        {
            updateChart();
        }

        public bool updateChart()
        {
            FlipEnabledAllButtons();
            barChart.Series[0].Points.Clear(); //clear the chart for starters
<<<<<<< HEAD
            /*
            * TODO: SCALABILITY
            * INSTEAD OF DEFININING THE QUERY IN HERE, WE SHOULD MAKE EVERY BIT VARIABLE
            * AND COMBINE A BUNCH OF PASSED VARIABLES FROM THE BUTTONS
            * AND BUILD OUR QUERY OUT OF THAT!
            */
            //set up variables for use in our looped checks...
            int PrecipMode = MasterChartConfig.PrecipitationMode;
            bool subGroupBool = MasterChartConfig.SubGroupData;

            string tableUsed;
            string precip;
            string timeFrame;

            if (subGroupBool)
            {
                tableUsed = "fietsendiefstal";
            }
            else
            {
                tableUsed = "straatroof";
            }

            if (MasterChartConfig.PrecipitationMode == 0)
            {
                precip = "";
            }
            else
            {
                precip = "and (Regen = 1 or Sneeuw = 1) ";
            }

            if (MasterChartConfig.TimeMode == 0)
            {
                timeFrame = "";
            }
            else
            {
                timeFrame = "and weer.Maand = " + Convert.ToString(MasterChartConfig.TimeMode);
            }
            
            //Loop through all the entries

            /* 
             * query that uses the table assigned above to select where the data will come from
             * bit hard to read due to all the +es but it beats having one massive line
             */
            string myQuery =
                    "Select count(ID), TemperatuurGem " +
                    "From "+ tableUsed + ", weer " +
                    "Where " + tableUsed + ".Dag = weer.Dag and " +
                    "" + tableUsed + ".Maand = weer.Maand and " +
                    "" + tableUsed + ".Jaar = weer.Jaar and TemperatuurGem is not null " 
                    + timeFrame + precip +
                    "Group by TemperatuurGem;";
            Console.WriteLine(myQuery);
            List<DBConnect.CountTemp> myCountResult = myConnection.DBselect(myQuery);
            Console.WriteLine(myCountResult);

            List<Tuple<string, double>> items = new List<Tuple<string, double>>()
            {
                new Tuple<string,double>("q", .5),
                new Tuple<string,double>("d", 1.5),
                new Tuple<string,double>("j", .7),
                new Tuple<string,double>("h", .8),
                new Tuple<string,double>("q", .5)


            };

            
            var sumvalue = items.Sum(c => c.Item2); // Calculates sum of all values
            
            var betweensum = items.SkipWhile(x => x.Item1 == "q") // Skip until matching item1            
                .TakeWhile(x => x.Item1 != "q") // take until matching item1
                .Sum(x => x.Item2); // Sum

            int gid = 0;
            items.Select(c => new { Tuple = c, gid = c.Item1 == "q" ? ++gid : gid })
                .GroupBy(x => x.gid)
                .Where(x => x.Key % 2 == 1)
                .SelectMany(x => x.Skip(1))
                .Sum(x => x.Tuple.Item2);

            foreach (var item in items)
            {
                Console.WriteLine();
            }

            foreach (var mylistEntry in myCountResult)
=======
            //moved query to master chart config class
            string myQuery = MasterChartConfig.BuildQuery(); // get proper query from master config
            Console.WriteLine(myQuery); //debug
            List<DBConnect.CountTemp> myCountResult = myConnection.DBselect(myQuery); //exec query
            Console.WriteLine(myCountResult); //debug, query results
            foreach (var mylistEntry in myCountResult) //loop through query results
>>>>>>> origin/DudeBranch
            {
                int TempGemround = mylistEntry.TempGem;
                int RoundNumber = Convert.ToInt32(GroepeerBox.SelectedItem) * 10;
                TempGemround = Convert.ToInt32(Math.Round(TempGemround / (RoundNumber * 1.0)) * RoundNumber);
                barChart.Series[0].Points.AddXY(TempGemround / 10, mylistEntry.Count);
            }
            Console.WriteLine("SETTINGS USED:" + "PRECIP MODE " + MasterChartConfig.PrecipitationMode + " " + "TABLE " + MasterChartConfig.SubGroupData);
            FlipEnabledAllButtons();
            return true;
        }

        /// <summary>
        /// Integer button that increments related variable and re-colors the button
        /// </summary>
        /// <param name="passedVariable">Variable from the master config relating to the button pressed</param>
        /// <param name="passedButton">the object of the button being pressed</param>
        /// <returns>integer, changed passedVariable</returns>
        public int ChangeButtonInteger(int passedVariable, Button passedButton)
        {
            /*
             * TODO:
             * COMPLETE FUNCTIONALITY
             * 
             * THIS FUNCTION SHOULD ENABLE A FILTER IN THREE MODES
             * 
             * MODE 1: ALWAYS ON
             * THIS IS THE DEFAULT MODE
             * THIS SHOWS THE THEFTS DURING BAD WEATHER IN THE NORMAL COLUMN
             * THE BUTTON SHOULD LOOK NORMAL
             * 
             * MODE 2: HIGHLIGHT
             * THIS SHOWS THE THEFTS DURING BAD WEATHER WITH A RED HIGHLIGHT ON TOP OF A NORMAL COLUMN
             * THE BUTTON SHOULD LOOK HIGHLIGHTED, POSSIBLY BLUE?
             * 
             * MODE 3: FILTER
             * THIS FILTERS THE THEFTS DURING BAD WEATHER FROM THE COLUMN, REDUCING IT
             * THE BUTTON SHOULD LOOK DISABLED, POSSIBLY CROSSED OUT OR RED
            */

            if (passedVariable < 2)
            {
                passedVariable++;
                if (passedVariable == 1)
                {
                    passedButton.ForeColor = System.Drawing.Color.DodgerBlue;
                }
                else
                {
                    passedButton.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else
            {
                passedVariable = 0;
                passedButton.ForeColor = System.Drawing.Color.Black;
            }

            //We pressed a button, so update the chart!
            return passedVariable;
        }

        /// <summary>
        /// Returns a list of controls (buttons)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="list"></param>
        public void GetAllControl(Control c, List<Control> list)
        {
            foreach (Control control in c.Controls)
            {
                list.Add(control);

                if (control.GetType() == typeof(Panel))
                    GetAllControl(control, list);
            }
        }

        /// <summary>
        /// Flips 'enabled' property of all buttons, causing UI to grey out or re-color
        /// </summary>
        public void FlipEnabledAllButtons()
        {
            List<Control> AllButtons = new List<Control>();

            GetAllControl(this, AllButtons);

            foreach (Control control in AllButtons)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Enabled = !control.Enabled;
                }
            }
        }

        private void WeatherButton_Click(object sender, EventArgs e)
        {
            //This calls the generic button function, less copypasta.
            MasterChartConfig.PrecipitationMode = ChangeButtonInteger(MasterChartConfig.PrecipitationMode, WeatherButton);
            updateChart();
        }

        private void RainButton_Click(object sender, EventArgs e)
        {
            MasterChartConfig.RainMode = ChangeButtonInteger(MasterChartConfig.RainMode, RainButton);
            updateChart();
        }

        private void FrostButton_Click(object sender, EventArgs e)
        {
            MasterChartConfig.SnowMode = ChangeButtonInteger(MasterChartConfig.SnowMode, FrostButton);
            updateChart();
        }

        private void sunButton_Click(object sender, EventArgs e)
        {
            MasterChartConfig.SunMode = ChangeButtonInteger(MasterChartConfig.SunMode, sunButton);
            updateChart();
        }

        private void SubGroupButton_Click(object sender, EventArgs e) //This one's seperate because it's not an int, but a bool!
        {
            MasterChartConfig.SubGroupData = !MasterChartConfig.SubGroupData; //Flip the bool.
            if (MasterChartConfig.SubGroupData) //true, straatroof
            {
                SubGroupButton.Text = "💰";
            }
            else //false, fietsendiefstal
            {
                SubGroupButton.Text = "🚲";
            }

            updateChart(); //We pressed a button, so update the chart!
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("hello");
            updateChart();
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
