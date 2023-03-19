using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;

namespace TTC.RubiksCubeSimulator.Display
{
    internal class CubeLayoutHandler : ICubeLayoutHandler
    {
        private Cube _cube;

        public CubeLayoutHandler()
        {
            _cube = new Cube();
        }

        public void WriteLayoutToConsole()
        {
            var cubeAsString = ConsoleOutputHelper.CreateLayoutString(_cube);
            Console.WriteLine(cubeAsString);
        }

        public void SetLayout(Cube cube)
        {
            Cube = cube;
        }

        public Cube Cube { get { return _cube; } private set { _cube = value; } }
    }
}
