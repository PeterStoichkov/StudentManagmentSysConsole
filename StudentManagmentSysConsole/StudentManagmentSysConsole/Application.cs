using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Net.Http.Headers;

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
            this.timer = new Timer();
            Input input = new Input();
            KeyEventArgs keyArgs = new KeyEventArgs();

            OutputBox outputBox = new OutputBox(new Point(1, 1),
                Console.WindowLeft + 70, (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            InputBox inputBox = new InputBox(new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , Console.WindowWidth - 8, 4);

            OutputBoxController outputBoxController = new OutputBoxController(outputBox);
            InputBoxController inputBoxController = new InputBoxController(inputBox);

            StudentView studentView = new StudentView(timer, inputBox, outputBox);

            BorderController borderController = new BorderController(studentView);

            StudentController studentController = new StudentController(timer, inputBox, outputBox,
                studentView, input, inputBoxController, outputBoxController, borderController
                );
        }
        public void BootstrapTeacherView()
        {
            this.timer = new Timer();
            Input input = new Input();
            Taskbar taskbar = new Taskbar();
            TaskbarController taskbarController = new TaskbarController(taskbar);
            KeyEventArgs keyArgs = new KeyEventArgs();

            OutputBox outputBox1 = new OutputBox(new Point(1, 1),
                (int)Math.Floor(Console.WindowWidth / 1.7), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            InputBox inputBox = new InputBox(new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , (int)Math.Floor(Console.WindowWidth / 1.08), 4);

            OutputBox outputBox2 = new OutputBox(new Point((int)Math.Floor(Console.WindowWidth / 1.45), Console.WindowTop + 1),
                (int)Math.Floor(Console.WindowWidth / 3.9), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

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
