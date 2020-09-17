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

        public virtual void ChangeProps(Point change_Widht_Height)
        {
           
            Height += change_Widht_Height.PosY;
            Width += change_Widht_Height.PosX;
           
            //if (TopLeft.PosX != 1)
            //{
            //    TopLeft = new Point(TopLeft.PosX + change_Widht_Height.PosX, TopLeft.PosY);
            //    Width -= change_Widht_Height.PosX;
            //}
            //if (TopLeft.PosY != 1)
            //{
            //    TopLeft = new Point(TopLeft.PosX, TopLeft.PosY + change_Widht_Height.PosY);
            //    Height -= change_Widht_Height.PosY;
            //}
        }
    }
}
