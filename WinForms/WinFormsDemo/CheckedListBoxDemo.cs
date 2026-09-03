using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public partial class CheckedListBoxDemo : Form
    {
        public CheckedListBoxDemo()
        {
            InitializeComponent();
        }

        private void CheckedListBoxDemo_Load(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var a in checkedListBox1.CheckedItems)
            {

                var b = a.ToString();
            }
        }
    }
}
