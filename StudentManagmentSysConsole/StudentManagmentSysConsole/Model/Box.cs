using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManagmentSysConsole.Model
{
    abstract class Box
    {
        public Point TopLeft { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Box(Point topleft, int height, int width)
        {
            TopLeft = topleft;
            Height = height;
            Width = width;
        }

        public virtual void ChangeProps(Point topleft, int height, int width)
        {
            TopLeft = topleft;
            Height = height;
            Width = width;
        }
    }
}
