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
        // Models
        //-- these seem unneccessery so here we wont use them

        // Views
        private Input input;
        private LoginView loginView;
        // Controllers
        private InputBoxController inputBoxController1, inputBoxController2;
        private OutputBoxController outputBoxController;
        private BorderController borderController;

        public LoginController(Timer timer, Input input, LoginView loginView, 
            InputBoxController inputBoxController1, InputBoxController inputBoxController2,
            OutputBoxController outputBoxController, BorderController borderController
            )
        {
            this.timer = timer;

            this.input = input;
            this.loginView = loginView;

            this.inputBoxController1 = inputBoxController1;
            this.inputBoxController2 = inputBoxController2;
            this.outputBoxController = outputBoxController;
            this.borderController = borderController;

            this.timer.Tick += this.borderController.BordarChange;
            this.timer.Tick += KeyActive;
        }
        private void KeyActive(object sender, EventArgs e)
        {

            while (input.isKeyAvailable())
            {
                // Here should be the current view being rendered                  



                KeyEventArgs keyArgs = new KeyEventArgs();
                keyArgs.Cki = input.GetKey();

                // Here diffrent methods will be attached to the event based on the Key
                // Triggered and deleted if needed

                // This is a pure logic for a controller -- into a method
                switch (keyArgs.Cki.Key)
                { 
                    case ConsoleKey.U:
                        timer.keyPress += inputBoxController1.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.keyPress -= inputBoxController1.ChangeState;
                        break;
                    case ConsoleKey.P:
                        timer.keyPress += inputBoxController2.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.keyPress -= inputBoxController2.ChangeState;
                        break;
                    case ConsoleKey.Enter:
                        
                        break;

                }
                loginView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
