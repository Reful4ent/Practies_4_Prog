using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Pract_4
{
    public class Time
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;
        List<int> objecList = new List<int>();

        int Seconds
        {
            get => seconds;
            set
            {
                int vSec = seconds + value;
                seconds = Math.Abs((vSec) % 60);
                if (vSec % 60 == 0 || vSec > 60)
                {
                    Minutes = (vSec / 60);
                }
            }
        }
        int Minutes
        {
            get => minutes;
            set
            {
                int vMin = minutes + value;
                minutes = Math.Abs((vMin) % 60);
                if (vMin % 60 == 0 || vMin > 60)
                {
                    Hours = vMin / 60;
                }

            }
        }
        int Hours
        {
            get => hours;
            set => hours = Math.Abs((hours + value) % 24);
            
        }

        

        

        public Time() {; }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        private void AddToList()
        {
            objecList.Clear();
            objecList.Add(hours);
            objecList.Add(minutes);
            objecList.Add(seconds);
        }
        private void CheckTime(params int[] status)
        {
            AddToList();
            string time = null;
            for(int i = 0; i < status.Length; i++)
                time += status[i]==-1 ? ("0" + objecList[i]+":") : (objecList[i]+":");
            time=time.TrimEnd(':');
            Console.WriteLine(time);
        }
        public void PrintTime()
        {
            int[] status = {0,0,0};
            status[0] = Hours < 10 ? -1 : 1;
            status[1] = Minutes < 10 ? -1 : 1;
            status[2] = Seconds < 10 ? -1 : 1;
            CheckTime(status);
        }

    }
}
