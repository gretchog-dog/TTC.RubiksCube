using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC.DataObjects
{
    public class Cube
    {
        public Cube(Face up, Face left, Face back, Face front, Face right, Face down)
        {
            if (up == null || left == null || back == null || front == null || right == null || down == null)
            {
                throw new ArgumentException("All faces must be defined");
            }

            Up = up;
            Left = left;
            Back = back;
            Front = front;
            Right = right;
            Down = down;
        }

        public Cube(Cube? cube)
        {
            if (cube == null)
            {
                Up = new Face(Colour.White);
                Left = new Face(Colour.Orange);
                Back = new Face(Colour.Blue);
                Front = new Face(Colour.Green);
                Right = new Face(Colour.Red);
                Down = new Face(Colour.Yellow);
            }
            else
            {
                Up = cube.Up;
                Left = cube.Left;
                Back = cube.Back;
                Front = cube.Front;
                Right = cube.Right;
                Down = cube.Down;
            }
        }

        public Cube() : this(null) { }

        public Face Up { get; set; }

        public Face Left { get; set; }

        public Face Back { get; set; }

        public Face Front { get; set; }

        public Face Right { get; set; }

        public Face Down { get; set; }
    }
}
