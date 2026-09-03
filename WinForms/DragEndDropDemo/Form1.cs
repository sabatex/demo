using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragEndDropDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string getOwner(Control control)
        {
            var sb = new StringBuilder(control.Name);
            while (control.Parent != null)
            {
                control = control.Parent;
                sb.Insert(0, control.Name + ".");
            }
            return sb.ToString();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            
            button1.DoDragDrop(button1.Name, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void splitContainer1_Panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e)
        {
            var text = e.Data.GetData(DataFormats.Text).ToString();

            foreach (var c in splitContainer1.Panel1.Controls.Find(text, false))
            {
                splitContainer1.Panel1.Controls.Remove(c);
                splitContainer1.Panel2.Controls.Add(c);
                c.Location = splitContainer1.Panel2.PointToClient(new Point(e.X, e.Y));
            }
        }

        private void splitContainer1_Panel1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;

        }

        private void splitContainer1_Panel1_DragDrop(object sender, DragEventArgs e)
        {
           
            var text = e.Data.GetData(DataFormats.Text).ToString();
            foreach (var c in splitContainer1.Panel2.Controls.Find(text, false))
            {
                splitContainer1.Panel2.Controls.Remove(c);
                splitContainer1.Panel1.Controls.Add(c);
                c.Location = splitContainer1.Panel1.PointToClient(new Point(e.X, e.Y));
            }

        }
    }
}
