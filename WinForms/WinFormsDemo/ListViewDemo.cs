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
    public partial class ListViewDemo : Form
    {
        public ListViewDemo()
        {
            InitializeComponent();

        }

        private void ListViewDemo_Load(object sender, EventArgs e)
        {
            var st =university.Student.NewStudentRow();
            st.Name = "Петренко";
            university.Student.AddStudentRow(st);

            st = university.Student.NewStudentRow();
            st.Name = "Іваненко";
            university.Student.AddStudentRow(st);

        }
    }
}
