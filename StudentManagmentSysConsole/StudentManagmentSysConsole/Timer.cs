using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    public delegate string TickEventHander(object sender, DateEventArgs e); 
    class Timer
    {
        public event TickEventHander Tick;

        private string OnTick(DateEventArgs e)
        {
            if (Tick != null)
            {
                return Tick(this, e);
            }
            else return null;
            
        }

        public string Start()
        {
            while (true)
            {
                DateEventArgs e = new DateEventArgs();
                e.dateTime = DateTime.Now;             
                System.Threading.Thread.Sleep(50); // This should be changed somehow as for how long to sleep
                return OnTick(e);
            }
        }
    }
}
