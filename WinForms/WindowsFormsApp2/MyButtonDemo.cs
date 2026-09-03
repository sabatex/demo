using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MyButtonDemo : Form
    {
        public MyButtonDemo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var pen = new Pen(Color.Red, 10);
            var g = e.Graphics;
            e.Graphics.DrawLine(pen, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
        }
    }
}
