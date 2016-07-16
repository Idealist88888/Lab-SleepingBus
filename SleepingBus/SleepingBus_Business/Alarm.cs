using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingBus_Business
{
    public class Alarm
    {
        public int Sound { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string NameStation { get; set; }
        public string NameCity { get; set; }

        public double Distance { get; set; }        
        public bool Vibration { get; set; }
        public bool IsOn { get; set; }

        public bool[] Repeats { get; set; }

    }
}
