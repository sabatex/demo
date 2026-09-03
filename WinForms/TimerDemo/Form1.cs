using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            var x = button1.Location.X;
            if (x < this.ClientSize.Width - button1.Width)
            {
                button1.Location = new Point(button1.Location.X + 10, button1.Location.Y);
            }
            else
                timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Threading.Timer timer = new System.Threading.Timer((state)=> { },null,1000,1000);

            timer1.Start();
            var openForms =   Application.OpenForms;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new ListDemo()).Show();
        }
    }
}
