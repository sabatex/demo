using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCoreDemo
{
    public partial class GDIDemo : Form
    {
        public GDIDemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = paintPanel.CreateGraphics();
            var pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            g.DrawLine(pen, new Point(0, 0), new Point(paintPanel.ClientSize.Width, paintPanel.ClientSize.Height));
            

        }

        private void paintPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = paintPanel.CreateGraphics();
            var brush = new LinearGradientBrush(new Point(0, 10),
       new Point(200, 10),
       Color.FromArgb(255, 255, 0, 0),   // Opaque red
       Color.FromArgb(255, 0, 0, 255));

            var pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            g.DrawLine(pen, new Point(0, 0), new Point(0, ClientSize.Height));

        }
    }
}
