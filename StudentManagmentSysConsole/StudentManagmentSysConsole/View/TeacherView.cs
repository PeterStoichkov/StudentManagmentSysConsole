using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    class TeacherView
    {
        public void Render(Timer timer, Taskbar taskbar, InputBox inputBox,
            OutputBox outputBox1, OutputBox outputBox2)
        {
            RenderTime.Render(Console.WindowWidth - 20, 0, timer);
            RenderTaskbar.Render(taskbar, (int)Math.Floor(Console.WindowHeight / 1.4));
            RenderBox.Render(inputBox);
            RenderOutputBox.Render(outputBox1);
            RenderOutputBox.Render(outputBox2);
        }
    }
}
