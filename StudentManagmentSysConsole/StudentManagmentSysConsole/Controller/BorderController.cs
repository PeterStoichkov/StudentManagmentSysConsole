using System;
using System.Collections.Generic;
using System.Linq;
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
            SetWindowParams();
        }

        public void BordarChange(object sender, EventArgs e)
        {
            if (windowHeight != Console.WindowHeight || windowWidth != Console.WindowWidth)
            {
                Console.Clear();
                view.Render();
                SetWindowParams();
            }              
        }

        public void SetWindowParams()
        {
            this.windowHeight = Console.WindowHeight;
            this.windowWidth = Console.WindowWidth;
        }
    }
}
