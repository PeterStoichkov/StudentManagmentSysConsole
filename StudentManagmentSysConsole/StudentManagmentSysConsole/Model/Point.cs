using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    struct Point
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public Point(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
    }
}
