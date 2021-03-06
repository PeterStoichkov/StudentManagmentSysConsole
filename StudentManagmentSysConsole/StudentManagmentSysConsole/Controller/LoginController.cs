﻿using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    class LoginController
    {
        private Timer timer;
        private InputFilter inputFilter;
        // Models
        //-- these seem unneccessery so here we wont use them

        // Views
        private Input input;
        private LoginView loginView;
        // Controllers
        private InputBoxController inputBoxController1, inputBoxController2;
        private OutputBoxController outputBoxController;
        private BorderController borderController;
        private LoginDBController loginDBController;

        public LoginController(Timer timer, Input input, LoginView loginView, 
            InputBoxController inputBoxController1, InputBoxController inputBoxController2,
            OutputBoxController outputBoxController, BorderController borderController, 
            InputFilter inputFilter, LoginDBController loginDBController
            )
        {
            this.timer = timer;
            this.inputFilter = inputFilter;

            this.input = input;
            this.loginView = loginView;

            this.inputBoxController1 = inputBoxController1;
            this.inputBoxController2 = inputBoxController2;
            this.outputBoxController = outputBoxController;
            this.borderController = borderController;
            this.loginDBController = loginDBController;

            this.timer.Tick += this.borderController.BordarChange;
            this.timer.Tick += KeyActive;
        }
        private void KeyActive(object sender, EventArgs e)
        {

            while (input.isKeyAvailable())
            {
                 
                KeyEventArgs keyArgs = new KeyEventArgs();
                keyArgs.Cki = input.GetKey();

                // Here diffrent methods will be attached to the event based on the Key
                // Triggered and deleted if needed

                switch (keyArgs.Cki.Key)
                { 
                    case ConsoleKey.U:
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 11);
                        Console.WriteLine("                                   ");
                        timer.KeyPress += inputBoxController1.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController1.ChangeState;
                        break;
                    case ConsoleKey.P:
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 11);
                        Console.WriteLine("                                   ");
                        timer.KeyPress += inputBoxController2.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController2.ChangeState;
                        break;
                    case ConsoleKey.Enter:
                        timer.KeyPress += inputBoxController1.ChangeState;
                        timer.KeyPress += inputBoxController2.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController1.ChangeState;
                        timer.KeyPress -= inputBoxController2.ChangeState;




                        LoginInfoEventArgs loginInfoEventArgs = new LoginInfoEventArgs();

                        if (inputBoxController1.GetInput(1) != null && inputBoxController2.GetInput(1) != null)
                        {
                            loginInfoEventArgs.Username = inputBoxController1.GetInput(1);
                            loginInfoEventArgs.Password = inputBoxController2.GetInput(1);

                            timer.LogInfo += loginDBController.LoginDBEvent;
                            timer.OnLogInfo(loginInfoEventArgs);
                            timer.LogInfo -= loginDBController.LoginDBEvent;
                        }
                        else
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 11);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("* Didn't enter username or password");
                            Console.SetCursorPosition(0, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        inputBoxController1.NullInput();
                        inputBoxController2.NullInput();
                        break;

                }
                loginView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
