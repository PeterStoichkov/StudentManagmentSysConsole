using StudentManagmentSysConsole.View;
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
        private LoginDBController fakeDBController;

        public LoginController(Timer timer, Input input, LoginView loginView, 
            InputBoxController inputBoxController1, InputBoxController inputBoxController2,
            OutputBoxController outputBoxController, BorderController borderController, 
            InputFilter inputFilter, LoginDBController fakeDBController
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
            this.fakeDBController = fakeDBController;

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
                        timer.KeyPress += inputBoxController1.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController1.ChangeState;
                        break;
                    case ConsoleKey.P:
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

                            timer.LogInfo += fakeDBController.LoginDBEvent;
                            timer.OnLogInfo(loginInfoEventArgs);
                            timer.LogInfo -= fakeDBController.LoginDBEvent;
                        }
                       
                        break;

                }
                loginView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
