﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    class InputBox : Box
    {
        public bool Active { get; set; }

        public InputBox(Point topleft, int width, int height)
            : base(topleft, height, width)
        {
            Active = false;
        }
    }
}
