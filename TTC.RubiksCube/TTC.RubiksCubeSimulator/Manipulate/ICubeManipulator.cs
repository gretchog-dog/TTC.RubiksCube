using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC.RubiksCubeSimulator.Manipulate
{
    public interface ICubeManipulator
    {
        void ActOnUserInput(int input);

        void Greet();
    }
}
