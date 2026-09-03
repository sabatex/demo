using ntics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MonoCicle.Models
{
    public class MainView: ObservableObject
    {
        public MainView(DateTime initialTime)
        {
            StartDateTime = initialTime;
            PreviousDateTime = initialTime;
        }
        public readonly DateTime StartDateTime;
        public DateTime PreviousDateTime { get; set; }
        private double power;
        public double Power { get=>power; set=>SetProperty(ref power,value); }

        private double speed;
        public double Speed { get=>speed; set=>SetProperty(ref speed,value); }

        private double rpm;
        public double RPM { get=>rpm; set=>SetProperty(ref rpm,value); }

        private double distance;
        public double Distance { get=>distance; set=>SetProperty(ref distance, value); }

        private bool engenieOverheadLamp;
        public bool EngenieOverheadLamp { get=>!engenieOverheadLamp; set=>SetProperty(ref engenieOverheadLamp,value); }

        private TimeSpan timeOffset;
        public TimeSpan TimeOffset { get => timeOffset; set => SetProperty(ref timeOffset, value); }
        public double UserWeight { get; set; }


        Direction direction;
        public Direction Direction { get=>direction; set=>SetProperty(ref direction,value); }

        int counter;
        public int Counter { get=>counter; set=>SetProperty(ref counter,value); }

    }
}
