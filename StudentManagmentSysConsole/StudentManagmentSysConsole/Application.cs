﻿using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{
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
            while (true)
            {
                while (!input.isKeyAvailable())
                {
                    string time = "";
                    time = timer.Start();
                    Console.SetCursorPosition(40, 20);
                    Console.WriteLine(time);
                    RenderTaskbar.Render(taskbar, Console.WindowHeight / 2);
                    System.Threading.Thread.Sleep(60);
                }
                keyArgs.Cki = input.GetKey();

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
