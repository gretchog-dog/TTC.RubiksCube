using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC.DataObjects
{
    public class Face
    {
        public Face() 
        {
            Spots = SetSpots(Colour.White);
        }

        public Face(Spot[,] spots)
        {
            if (spots!.GetLength(0) != 3 || spots!.GetLength(1) != 3)
            {
                throw new ArgumentException("Face must be defined as a 3x3 grid");
            }

            foreach(Spot spot in spots)
            {
                if (spot == null)
                {
                    throw new ArgumentException("A face must have all spots defined");
                }
            }

            Spots = spots;
        }

        public Face(Colour colour)
        {
            Spots = SetSpots(colour);
        }

        private Spot[,] SetSpots(Colour colour)
        {
            var spots = new Spot[3, 3];
            for (int xIndex = 0; xIndex < 3; xIndex++)
            {
                for (int yIndex = 0; yIndex < 3; yIndex++)
                {
                    spots[xIndex, yIndex] = new Spot(colour);
                }
            }

            return spots;
        }

        public Spot[,] Spots { get; set; }
    }
}
