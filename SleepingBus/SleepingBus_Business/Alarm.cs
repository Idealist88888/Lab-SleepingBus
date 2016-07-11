using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingBus_Business
{
    class Alarm
    {
        int sound;
        public int Sound
        {
            get
            {
                return sound;
            }

            set
            {
                sound = value;
            }
        }

        int location;
        public int Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        string nameLocation;
        public string NameLocation
        {
            get
            {
                return nameLocation;
            }

            set
            {
                nameLocation = value;
            }
        }

        int distance;
        public int Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
            }
        }

        bool vibration;
        public bool Vibration
        {
            get
            {
                return vibration;
            }

            set
            {
                vibration = value;
            }
        }

        bool repeats;
        public bool Repeats
        {
            get
            {
                return repeats;
            }

            set
            {
                repeats = value;
            }
        }


    }
}
