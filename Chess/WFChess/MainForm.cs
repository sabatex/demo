using Chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsChess
{
    public partial class MainForm : Form
    {
        char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        Desk _desk = new Desk();

        public MainForm()
        {
            InitializeComponent();
            _desk.ClearDesk();
            _desk.RepaintCell += PaintCell;
            _desk.Refresh += RefreshDesk;
        }
        void PaintCell(int i, int j)
        {
            var coords = GetCoordiantes(i, j);
            var control = tableLayoutPanel1.GetControlFromPosition(coords.Y + 1, coords.X + 1) as PictureBox;
            control.BackColor = Color.Green;
            control.Refresh();
        }
        SFigurePosition GetCoordiantes(int i, int j)
        {
            if (_desk.ActivePlayerColor == FigureColor.White)
            {
                return new SFigurePosition(i, j);
            }
            return new SFigurePosition(7 - i, 7 - j);
        }
        void RefreshDesk()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var coords = GetCoordiantes(i, j);
                    var control = tableLayoutPanel1.GetControlFromPosition(j + 1, i + 1) as PictureBox;
                    if (control != null)
                    {
                        if (_desk[coords.X, coords.Y] != null)
                        {
                            try
                            {
                                var image = Image.FromStream(new MemoryStream(_desk[coords.X, coords.Y].GetImage()));
                                control.Image = image;
                                //var c= new Cursor() 
                                control.Refresh();

                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            control.Image = null;
                        }

                        if ((i + j) % 2 == 0)
                        {
                            control.BackColor = Color.White;
                        }
                        else
                        {
                            control.BackColor = Color.Gray;
                        }
                        control.Refresh();
                    }
                }
            }

            for (int i = 1; i < 9; i++)
            {
                var control2 = tableLayoutPanel1.GetControlFromPosition(i, 0) as Label;
                var control1 = tableLayoutPanel1.GetControlFromPosition(0, i) as Label;

                if (_desk.ActivePlayerColor == FigureColor.Black)
                {
                    control1.Text = i.ToString();
                    control2.Text = "" + chars[8 - i];
                }
                else
                {
                    control1.Text = (9 - i).ToString();
                    control2.Text = "" + chars[i - 1];
                }
            }

            playerName.Text = _desk.ActivePlayerColor == FigureColor.White ? "White Player" : "Black Player";    
        
            // Clear player desk
            for (int i = 0;i<5;i++)
            {
                var control =playerStatusPanel.GetControlFromPosition(0, i) as PictureBox;
                Trace.Assert(control != null);
                control.Image = null;
            }

            var figures = _desk.ActivePlayer._deadFigures.OrderByDescending(o=>o.FigureOrder).GroupBy(k => k.FigureOrder);
            int idx = 0;
            foreach (var figure in figures)
            {
                var control = playerStatusPanel.GetControlFromPosition(0, idx) as PictureBox;
                control.Image = Image.FromStream(new MemoryStream(figure.FirstOrDefault().GetImage()));
                var label = playerStatusPanel.GetControlFromPosition(1, idx) as Label;
                label.Text = figure.Count().ToString();
                idx++;
            }


        }



        void SetRowLabel(int i)
        {
            var lb = new Label
            {
                Text = (9 - i).ToString(),
                AutoSize = false,
                Margin = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(0, i));
        }
        void SetColumnLabel(int i)
        {
            var lb = new Label
            {
                Text = "" + chars[i - 1],
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(i, 0));
        }
        void AddCell(int i, int j)
        {
            var f = new PictureBox
            {
                BackColor = (i + j) % 2 == 0 ? Color.White : Color.Gray,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = new Padding(0)
            };
            f.Click += Image_Click;
            f.DragEnter += cellDragEnter;
            
            

            tableLayoutPanel1.Controls.Add(f);
            tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
        }

        private void cellDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void InitialPlayerDesk()
        {
            for (int i = 0; i < 5; i++)
            {
                var f = new PictureBox
                {
                    BackColor =  Color.White,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                playerStatusPanel.Controls.Add(f);
                playerStatusPanel.SetCellPosition(f, new TableLayoutPanelCellPosition(0, i));
                var label = new Label
                {
                    Text = "",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                playerStatusPanel.Controls.Add(label);
                playerStatusPanel.SetCellPosition(label, new TableLayoutPanelCellPosition(1, i));
            }
        }

        void AddDeadFigureInfo(TableLayoutPanel obj, FigureColor color)
        {
            for (int i = 0; i < 5; i++)
            {
                var pb = new PictureBox
                {
                    //BackColor = Color.Chartreuse,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                obj.Controls.Add(pb);
                obj.SetCellPosition(pb, new TableLayoutPanelCellPosition(0, i));

                var lb = new Label
                {
                    Text = "x" + 0.ToString(),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                obj.Controls.Add(lb);
                obj.SetCellPosition(lb, new TableLayoutPanelCellPosition(1, i));
            }

            if (color == FigureColor.White)
            {
                (obj.GetControlFromPosition(0, 0) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.QueenWhite));
                (obj.GetControlFromPosition(0, 1) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.BishopWhite));
                (obj.GetControlFromPosition(0, 2) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.HourseWhite));
                (obj.GetControlFromPosition(0, 3) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.RockWhite));
                (obj.GetControlFromPosition(0, 4) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.PawnWhite));
            }
            else
            {
                (obj.GetControlFromPosition(0, 0) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.QueenBlack));
                (obj.GetControlFromPosition(0, 1) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.BishopBlack));
                (obj.GetControlFromPosition(0, 2) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.HourseBlack));
                (obj.GetControlFromPosition(0, 3) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.RockBlack));
                (obj.GetControlFromPosition(0, 4) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.PawnBlack));
            }
            //tableLayoutPanel1.Controls.Add(f);
            //tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
            //f.Dock = DockStyle.Fill;
            //f.SizeMode = PictureBoxSizeMode.StretchImage;

         }

        private void Image_Click(object sender, EventArgs e)
        {
            RefreshDesk();
            var pos = tableLayoutPanel1.GetCellPosition(sender as PictureBox);
            var a = GetCoordiantes(pos.Row - 1, pos.Column - 1);
            DoDragDrop($"{a}",DragDropEffects.Move);
            (sender as PictureBox).BackColor = Color.Bisque;
            _desk.ChoseAction(a.X, a.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(80, 80);
            //this.Height = 650;
            //this.Width = 660;
            for (int i = 1; i < 9; i++)
            {
                SetRowLabel(i);
                SetColumnLabel(i);
                for (int j = 1; j < 9; j++)
                {
                    AddCell(i, j);
                }
            }
            tableLayoutPanel1.AllowDrop = true;
            InitialPlayerDesk();
            //AddDeadFigureInfo(tableLayoutPanel2, FigureColor.White);
            //AddDeadFigureInfo(playerStatusPanel, FigureColor.Black);
            RefreshDesk();
            Refresh();
        }
 
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            _desk.ClearDesk();
            RefreshDesk();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
