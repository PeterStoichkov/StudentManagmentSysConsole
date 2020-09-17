using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    abstract class View : IView
    {
        public Timer Timer { get; set; }

        public View(Timer timer)
        {
            Timer = timer;
        }

        public virtual void Render() {
            RenderTime.Render(Console.WindowWidth - 23, 0, Timer);
            Console.CursorVisible = false;
        }
    }
}
