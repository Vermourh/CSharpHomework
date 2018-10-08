using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock
{
    public delegate void TimeHandler(object sender, EventArgs e);
    public class Clock
    {
        private DateTime timeClock;
        public event TimeHandler TimeIsUp;

        public DateTime TimeClock
        {
            get
            {
                return timeClock;
            }
        }

        public Clock()
        {
            DateTime now = DateTime.Now;
            timeClock = new DateTime(now.Year, now.Month, now.Day,
                now.Hour, now.Minute, now.Second + 1);
        }
        public Clock(string clockString) : this()
        {
            timeClock = DateTime.Parse(clockString);
        }
        public void TurnOn()
        {
            while (true)
            {
                if (this.Equals(DateTime.Now))
                {
                    TimeIsUp(this, new EventArgs());
                    break;
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is DateTime)
            {
                DateTime time = (DateTime)obj;
                if (time.Hour == timeClock.Hour && time.Minute == timeClock.Minute && time.Second == timeClock.Second)
                return true;
            }
            return false;
        }

        public static void timeAlert(object sender, EventArgs args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.Hour + ":"+ now.Minute + ":"+ now.Second + "到了");
        }
    }
}
