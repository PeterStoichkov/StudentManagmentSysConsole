using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.View
{
    class LoginView : View
    {
        public InputBox InputBox1 { get; set; }
        public InputBox InputBox2 { get; set; }
        public OutputBox OutputBox { get; set; }


        public LoginView(Timer timer, InputBox inputBox1, InputBox inputBox2, OutputBox outputBox)
            :base(timer)
        {
            this.InputBox1 = inputBox1;
            this.InputBox2 = inputBox2;
            this.OutputBox = outputBox;
        }


        public override void Render()
        {
            base.Render();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 21, Console.WindowHeight / 2 + 5);
            Console.WriteLine("USERNAME : ");
            RenderBox.Render(InputBox1, new Point(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 4),
                (int)Math.Floor(Console.WindowWidth / 5.5), 2);

            Console.SetCursorPosition(Console.WindowWidth / 2 - 21, Console.WindowHeight / 2 + 9);
            Console.WriteLine("PASSWORD : ");
            RenderBox.Render(InputBox2, new Point(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 8),
                (int)Math.Floor(Console.WindowWidth / 5.5), 2);

            RenderOutputBox.Render(OutputBox, new Point(5, 1),
                Console.WindowWidth - 10, Console.WindowHeight - 3);
        }
    }
}
