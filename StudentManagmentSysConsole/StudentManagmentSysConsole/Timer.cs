using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    public delegate void TickEventHander(object sender, EventArgs e);
    public delegate void KeyPressEventHandler(object sender, KeyEventArgs e);
    class Timer
    {
        public event TickEventHander Tick;
        public event KeyPressEventHandler keyPress;

        private void OnTick(EventArgs e)
        {
            if (Tick != null)
            {
                Tick(this, e);
            }
        }

        public void OnKeyPress(KeyEventArgs e)
        {
            if (keyPress != null)
            {
                keyPress(this, e);
            }
        }

        public void Start()
        {
            while (true)
            {

                OnTick(EventArgs.Empty);
                System.Threading.Thread.Sleep(50); // This should be changed somehow as for how long to sleep
                
            }
        }

        public string ReturnTime() { return DateTime.Now.ToString("g"); }

        }
}
