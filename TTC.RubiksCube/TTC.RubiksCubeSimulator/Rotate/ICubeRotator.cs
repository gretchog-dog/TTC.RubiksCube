using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;

namespace TTC.RubiksCubeSimulator.Rotate
{
    public interface ICubeRotator
    {
        void Initialise(Cube cube);
        void ApplyRotations(List<string> rotations);
        void RotateUp(bool counterClockwise = false);
        void RotateDown(bool counterClockwise = false);
        void RotateFront(bool counterClockwise = false);
        void RotateBack(bool counterClockwise = false);
        void RotateLeft(bool counterClockwise = false);
        void RotateRight(bool counterClockwise = false);
        Cube Cube { get; }
    }
}
