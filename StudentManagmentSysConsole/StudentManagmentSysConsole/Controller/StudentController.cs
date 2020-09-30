using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    class StudentController
    {
        private Timer timer;

        // Models
        private InputBox inputBox;
        private OutputBox outputBox;
        private User user;

        // Views
        private StudentView studentView;
        private Input input;

        // Controllers
        private InputBoxController inputBoxController;
        private OutputBoxController outputBoxController;
        private BorderController borderController;

        public StudentController(Timer timer, InputBox inputBox, OutputBox outputBox, StudentView studentView, 
            Input input, InputBoxController inputBoxController, OutputBoxController outputBoxController,
            BorderController borderController, User user
            )
        {
            this.timer = timer;

            this.inputBox = inputBox;
            this.outputBox = outputBox;
            this.user = user;

            this.studentView = studentView;
            this.input = input;

            this.inputBoxController = inputBoxController;
            this.outputBoxController = outputBoxController;
            this.borderController = borderController;

            timer.Tick += this.borderController.BordarChange;
            timer.Tick += KeyActive;
            
        }

        private void KeyActive(object sender, EventArgs e)
        {
            while (input.isKeyAvailable())
            {
                KeyEventArgs keyArgs = new KeyEventArgs();
                keyArgs.Cki = input.GetKey();

                switch (keyArgs.Cki.Key)
                {

                    case ConsoleKey.I:
                        timer.KeyPress += inputBoxController.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController.ChangeState;
                        break;
                    case ConsoleKey.Enter:
                        timer.KeyPress += inputBoxController.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController.ChangeState;
                        if (inputBoxController.GetInput() != null)
                        {
                            outputBoxController.FillOutputBox(inputBoxController.GetInput());
                        }
                        break;
                    case ConsoleKey.C:
                        timer.KeyPress += outputBoxController.ClearOutputBox;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= outputBoxController.ClearOutputBox;
                        break;
                    case ConsoleKey.S:
                        outputBoxController.FillOutputBox(user.DisplayInfo());
                        break;

                }
                studentView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
