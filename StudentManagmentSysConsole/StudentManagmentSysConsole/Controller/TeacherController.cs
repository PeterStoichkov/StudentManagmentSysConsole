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
        
        //Models
        private InputBox inputBox;
        private OutputBox outputBox1, outputBox2;
        private Taskbar taskbar;

        //Views
        private Input input;
        private TeacherView teacherView;

        //Controllers
        private TaskbarController taskbarController;   
        private OutputBoxController outputBoxController1, outputBoxController2;
        private InputBoxController inputBoxController;
        private BorderController borderController;

        

        public TeacherController(Timer timer, InputBox inputBox, OutputBox outputBox1, OutputBox outputBox2, Taskbar taskbar,
            Input input,TeacherView teacherView, TaskbarController taskbarController, OutputBoxController outputBoxController1, 
            OutputBoxController outputBoxController2, InputBoxController inputBoxController, BorderController borderController)
        {
            this.timer = timer;
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

            this.teacherView = teacherView;

            timer.Tick += KeyActive;
            timer.Tick += this.borderController.BordarChange;
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
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        timer.keyPress += taskbarController.ChangeSelect;
                        timer.OnKeyPress(keyArgs);
                        timer.keyPress -= taskbarController.ChangeSelect;
                        break;
                    case ConsoleKey.I:
                        timer.keyPress += inputBoxController.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.keyPress -= inputBoxController.ChangeState;
                        break;
                    case ConsoleKey.Enter:
                        timer.keyPress += inputBoxController.ChangeState;
                        timer.OnKeyPress(keyArgs);
                        timer.keyPress -= inputBoxController.ChangeState;
                        if(inputBoxController.GetInput() != null)
                        {
                            outputBoxController1.FillOutputBox(inputBoxController.GetInput());
                        }                     
                        break;
                    case ConsoleKey.C:
                        timer.keyPress += outputBoxController1.ClearOutputBox;
                        timer.OnKeyPress(keyArgs);
                        timer.keyPress -= outputBoxController1.ClearOutputBox;
                        break;

                }
                teacherView.Render();
                System.Threading.Thread.Sleep(100);
            }
        }

    }
}
