using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    class StudentView : View
    {
        public InputBox InputBox { get; set; }
        public OutputBox OutputBox { get; set; }


        public override void Render()
        {
            base.Render();

            RenderBox.Render(this.InputBox, new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , (int)Math.Floor(Console.WindowWidth / 1.08), 4);

            RenderOutputBox.Render(this.OutputBox, new Point(1, 1),
                (int)Math.Floor(Console.WindowWidth / 1.7), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);
        }

        public StudentView(Timer timer, InputBox inputBox, OutputBox outputBox)
            :base(timer)
        {
            InputBox = inputBox;
            OutputBox = outputBox;
        }
    }
}
