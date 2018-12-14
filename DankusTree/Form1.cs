using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DankusTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            this.TopMost = true;
            foreach (Control Control in this.Controls)
            {
                if (Control.GetType() == new Panel().GetType() && Control.Name!= "panel_snowpile")
                {
                    Control.Name = "Light" + i;
                    i++;
                }
            }
        }

        private void Timer_Time_Tick(object sender, EventArgs e)
        {
            TimeSpan TSpan = (TimeSpan)(new DateTime(DateTime.Now.Year,12,25,0,0,0) - DateTime.Now);
            string SSpan = "";
            if (Math.Floor(TSpan.TotalDays) != 0) { if (Math.Floor(TSpan.TotalDays) != 1) { SSpan += Math.Floor(TSpan.TotalDays) + " Days "; } else { SSpan += Math.Floor(TSpan.TotalDays) + " Day "; } }
            if (TSpan.Hours != 0) { if (TSpan.Hours != 1) { SSpan += TSpan.Hours + " Hours "; } else { SSpan += TSpan.Hours + " Hour "; } }
            if (TSpan.Minutes != 0) { if (TSpan.Minutes != 1) { SSpan += TSpan.Minutes + " Mins "; } else { SSpan += TSpan.Minutes + " Min "; } }
            if (TSpan.Seconds != 0)
            {
                if (SSpan != "") { SSpan += "And "; }
                if (TSpan.Seconds != 1) { SSpan += TSpan.Seconds + " Secs "; } else { SSpan += TSpan.Seconds + " Sec "; }
            }
            Label_Time.Text = SSpan;
        }

        Random Rnd = new Random();
        Color[] Colors = new Color[] { Color.Red,Color.Green,Color.Cyan,Color.Gold };
        private void Timer_Lights_Tick(object sender, EventArgs e)
        {
            foreach (Control Control in this.Controls)
            {
                if (Control.Name.StartsWith("Light"))
                {
                    Control.BackColor = Colors[Rnd.Next(0, Colors.Length)];
                }
            }
        }

        UInt64 Snows = 0;
        int SnowMod = 0;
        bool SnowDraining = false;

        private void Timer_Snow_Tick(object sender, EventArgs e)
        {
            if (Rnd.Next(0, 15) == 1 && !SnowDraining)
            {
                Panel NewSnow = new Panel();
                NewSnow.BackColor = Color.White;
                NewSnow.Name = "Snow"+Snows;
                NewSnow.Height = 15;
                NewSnow.Width = 15;
                NewSnow.Location = new Point(Rnd.Next(0, this.pictureBox1.Width),-15);
                NewSnow.BringToFront();
                this.pictureBox1.Controls.Add(NewSnow);
                Snows++;
            }
            foreach (Control Control in this.pictureBox1.Controls)
            {
                if (Control.Name.StartsWith("Snow"))
                {
                    if (Control.Location.Y > this.panel_snowpile.Location.Y) {
                        if (SnowMod % 4 == 0)
                        {
                            this.panel_snowpile.Height += 1;
                            this.panel_snowpile.Location = new Point(0, this.panel_snowpile.Location.Y - 1);
                            if (this.panel_snowpile.Location.Y <= 0)
                            {
                                SnowDraining = true;
                                this.Timer_Snow.Interval = 200;
                                //this.panel_snowpile.Height = 0;
                                //this.panel_snowpile.Location = new Point(0, this.pictureBox1.Height);
                            }
                            SnowMod = 0;
                        }
                        this.pictureBox1.Controls.Remove(Control);
                        SnowMod++;
                    }
                    Control.Location = new Point(Rnd.Next(-1, 2) + Control.Location.X, Control.Location.Y + 1);
                    Control.BringToFront();
                }
            }
            if (SnowDraining)
            {
                this.panel_snowpile.Height -= 1;
                this.panel_snowpile.Location = new Point(0, this.pictureBox1.Height - this.panel_snowpile.Height);
                if (this.panel_snowpile.Height == 0) { SnowDraining = false; this.Timer_Snow.Interval = 50; }
            }
        }
    }
}
