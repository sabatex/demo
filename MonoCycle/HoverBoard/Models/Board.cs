using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace MonoCicle.Models
{
    public class Board:IDisposable
    {
        public int RPM { get=>vs.Sum()/vs.Count;}
        public double Distance { get; set; }
        public double Speed { get => sq.Sum() / sq.Count; }
        public Direction Direction { get => wheel.Direction; }

        public event Action EngenieOverheat;

        public int Counter { get=>sensorCounter; }


        public double Power { get=>wheel.Power; set { wheel.Power = value; }}
        Timer timer;
        readonly object _locker = new object();
        Queue<int> vs = new Queue<int>();
        Queue<double> sq = new Queue<double>();
        private Wheel wheel;
        private int sensorCounter = 0;
        private int sCounter = 0;
        private long t1 = 0;
        private Board(WheelSize wheelSize)
        {
            vs.Enqueue(0);
            sq.Enqueue(0);
            wheel = Wheel.CreateWheel(wheelSize);
            wheel.SensorEvent += OnSensorEvent;
            wheel.EngenieOverhead += OnEngenieOverhead;
            wheel.Mass = 100;
            timer = new Timer(500);
            timer.Elapsed += OnElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
           lock (_locker)
           {
                Distance = sensorCounter * wheel.WheelLength;
                if (t1 !=0)
                {
                    if (sensorCounter != sCounter)
                    {
                        int count = sensorCounter - sCounter;
                        long t2 = e.SignalTime.Ticks;
                        // dt in sec
                        double dt = (t2 - t1) / 10000000.0;
                        var rpm = (int)(count / dt * 60);
                        vs.Enqueue(rpm);
                        if (vs.Count > 10) vs.Dequeue();

                        var speed = count * wheel.WheelLength / dt * 60 * 60 / 1000;
                        sq.Enqueue(speed);
                        if (sq.Count > 10) sq.Dequeue();
                        t1 = e.SignalTime.Ticks;
                    }

                }
                else
                {
                    t1 = e.SignalTime.Ticks;
                }
                sCounter = sensorCounter;
           }
        }

        private void OnEngenieOverhead()
        {
            EngenieOverheat?.Invoke();
        }

        private void OnSensorEvent()
        {
            switch (wheel.Direction)
            {
                case Direction.Forward:
                    sensorCounter++;
                    break;
                case Direction.Back:
                    sensorCounter--;
                    break;
                case Direction.None:
                    break;
            }
          
        }


        public static Board GetBoard(WheelSize wheelSize) => new Board(wheelSize);

        public void Dispose()
        {
            wheel?.Dispose();
            timer?.Dispose();
        }
    }
}
