using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC.DataObjects
{
    public class Spot
    {
        public Spot(): this(Colour.White) { }

        public Spot(Colour colour)
        {
            Colour = colour;
        }

        public Colour Colour { get; set; }
    }
}
