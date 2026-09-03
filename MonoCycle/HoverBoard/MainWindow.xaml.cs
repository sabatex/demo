using MonoCicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MonoCicle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IDisposable
    {
        public MainView model { get; set; }
        private DispatcherTimer _displayRenderTimer;

        private Board board;

        private DateTime engenieOverheat;
        private DateTime time1;
        private double totalDistance = 0;
        double speed = 0;
        int rpm;


        private const double _duration = 0.01;
        private const double _radius = 0.1;
        private const double MAXPOWER = 100;
        private const double POWERDISCRETE = 10;
        private const int FPS = 50;
        private Direction _direction;
        private double _power;
        int counter = 0;

        long lastTicks = 0;

     

        public MainWindow()
        {
            InitializeComponent();
            var initialTime = DateTime.UtcNow;
            time1 = initialTime; 
            engenieOverheat = initialTime;
            model = new MainView(initialTime) { UserWeight = 100};
            _power = 10;
            _direction = Direction.None;
            DataContext = model;

            board = Board.GetBoard(WheelSize.d10);
            board.EngenieOverheat += BoardEngenieOverheat;

            _displayRenderTimer = new DispatcherTimer();
            _displayRenderTimer.Tick += OnHandleRender;
            var interval = TimeSpan.FromMilliseconds(20);
            _displayRenderTimer.Interval = interval;
           
            _displayRenderTimer.Start();
        }

        private void BoardEngenieOverheat()
        {
            engenieOverheat = DateTime.UtcNow;
        }

        private void OnHandleRender(object sender, EventArgs e)
        {
            var datenow = DateTime.UtcNow;
            if ((datenow - engenieOverheat).Seconds < 2)
            {
                model.EngenieOverheadLamp = true;
            }
            else
            {
                model.EngenieOverheadLamp = false;
            }

            model.TimeOffset = datenow - model.StartDateTime;
            switch (_direction)
            {
                case Direction.None:
                    board.Power = 0;
                    break;
                case Direction.Forward:
                    board.Power = _power;
                    break;
                case Direction.Back:
                    board.Power = -_power;
                    break;
            }

            model.Power = board.Power;
            model.Distance = Math.Round(board.Distance,4);
            model.Speed = Math.Round(board.Speed,2);
            model.RPM = board.RPM;
            model.Direction = board.Direction;
            model.Counter = board.Counter;

        }




        //private void OnHandle(object state)
        //{
        //    // calculate acseleration F=m*a
        //    switch (_direction)
        //    {
        //        case Direction.None:
        //            model.Power = 0;
        //            break;
        //        case Direction.Forward:
        //            model.Power = _power;
        //            break;
        //        case Direction.Back:
        //            model.Power = -_power;
        //            break;

        //    }
        //    //double a = model.Power / model.UserWeight;
        //    var currentTime = DateTime.UtcNow;
        //    //double period = (double)(currentTime - time1).Milliseconds / 1000;
        //    //time1 = currentTime;
        //    //double v2 = a * period + speed;
        //    //double distance = (v2 + speed) / 2 * period;
        //    ////model.RPM = (distance / (2 * Math.PI * _radius))/_duration*60;
        //    //wheel.AddForce(currentTime.Ticks,model.Power);
        //    //totalDistance += distance;
        //    //speed = v2;
        //    //model.Distance += distance ;
        //    //model.Speed = v2;
        //}

        public void Dispose()
        {
            _displayRenderTimer?.Stop();
            board?.Dispose();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    _direction = Direction.Back;
                    break;
                case Key.Right:
                    _direction = Direction.Forward;
                    break;
                case Key.Up:
                    if (_power < MAXPOWER) _power += POWERDISCRETE;
                    if (_power > MAXPOWER) _power = MAXPOWER;
                    break;
                case Key.Down:
                    if (_power > 0) _power -= POWERDISCRETE;
                    if (_power < 0) _power = 0;
                    break;
            }
 
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                case Key.Right:
                    _direction = Direction.None;
                    break;
            }

        }
    }
}
