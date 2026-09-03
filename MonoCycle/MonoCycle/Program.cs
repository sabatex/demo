using MonoCycle.Models;
using System;

namespace MonoCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // check model 
            var wheel = Wheel.CreateWheel(WheelSize.d22);
            wheel.TimerOnn = false;
            wheel.Mass = 100;
            wheel.Power = 10;
            wheel.SensorEvent += Wheel_SensorEvent;

            wheel.TestOneTimeForce(1);
            ShowWheelResult(wheel);
            wheel.Power = -10;
            wheel.TestOneTimeForce(1);
            ShowWheelResult(wheel);
            wheel.Power = 10;
            wheel.TestOneTimeForce(1);

            ShowWheelResult(wheel);
            wheel.Power = 10;



            double tick = 1;
            for (int i =0;i<10;i++)
            {
                Console.Write($"Tick {tick} with power {wheel.Power}, sensors events: ");
                tick++;
                wheel.TestOneTimeForce(1);
                ShowWheelResult(wheel);
             }
            wheel.Power = -10;
            for (int i = 0; i < 40; i++)
            {
                Console.Write($"Tick {tick} with power {wheel.Power}, sensors events: ");
                tick+=1;
                wheel.TestOneTimeForce(1);
                ShowWheelResult(wheel);
            }

            Console.WriteLine("Hello World!");
        }

        private static void ShowWheelResult(Wheel wheel)
        {
            var dist = wheel.TestDistnanceFromSensor < (wheel.TestDistanceBetwenSensors - wheel.TestDistnanceFromSensor) ? wheel.TestDistnanceFromSensor : wheel.TestDistanceBetwenSensors - wheel.TestDistnanceFromSensor;
            Console.WriteLine($"\n\r Speed: {wheel.TestSpeed} DistanceFromSensor: {dist}");

        }

        private static void Wheel_SensorEvent(int obj)
        {
            Console.Write($" {obj}");
        }
    }
}
