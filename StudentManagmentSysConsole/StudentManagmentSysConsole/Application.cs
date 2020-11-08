using StudentManagmentSysConsole.Controller;
using StudentManagmentSysConsole.Model;
using StudentManagmentSysConsole.View;
using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

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
        
        public void BootstrapStudentView(User _user)
        {
            this.timer = new Timer();

            Input input = new Input();

            User user = _user;

            OutputBox outputBox = new OutputBox(new Point(1, 1),
                Console.WindowLeft + 70, (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            InputBox inputBox = new InputBox(new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , Console.WindowWidth - 8, 4);

            OutputBoxController outputBoxController = new OutputBoxController(outputBox);
            InputBoxController inputBoxController = new InputBoxController(inputBox);
            StudentDBController studentDBController = new StudentDBController();

            StudentView studentView = new StudentView(timer, inputBox, outputBox);

            BorderController borderController = new BorderController(studentView);

            InputFilter inputFilter = new InputFilter();

            QueryCreator queryCreator = new QueryCreator(_user);


            StudentController studentController = new StudentController(timer, inputFilter, inputBox, outputBox,
                studentView, input, inputBoxController, outputBoxController, borderController, user, queryCreator,
                studentDBController
                );
        }
        public void BootstrapTeacherView(User _user)
        {

            User user = _user;

            this.timer = new Timer();
            Input input = new Input();
            Taskbar taskbar = new Taskbar();
            TaskbarController taskbarController = new TaskbarController(taskbar);
            

            OutputBox outputBox1 = new OutputBox(new Point(1, 1),
                (int)Math.Floor(Console.WindowWidth / 1.7), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            InputBox inputBox = new InputBox(new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , (int)Math.Floor(Console.WindowWidth / 1.08), 4);

            OutputBox outputBox2 = new OutputBox(new Point((int)Math.Floor(Console.WindowWidth / 1.45), Console.WindowTop + 1),
                (int)Math.Floor(Console.WindowWidth / 3.9), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            OutputBoxController outputBoxController1 = new OutputBoxController(outputBox1);
            OutputBoxController outputBoxController2 = new OutputBoxController(outputBox2);
            InputBoxController inputBoxController = new InputBoxController(inputBox);
            TeacherDBController teacherDBController = new TeacherDBController();

            TeacherView teacherView = new TeacherView(timer, taskbar, inputBox, outputBox1, outputBox2);

            BorderController borderController = new BorderController(teacherView);

            InputFilter inputFilter = new InputFilter();

            QueryCreator queryCreator = new QueryCreator(_user);

            TeacherController teacherController = new TeacherController(timer, inputFilter, inputBox, outputBox1, outputBox2,
                taskbar, input, teacherView, taskbarController, outputBoxController1,
                outputBoxController2, inputBoxController, borderController,
                user, queryCreator, teacherDBController);
        }
        public void BootstrapLoginView()
        {
            this.timer = new Timer();
            Input input = new Input();

            InputBox inputBox1 = new InputBox(new Point(Console.WindowWidth / 2, Console.WindowHeight / 2),
                (int)Math.Floor(Console.WindowWidth / 1.7), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            InputBox inputBox2 = new InputBox(new Point(1, (int)Math.Floor(Console.WindowHeight / 1.4) + 1)
                    , (int)Math.Floor(Console.WindowWidth / 1.08), 4);

            OutputBox outputBox = new OutputBox(new Point((int)Math.Floor(Console.WindowWidth / 1.45), Console.WindowTop + 1),
                (int)Math.Floor(Console.WindowWidth / 3.9), (int)Math.Floor(Console.WindowHeight / 1.7) + 1);

            LoginView loginView = new LoginView(timer, inputBox1, inputBox2, outputBox);

            BorderController borderController = new BorderController(loginView);

            OutputBoxController outputBoxController = new OutputBoxController(outputBox);
            InputBoxController inputBoxController1 = new InputBoxController(inputBox1);
            InputBoxController inputBoxController2 = new InputBoxController(inputBox2);
            InputFilter inputFilter = new InputFilter();
            LoginDBController fakeDBController = new LoginDBController(this);

            LoginController loginController = new LoginController(timer, input, loginView, inputBoxController1, inputBoxController2,
                outputBoxController, borderController, inputFilter, fakeDBController);
        }
    }
}
