using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public class T
        {
            public string A { get; set; }
            public string B { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            StringBuilder str = new StringBuilder();
            var a = new List<T>();

        }

    }
}
