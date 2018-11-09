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
                if (Control.GetType() == new Panel().GetType())
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
            if (Math.Floor(TSpan.TotalDays) != 0) { SSpan += Math.Floor(TSpan.TotalDays) + " Days "; }
            if (TSpan.Hours != 0) { SSpan += TSpan.Hours + " Hours "; }
            if (TSpan.Minutes != 0) { SSpan += TSpan.Minutes + " Mins "; }
            if (SSpan != "") { SSpan += "And "; }
            SSpan += TSpan.Seconds + " Secs ";
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

        int Snows = 0;
        private void Timer_Snow_Tick(object sender, EventArgs e)
        {
            if (Rnd.Next(0, 15) == 1)
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
                    if (Control.Location.Y > this.pictureBox1.Height) {
                        this.pictureBox1.Controls.Remove(Control);
                    }
                    Control.Location = new Point(Rnd.Next(-1, 2) + Control.Location.X, Control.Location.Y + 1);
                    Control.BringToFront();
                }
            }
        }
    }
}
