using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class MyButton:Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            //var pen = new Pen(Color.Red, 10);
            var g = pevent.Graphics;
            //g.DrawLine(pen, 0, 0, g.VisibleClipBounds.Width, g.VisibleClipBounds.Height);
            //g.DrawLine(pen, 0, g.VisibleClipBounds.Height, g.VisibleClipBounds.Width, 0);
            //var rect = new Rectangle(0, 0, ClientRectangle ClientSize.Width,ClientSize.Height);
            LinearGradientBrush lBrush = new LinearGradientBrush(ClientRectangle, Color.Red, Color.Yellow, LinearGradientMode.BackwardDiagonal);
            var pen = new Pen(lBrush, 2);
            // g.DrawRectangle(new Pen(Color.Black,2), ClientRectangle);
            // g.DrawRectangle(pen, 5, 5, ClientRectangle.Width - 10, ClientRectangle.Height - 10);
            //g.FillEllipse(lBrush, rect);
            //g.DrawString(Text, Font, lBrush, new Point(0, ClientRectangle.Height / 2));
            g.DrawLine(pen, 5, 0, ClientRectangle.Width - 5, 0);
            g.DrawLine(pen, 5, ClientRectangle.Height, ClientRectangle.Width - 5, ClientRectangle.Height);
            g.DrawLine(pen, 0, 5, 0, ClientRectangle.Height - 5);
            g.DrawLine(pen, ClientRectangle.Width,5,ClientRectangle.Width, ClientRectangle.Height-5);
            g.DrawArc(pen, 0,0,10,10, 180, 90);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            
        }
    }
}
