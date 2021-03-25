using System;

namespace HomeWorkC
{
    public delegate void ClockHandler(Clock sender);
    public class Clock
    {
        public event ClockHandler Alarm;
        public event ClockHandler Tick;
        public DateTime CurrentTime { get; set; }
        public DateTime GoalTime { get; set; }
        public Clock()
        {
            CurrentTime = new System.DateTime();
        }
        public void OpenClock()
        {
            Console.WriteLine("闹钟开启啦！！！");
            Tick(this);
            Alarm(this);
        }

    }
    class Form
    {
        public Clock myClock = new Clock();
        public Form()
        {
            myClock.Alarm += Alarm1;
            myClock.Tick += Tick1;
        }
        void Alarm1(Clock sender)
        {
            if (DateTime.Compare(sender.CurrentTime, sender.GoalTime) == 0)
            {
                Console.WriteLine("闹钟响起来了");
            }
        }
        void Tick1(Clock sender)
        {
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("tick!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.myClock.GoalTime = Convert.ToDateTime("10:00:00");
            form.myClock.OpenClock();
        }
    }

}


