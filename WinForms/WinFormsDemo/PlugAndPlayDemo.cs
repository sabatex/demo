using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WinFormsDemo
{
    public partial class PlugAndPlayDemo : Form
    {
        public PlugAndPlayDemo()
        {
            InitializeComponent();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            DoDragDrop(pictureBox, DragDropEffects.Move);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
  
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //PictureBox pictureBox = sender as PictureBox;
            //DoDragDrop(pictureBox.Name, DragDropEffects.Move);

        }

        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
         }

        private void flowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {
           var f = e.Data.GetData(DataFormats.Text) as string;
            //flowLayoutPanel1.Controls.Find(f,true);
            var c = flowLayoutPanel1.Controls.Find(f, true);
            PictureBox pictureBox = c[0] as PictureBox;
            //e.Data.GetData(DataFormats.Serializable);
            //    PictureBox pictureBox = sender as PictureBox;
            flowLayoutPanel2.Controls.Add(pictureBox);
            flowLayoutPanel1.Controls.Remove(pictureBox);
            //e.Effect = DragDropEffects.Move;
            //PictureBox pictureBox = e.Data as PictureBox;
            //flowLayoutPanel2.Controls.Add(pictureBox);
            //    flowLayoutPanel1.Controls.Remove(pictureBox);

        }

        private void pictureBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
 
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            var f = e.Data.GetData(DataFormats.Text) as string;
            //flowLayoutPanel1.Controls.Find(f,true);
            var c = flowLayoutPanel2.Controls.Find(f, true);
            PictureBox pictureBox = c[0] as PictureBox;
            //e.Data.GetData(DataFormats.Serializable);
            //    PictureBox pictureBox = sender as PictureBox;
            flowLayoutPanel1.Controls.Add(pictureBox);
            flowLayoutPanel2.Controls.Remove(pictureBox);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //PictureBox pictureBox = sender as PictureBox;
            Control pictureBox = sender as Control;
            DoDragDrop(pictureBox.Name, DragDropEffects.Move);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }

        
    }
}
