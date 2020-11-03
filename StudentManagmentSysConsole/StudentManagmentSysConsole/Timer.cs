using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    public delegate void TickEventHander(object sender, EventArgs e);
    public delegate void KeyPressEventHandler(object sender, KeyEventArgs e);
    public delegate void LoginInfoEventHandler(object sender, LoginInfoEventArgs e);
    public delegate void TeacherRequestEventHandler(object sender, TeacherInfoEventArgs e);
    class Timer
    {
        public event TickEventHander Tick;
        public event KeyPressEventHandler KeyPress;
        public event LoginInfoEventHandler LogInfo;
        public event TeacherRequestEventHandler TeacherRequest;

        public void OnTeacherRequest(TeacherInfoEventArgs e)
        {
            if(TeacherRequest != null)
            {
                TeacherRequest(this, e);
            }
        }

        private void OnTick(EventArgs e)
        {
            if (Tick != null)
            {
                Tick(this, e);
            }
        }

        public void OnKeyPress(KeyEventArgs e)
        {
            if (KeyPress != null)
            {
                KeyPress(this, e);
            }
        }

        public void OnLogInfo(LoginInfoEventArgs e)
        {
            if (LogInfo != null)
            {
                LogInfo(this, e);
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
