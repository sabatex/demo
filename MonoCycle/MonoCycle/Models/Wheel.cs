using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using static System.Math;

namespace MonoCycle.Models
{
    public sealed class Wheel : IDisposable
    {
        public double Mass { get; set; } = 1;
        public double Power { get; set; }
        public double WheelLength => wheelLength;
        public Direction Direction { get; set; }

        public event Action<int> SensorEvent;
        bool timerOnn;
        public bool TimerOnn { get=>timerOnn; set { t1 = 0;timerOnn = value; } }


        public double TestSpeed => v1;
        public double TestDistnanceFromSensor => Abs(distanceFromSensor);
        public double TestDistanceBetwenSensors => distanceBetwenSensors;

        private readonly int sensorCount;

        double wheelLength,diameter, v1,power,mass, distanceBetwenSensors;
        double distanceFromSensor;
        int lastSensor = 1;
        private Timer _timer;
        long t1;
        readonly object _locker = new object();


        private Wheel(double diametr,int sensors)
        {
            this.diameter = diametr;
            this.sensorCount = sensors;
            wheelLength = diametr * Math.PI;
            distanceBetwenSensors = wheelLength / sensorCount;
            t1 = 0;
            v1 = 0;
            lastSensor = 1;
            _timer = new Timer(20);
            _timer.Elapsed += OnElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;

        }

        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            if (TimerOnn)
            {
                lock (_locker)
                {
                    if (t1 != 0)
                    {
                        oneTimeForce((e.SignalTime.Ticks - t1) / 10000000.0);
                    }
                    t1 = e.SignalTime.Ticks;
                }
            }
        }


        private bool directionChange(double a, double b) => (Abs(a) + Abs(b)) != Abs(a + b);
        private Tuple<double,double> calcDistance(double v1,double v2,double time)
        {
            if (v1 == 0)
            {
                if (v2 > 0)
                    return new Tuple<double, double>(v2/2 * time, 0);
                else
                    return new Tuple<double, double>(0, v2/2 * time);
            }
            if (v2 == 0)
            {
                if (v1 > 0)
                    return new Tuple<double, double>(0,0 - v1 / 2 * time);
                else
                    return new Tuple<double, double>(v1 / 2 * time,0);
            }

            if (directionChange(v1,v2))
            {
                double dv = time/(Math.Abs(v1) + Math.Abs(v2));
                double dt1 = Abs(dv * v1);
                double dt2 = Abs(dv * v2);
                if (v1 > 0)
                    return new Tuple<double, double>(v1/2 * dt1, v2/2 * dt2);
                else
                    return new Tuple<double, double>(v2/2 * dt2, v1/2 * dt1);
 
            }


            if ((v1 + v2) > 0)
                return new Tuple<double, double>((v2 + v1) / 2 * time, 0);
            else
                return new Tuple<double, double>(0, (v2 + v1) / 2 * time);
        }

        private void runForward(double distance)
        {
            if (distance < 0)
                throw new Exception("For run forward, the distance must be positive");

            if (distanceFromSensor < 0)
            {
                // change direction
                if (Abs(distanceFromSensor) > distance)
                {
                    distanceFromSensor += distance;
                    return;
                }
                distanceFromSensor += distance;
                SensorEvent.Invoke(lastSensor); // change direction
            }
            else
            {
                distanceFromSensor += distance;
            }
            while (distanceFromSensor >= distanceBetwenSensors)
            {

                lastSensor++;
                if (lastSensor > sensorCount) lastSensor = 1;
                distanceFromSensor -= distanceBetwenSensors;
                SensorEvent.Invoke(lastSensor);
            }
        }
        private void runBackward(double distance)
        {
            if (distance > 0)
                throw new Exception("For run forward, the distance must be negativetive");

            if (distanceFromSensor > 0)
            {
                // change direction
                if (Abs(distanceFromSensor) > Abs(distance))
                {
                    distanceFromSensor += distance;
                    return;
                }
                distanceFromSensor += distance;
                SensorEvent.Invoke(lastSensor); // change direction
            }
            else
            {
                distanceFromSensor += distance;
            }
            while (Abs(distanceFromSensor) >= distanceBetwenSensors)
            {

                lastSensor--;
                if (lastSensor <= 0) lastSensor = sensorCount;
                distanceFromSensor += distanceBetwenSensors;
                SensorEvent.Invoke(lastSensor);
            }
        }

        private void oneTimeForce(double time)
        {
            // next elapsed
            double a = Power / Mass; // calc accelerate
            double v2 = a * time + v1; // calc current speed
            double absSpeed = Math.Abs(v1) + Math.Abs(v2);
            var currentDistance = calcDistance(v1, v2, time);
            // run forvard
                if (currentDistance.Item1 != 0)
                    runForward(currentDistance.Item1);
                if (currentDistance.Item2 != 0)
                    runBackward(currentDistance.Item2);
                 v1 = v2; // store curennt speed as v1

        }
        /// <summary>
        /// For external tested 
        /// </summary>
        /// <param name="time"></param>
        public void TestOneTimeForce(double time) => oneTimeForce(time);


        /// <summary>
        /// Create wheel with preset diameter
        /// </summary>
        /// <param name="wheelSize"></param>
        /// <returns></returns>
        public static Wheel CreateWheel(WheelSize wheelSize,int sensors = 2) =>
            wheelSize switch
            {
                WheelSize.d10 => new Wheel(0.25,sensors),
                WheelSize.d12 => new Wheel(0.3, sensors),
                WheelSize.d14 => new Wheel(0.36, sensors),
                WheelSize.d16 => new Wheel(0.41, sensors),
                WheelSize.d18 => new Wheel(0.46, sensors),
                WheelSize.d22 => new Wheel(0.56, sensors),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(wheelSize))

            };

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
