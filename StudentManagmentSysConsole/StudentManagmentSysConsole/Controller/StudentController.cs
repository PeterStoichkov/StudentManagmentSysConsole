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

        // Views
        private StudentView studentView;
        private Input input;

        // Controllers
        private InputBoxController inputBoxController;
        private OutputBoxController outputBoxController;
        private BorderController borderController;

        public StudentController(Timer timer, InputBox inputBox, OutputBox outputBox, StudentView studentView, 
            Input input, InputBoxController inputBoxController, OutputBoxController outputBoxController,
            BorderController borderController
            )
        {
            this.timer = timer;

            this.inputBox = inputBox;
            this.outputBox = outputBox;

            this.studentView = studentView;
            this.input = input;

            this.inputBoxController = inputBoxController;
            this.outputBoxController = outputBoxController;
            this.borderController = borderController;

            
            timer.Tick += KeyActive;
            timer.Tick += this.borderController.BordarChange;
        }

        private void KeyActive(object sender, EventArgs e)
        {
            KeyEventArgs keyArgs = new KeyEventArgs();
            keyArgs.Cki = input.GetKey();

            switch (keyArgs.Cki.Key)
            {
                
                case ConsoleKey.I:
                    timer.keyPress += inputBoxController.ChangeState;
                    timer.OnKeyPress(keyArgs);
                    timer.keyPress -= inputBoxController.ChangeState;
                    break;
                case ConsoleKey.Enter:
                    timer.keyPress += inputBoxController.ChangeState;
                    timer.OnKeyPress(keyArgs);
                    timer.keyPress -= inputBoxController.ChangeState;
                    if (inputBoxController.GetInput() != null)
                    {
                        outputBoxController.FillOutputBox(inputBoxController.GetInput());
                    }
                    break;
                case ConsoleKey.C:
                    timer.keyPress += outputBoxController.ClearOutputBox;
                    timer.OnKeyPress(keyArgs);
                    timer.keyPress -= outputBoxController.ClearOutputBox;
                    break;

            }
            studentView.Render();
            System.Threading.Thread.Sleep(100);
        }
    }
}
