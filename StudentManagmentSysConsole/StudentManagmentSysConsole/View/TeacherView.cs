using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    class TeacherView : View
    {
        
        public Taskbar Taskbar { get; set; }
        public InputBox InputBox { get; set; }
        public OutputBox OutputBox1 { get; set; }
        public OutputBox OutputBox2 { get; set; }

        public TeacherView(Timer timer,Taskbar taskbar, InputBox inputBox,
            OutputBox outputBox1, OutputBox outputBox2)
            :base(timer)
        {
            
            Taskbar = taskbar;
            InputBox = inputBox;
            OutputBox1 = outputBox1;
            OutputBox2 = outputBox2;
        }

        public override void Render()          
        {
            base.Render();
            RenderTaskbar.Render(Taskbar, (int)Math.Floor(Console.WindowHeight / 1.4));

            RenderBox.Render(this.InputBox, new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , (int)Math.Floor(Console.WindowWidth / 1.08), 4);

            RenderOutputBox.Render(this.OutputBox1, new Point(1, 1),
                (int)Math.Floor(Console.WindowWidth / 1.6), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            RenderOutputBox.Render(this.OutputBox2, new Point((int)Math.Floor(Console.WindowWidth / 1.45), Console.WindowTop + 1),
                (int)Math.Floor(Console.WindowWidth / 3.9), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);
        }
    }
}
