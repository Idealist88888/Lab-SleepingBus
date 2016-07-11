using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingBus_Business
{
    class Alarm
    {
        public int Sound { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string NameStation { get; set; }
        public string NameCity { get; set; }

        public int Distance { get; set; }

        double destinationDistance;
        public double DestinationDistance
        {
            get
            {
                return destinationDistance;
            }

            set
            {
                destinationDistance = value;
            }
        }

        public bool Vibration { get; set; }
        public bool IsAlarming { get; set; }

        public bool Repeats { get; set; }

    }
}
