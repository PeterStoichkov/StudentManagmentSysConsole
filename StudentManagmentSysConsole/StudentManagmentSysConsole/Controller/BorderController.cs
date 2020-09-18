using StudentManagmentSysConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Controller
{
    // This class will deal with the resizing of the window
    class BorderController
    {
        private int windowHeight;
        private int windowWidth;
        private IView view;
        

        public BorderController(IView view)
        {
            this.view = view;
            this.windowHeight = Console.WindowHeight;
            this.windowWidth = Console.WindowWidth;
        }

        public void BordarChange(object sender, EventArgs e)
        {
            if (windowHeight != Console.WindowHeight || windowWidth != Console.WindowWidth)
            {
                Console.Clear();   
                view.Render();
            }              
        }

        // Changes the fields of the Controller but also it returns a point wich contains the change in width, height
        public Point SetWindowParams()
        {
            Point changeWidthHight = new Point(Console.WindowWidth - this.windowWidth,
                Console.WindowHeight - this.windowHeight);

            this.windowHeight = Console.WindowHeight;
            this.windowWidth = Console.WindowWidth;

            return changeWidthHight;
        }
    }
}
