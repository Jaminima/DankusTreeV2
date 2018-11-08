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
                if (Control.GetType()==new Panel().GetType())
                {
                    Control.BackColor = Colors[Rnd.Next(0, Colors.Length)];
                }
            }
        }
    }
}
