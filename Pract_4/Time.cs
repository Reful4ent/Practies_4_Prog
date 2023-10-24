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

        public int Seconds
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
        public int Minutes
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
        public int Hours
        {
            get => hours;
            set => hours = Math.Abs((hours + value) % 24);
            
        }

        public void MoveSeconds(int second) => Seconds = second;
        public void MoveMinutes(int minute) => Minutes = minute;
        public void MoveHours(int hour) => Hours = hour;
        public void MoveTime(int second, int minute, int hour)
        {
            MoveSeconds(second);
            MoveMinutes(minute);
            MoveHours(hour);
        }
        public Time() {; }
        public Time(int hours, int minutes, int seconds)
        {
            if (hours > 23 || minutes > 59 || seconds > 59)
                Console.WriteLine("Введено большое значение! Время будет переопределено!");
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
