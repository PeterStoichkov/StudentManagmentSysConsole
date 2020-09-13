using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
    // See if you can order it better
    public delegate void KeyPressEventHandler(object sender, KeyEventArgs e);
    class Application
    {
        public event KeyPressEventHandler keyPress;
        // This is like the current view
        public void Start()
        {
            Console.CursorVisible = false;

            // Something like bootstrap
            Timer timer = new Timer();
            timer.Tick += (object sender, DateEventArgs e) =>
            { return String.Format(e.dateTime.ToString()); };
            Input input = new Input();
            Taskbar taskbar = new Taskbar();
            TaskbarController tkbController = new TaskbarController(taskbar);
            KeyEventArgs keyArgs = new KeyEventArgs();

            OutputBox outputBox = new OutputBox(new Point(10, 10), 20, 12);
            InputBox inputBox = new InputBox(new Point(80, 10), 20, 12);
            OutputBoxController outputBoxController = new OutputBoxController(outputBox);
            InputBoxController inputBoxController = new InputBoxController(inputBox);
            //

            while (true)
            {              
                while(!input.isKeyAvailable())
                {
                    // Here should be the current view being rendered
                    string time = "";
                    time = timer.Start();
                    Console.SetCursorPosition(40, 20);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(time);

                    RenderTaskbar.Render(taskbar, Console.WindowHeight / 2);

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    RenderBox.Render(inputBox);
                    RenderOutputBox.Render(outputBox);

                    System.Threading.Thread.Sleep(100);
                }
                keyArgs.Cki = input.GetKey();

                // Here diffrent methods will be attached to the event based on the Key
                // Triggered and deleted if needed

                // This is a pure logic for a controller
                switch (keyArgs.Cki.Key)
                {                
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        keyPress += tkbController.ChangeSelect;
                        OnKeyPress(keyArgs);
                        keyPress -= tkbController.ChangeSelect;
                        break;
                    case ConsoleKey.I:
                        keyPress += inputBoxController.ChangeState;
                        OnKeyPress(keyArgs);
                        keyPress -= inputBoxController.ChangeState;
                        break;
                    case ConsoleKey.Enter:
                        keyPress += inputBoxController.ChangeState;
                        OnKeyPress(keyArgs);
                        keyPress -= inputBoxController.ChangeState;
                        outputBoxController.FillOutputBox(inputBoxController.GetInput());
                        break;
                    case ConsoleKey.C:
                        keyPress += outputBoxController.ClearOutputBox;
                        OnKeyPress(keyArgs);
                        keyPress -= outputBoxController.ClearOutputBox;
                        break;

                }

            }
        }
        public void OnKeyPress(KeyEventArgs e)
        {
            if (keyPress != null)
            {
                keyPress(this, e);
            }
        }
        public void BootstrapStudentView()
        {

        }
        public void BootstrapTeacherView()
        {

        }
        public void BootstrapLoginView()
        {

        }
    }
}
