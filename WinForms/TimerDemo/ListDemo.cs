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
    public partial class ListDemo : Form
    {
        public ListDemo()
        {
            InitializeComponent();
        }

        private void ListDemo_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(10);
            listBox1.Items.Add(2.5);
            listBox1.Items.Add(2.1);
            listBox1.Items.Add("Simple text");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Sorted = checkBox1.Checked;
        }
    }
}
