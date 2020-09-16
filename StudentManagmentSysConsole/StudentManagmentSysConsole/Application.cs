using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole
{    
    class Application
    {
        private Timer timer;
        
        public void Start()
        {

            Console.CursorVisible = false;
            this.timer.Start();     
        }
        
        public void BootstrapStudentView()
        {

        }
        public void BootstrapTeacherView()
        {
            this.timer = new Timer();
            Input input = new Input();
            Taskbar taskbar = new Taskbar();
            TaskbarController taskbarController = new TaskbarController(taskbar);
            KeyEventArgs keyArgs = new KeyEventArgs();

            OutputBox outputBox1 = new OutputBox(new Point(10, 10), 20, 12);
            InputBox inputBox = new InputBox(new Point(80, 10), 20, 12);
            OutputBox outputBox2 = new OutputBox(new Point(8, 8), 8, 6);
            OutputBoxController outputBoxController1 = new OutputBoxController(outputBox1);
            OutputBoxController outputBoxController2 = new OutputBoxController(outputBox2);
            InputBoxController inputBoxController = new InputBoxController(inputBox);
            TeacherView teacherView = new TeacherView(timer, taskbar, inputBox, outputBox1, outputBox2);

            BorderController borderController = new BorderController(teacherView);

            TeacherController teacherController = new TeacherController(timer, inputBox, outputBox1, outputBox2,
                taskbar, input, teacherView, taskbarController,
                outputBoxController1, outputBoxController2, inputBoxController, borderController);
        }
        public void BootstrapLoginView()
        {

        }
    }
}
