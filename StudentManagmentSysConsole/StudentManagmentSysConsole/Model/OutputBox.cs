using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    class OutputBox : Box
    {
        public string Text { get; set; }

        public OutputBox(Point topleft, int width, int height)
            :base(topleft, height, width)
        {
            Text = " ";
        }
    }
}
