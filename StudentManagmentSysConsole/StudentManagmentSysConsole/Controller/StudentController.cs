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
        private InputFilter inputFilter;
        private QueryCreator queryCreator;

        // Models
        private InputBox inputBox;
        private OutputBox outputBox;
        private Student student;

        // Views
        private StudentView studentView;
        private Input input;

        // Controllers
        private InputBoxController inputBoxController;
        private OutputBoxController outputBoxController;
        private BorderController borderController;

        public StudentController(Timer timer, InputFilter inputFilter, InputBox inputBox, OutputBox outputBox, StudentView studentView, 
            Input input, InputBoxController inputBoxController, OutputBoxController outputBoxController,
            BorderController borderController, User user, QueryCreator queryCreator
            )
        {
            this.timer = timer;
            this.inputFilter = inputFilter;
            this.queryCreator = queryCreator;

            this.inputBox = inputBox;
            this.outputBox = outputBox;
            this.student = new Student(user.Password, user.Username, user.LetterID,
                user.FirstName, user.LastName, user.FieldID, user.Subject); 

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
                        if (inputBoxController.GetInput(2) != null)
                        {
                            queryCreator.CreateQuery(inputBoxController.GetInput(2));
                        }
                        // send Query to DB and display info in outputbox
                        outputBoxController.FillOutputBox(queryCreator.ReturnQuery());
                        break;
                    case ConsoleKey.C:
                        timer.KeyPress += outputBoxController.ClearOutputBox;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= outputBoxController.ClearOutputBox;
                        break;
                    case ConsoleKey.S:
                        outputBoxController.FillOutputBox(student.DisplayInfo());
                        break;

                }
                studentView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
