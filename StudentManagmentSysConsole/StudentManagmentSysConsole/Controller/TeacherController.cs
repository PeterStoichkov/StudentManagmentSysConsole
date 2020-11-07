using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    class TeacherController
    {
        private Timer timer;
        private InputFilter inputFilter;
        private QueryCreator queryCreator;

        //Models
        private InputBox inputBox;
        private OutputBox outputBox1, outputBox2;
        private Taskbar taskbar;
        private Teacher teacher;

        //Views
        private Input input;
        private TeacherView teacherView;

        //Controllers
        private TaskbarController taskbarController;   
        private OutputBoxController outputBoxController1, outputBoxController2;
        private InputBoxController inputBoxController;
        private BorderController borderController;
        private TeacherDBController teacherDBController;
        

        public TeacherController(Timer timer, InputFilter inputFilter, InputBox inputBox, OutputBox outputBox1, OutputBox outputBox2, Taskbar taskbar,
            Input input,TeacherView teacherView, TaskbarController taskbarController, OutputBoxController outputBoxController1, 
            OutputBoxController outputBoxController2, InputBoxController inputBoxController, BorderController borderController, User user, QueryCreator queryCreator, TeacherDBController teacherDBController)
        { 
            this.timer = timer;
            this.inputFilter = inputFilter;
            this.queryCreator = queryCreator;

            this.inputBox = inputBox;
            this.outputBox1 = outputBox1;
            this.outputBox2 = outputBox2;
            this.taskbar = taskbar;
            this.input = input;
            
            this.taskbarController = taskbarController;
            this.outputBoxController1 = outputBoxController1;
            this.outputBoxController2 = outputBoxController2;
            this.inputBoxController = inputBoxController;
            this.borderController = borderController;
            this.teacherDBController = teacherDBController;

            this.teacherView = teacherView;
            this.teacher = new Teacher(user.Password, user.Username, user.LetterID,
                user.FirstName, user.LastName, user.FieldID, user.Subject);

            timer.Tick += KeyActive;
            timer.Tick += this.borderController.BordarChange;
        }

        private void KeyActive(object sender, EventArgs e)
        {
             
            while (input.isKeyAvailable())
            {
                // Here should be the current view being rendered                  

                KeyEventArgs keyArgs = new KeyEventArgs();
                TeacherInfoEventArgs teacherInfoEventArgs = new TeacherInfoEventArgs();
                keyArgs.Cki = input.GetKey();

                // Here diffrent methods will be attached to the event based on the Key
                // Triggered and deleted if needed

                // This is a pure logic for a controller -- into a method
                switch (keyArgs.Cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        timer.KeyPress += taskbarController.ChangeSelect;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= taskbarController.ChangeSelect;
                        break;
                    case ConsoleKey.I:
                        timer.KeyPress += inputBoxController.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController.ChangeState;
                        break;
                    case ConsoleKey.Enter:

                        timer.KeyPress += inputBoxController.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= inputBoxController.ChangeState;

                        if(inputBoxController.GetInput(2) != null)
                        {
                            queryCreator.CreateQuery(inputBoxController.GetInput(2), taskbar.ReturnStateAsInt());

                            if (taskbar.ReturnStateAsInt() == 4) teacherInfoEventArgs.Action = 1;
                            else teacherInfoEventArgs.Action = 0;

                            teacherInfoEventArgs.Query = queryCreator.ReturnQuery();
                            teacherInfoEventArgs.RawInput = queryCreator.Input;

                            timer.TeacherRequest += teacherDBController.TeacherRequestEventHandler;
                            timer.OnTeacherRequest(teacherInfoEventArgs);
                            timer.TeacherRequest -= teacherDBController.TeacherRequestEventHandler;
                            inputBoxController.NullInput();
                        }
                        if(teacherInfoEventArgs.Action == 1) {

                            outputBoxController1.FillOutputBox(teacherDBController.ReturnOperaionResult());
                        } else { 
                            outputBoxController2.FillOutputBox(teacherDBController.ReturnOperaionResult());
                        }
                        break;
                    case ConsoleKey.C:
                        timer.KeyPress += outputBoxController1.ClearOutputBox;
                        timer.OnKeyPress(keyArgs);
                        timer.KeyPress -= outputBoxController1.ClearOutputBox;
                        break;
                    case ConsoleKey.T:
                        outputBoxController1.FillOutputBox(teacher.DisplayInfo());
                        break;
                    
                }
                teacherView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }

    }
}
