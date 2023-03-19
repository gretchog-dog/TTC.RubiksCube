using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;

namespace TTC.RubiksCubeSimulator.Display
{
    internal interface ICubeLayoutHandler
    {
        void SetLayout(Cube cube);
        void WriteLayoutToConsole();
    }
}
