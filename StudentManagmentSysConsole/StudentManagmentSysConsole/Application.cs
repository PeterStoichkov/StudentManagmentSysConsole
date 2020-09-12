using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
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
        public void Start()
        {
            // Something like bootstrap
            Timer timer = new Timer();
            timer.Tick += (object sender, DateEventArgs e) =>
            { return String.Format(e.dateTime.ToString()); };
            Input input = new Input();
            Taskbar taskbar = new Taskbar();
            TaskbarController tkbController = new TaskbarController(taskbar);
            KeyEventArgs keyArgs = new KeyEventArgs();
            //
            
            while (true)
            {              
                while (!input.isKeyAvailable())
                {
                    // Here should be the current view being rendered
                    string time = "";
                    time = timer.Start();
                    Console.SetCursorPosition(40, 20);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(time);
                    RenderTaskbar.Render(taskbar, Console.WindowHeight / 2);
                    System.Threading.Thread.Sleep(100);
                }
                keyArgs.Cki = input.GetKey();

                // Here diffrent methods will be attached to the event based on the Key
                // Triggered and deleted if needed
                switch (keyArgs.Cki.Key)
                {                
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        keyPress += tkbController.ChangeSelect;
                        OnKeyPress(keyArgs);
                        keyPress -= tkbController.ChangeSelect;
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
    }
}
