using ntics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Timers;

namespace MonoCicle.Models
{
    public sealed class Wheel:IDisposable
    {
        public double Mass { get; set; } = 1;
        public double Power { get; set; }

        public double WheelLength=>wheelLength;

        public event Action SensorEvent;
        public event Action EngenieOverhead;

        public Direction Direction { get; set; }


        private Timer _timer;


        /// <summary>
        /// diametr m
        /// </summary>
        double d;
        public double wheelLength;
        double power;
        double mass=100;
        double distance;
        long startTicks;
        long t1;
        double v1;
        
        readonly object _locker = new object();


        private Wheel(double d)
        {
            BigInteger bi = new BigInteger(new byte[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 });
            var r = bi + new BigInteger(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            this.d = d;

            Span<int> numbers  = stackalloc[] { 12, 12, 12, 21, 23 };

            wheelLength = d * Math.PI;
            t1 = 0;
            v1 = 0;
            _timer = new Timer(20);
            _timer.Elapsed += OnElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;

        }

        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                if (t1 != 0)
                {
                    double power = Power;
                    double mass = Mass;
                    long t2 = e.SignalTime.Ticks;
                    // dt in sec
                    double dt = (t2 - t1) / 10000000.0;
                    double a = power / mass;
                    double v2 = a * dt + v1;
                    double dl = (v2 + v1) / 2 * dt;
                    v1 = v2;
                    if (Math.Abs(dl) > wheelLength)
                    {
                        EngenieOverhead?.Invoke();
                    }
                    if (dl > 0)
                        Direction = Direction.Forward;
                    else
                    {
                        if (dl < 0)
                            Direction = Direction.Back;
                        else
                            Direction = Direction.None;

                    }

                    distance += dl;
                    while (Math.Abs(distance) >= wheelLength)
                    {
                        SensorEvent?.Invoke();
                        if (distance > 0)
                            distance -= wheelLength;
                        else
                            distance += wheelLength;
                    }
                 }
                t1 = e.SignalTime.Ticks;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wheelSize"></param>
        /// <returns></returns>
        public static Wheel CreateWheel(WheelSize wheelSize) =>
            wheelSize switch
            {
                WheelSize.d10 => new Wheel(0.25),
                WheelSize.d12 => new Wheel(0.3),
                WheelSize.d14 => new Wheel(0.36),
                WheelSize.d16 => new Wheel(0.41),
                WheelSize.d18 => new Wheel(0.46),
                WheelSize.d22 => new Wheel(0.56),
                _             => throw new ArgumentException(message:"invalid enum value",paramName:nameof(wheelSize))

            };

        /// <summary>
        /// set power
        /// </summary>
        /// <param name="ticks">100 hano Seconds (10000000 per second)</param>
        /// <param name="power"></param>
        public void AddForce(long ticks, double powerPercent)
        {
            lock (_locker)
            {

                if (t1 != 0)
                {
                    // sec power
                    double dt = (ticks - t1) / 10000000.0;
                    double a = power / mass;
                    double v2 = a * dt + v1;
                    double dl = (v2 + v1) / 2 * dt;
                    v1 = v2;
                    double sd = distance % wheelLength;
                    distance += dl;
                    double ob = (sd + dl) / wheelLength;

                    if (ob >= 1)
                    {
                        double overDistance = (ob - Math.Truncate(ob)) * wheelLength;
                        long k = (long)(dl / overDistance);
                        if (k < 1)
                        {
                            startTicks = k;
                        }
                        long d2t = t1 + (ticks - t1) / k;
                        startTicks = d2t;
                        SensorEvent?.Invoke();
                    }
                }
                else
                {
                    startTicks = ticks;
                }
                t1 = ticks;
                power = powerPercent;
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


        //public void AddDistance(double distance)
        //{
        //    if (distance  > wheelLength)
        //    {
        //        EngenieOverhead?.Invoke(this, new EventArgs());
        //        counter += Math.Round(distance / wheelLength);
        //        distance = distance % wheelLength;
        //    }
        //    angle += distance / _oneGradusLength;
        //    if (angle > 360.0)
        //    {
        //        SensorEvent?.Invoke(this, new EventArgs());
        //        angle -= 360;
        //    }

        //}

    }

    public class EventArgsWheel:EventArgs
    {
        public long Ticks;
        public double ob;
    }

}
