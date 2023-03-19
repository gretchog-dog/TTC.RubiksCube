using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;
using TTC.RubiksCubeSimulator.Extensions;

namespace TTC.RubiksCubeSimulator.Rotate
{
    internal class CubeRotator : ICubeRotator
    {
        private Cube _cube;

        public CubeRotator()
        {
            Cube = new Cube();
        }

        public void Initialise(Cube cube)
        {
            Cube = cube;
        }

        public void ApplyRotations(List<string> rotations)
        {
            if (AreValidRotations(rotations))
            {
                ProcessRotations(rotations);
            }
        }

        private bool AreValidRotations(List<string> rotations)
        {
            foreach (var rotation in rotations)
            {
                if (string.IsNullOrEmpty(rotation) || rotation.Length > 2)
                {
                    Console.WriteLine("Rotation command invalid: {0}", rotation);
                    return false;
                }

                if (!new char[] { 'F', 'B', 'U', 'D', 'L', 'R' }.Contains(rotation[0]))
                {
                    Console.WriteLine("Rotation commands should start with 'F', 'B', 'U', 'D', 'L' or 'R'");
                    return false;
                }

                if (rotation.Length == 2 && rotation[1] != '\'')
                {
                    Console.WriteLine("Rotations must be a single character, optionally followed by an ' to signify counterclockwise rotation");
                }
            }

            return true;
        }

        private void ProcessRotations(List<string> rotations)
        {
            foreach(var rotation in rotations)
            {
                bool counterclockwise = false;

                if (rotation.Length == 2)
                {
                    // If we've made it this far we can assume the second character is an ', signifying counterclockwise rotation
                    counterclockwise = true;
                }

                switch (rotation[0])
                {
                    case 'F':
                        RotateFront(counterclockwise);
                        break;
                    case 'B':
                        RotateBack(counterclockwise);
                        break;
                    case 'L':
                        RotateLeft(counterclockwise);
                        break;
                    case 'R':
                        RotateRight(counterclockwise);
                        break;
                    case 'U':
                        RotateUp(counterclockwise);
                        break;
                    case 'D':
                        RotateDown(counterclockwise);
                        break;
                    default:
                        throw new Exception("Command not recognised");
                }
            }
        }

        public void RotateBack(bool counterClockwise = false)
        {
            var currentUp = Cube.Up.GetRow(0);
            var currentDown = Cube.Down.GetRow(2);
            var currentLeft = Cube.Left.GetColumn(0);
            var currentRight = Cube.Right.GetColumn(2);

            if (counterClockwise)
            {
                Cube.Left.SetColumn(0, currentDown);
                Cube.Down.SetRow(2, currentRight.Reverse().ToArray());
                Cube.Right.SetColumn(2, currentUp);
                Cube.Up.SetRow(0, currentLeft.Reverse().ToArray());
            }
            else
            {
                Cube.Right.SetColumn(2, currentDown.Reverse().ToArray());
                Cube.Down.SetRow(2, currentLeft);
                Cube.Left.SetColumn(0, currentUp.Reverse().ToArray());
                Cube.Up.SetRow(0, currentRight);
            }

            Cube.Back.Rotate(counterClockwise);
        }

        public void RotateDown(bool counterClockwise = false)
        {
            var currentFront = Cube.Front.GetRow(2);
            var currentBack = Cube.Back.GetRow(2);
            var currentLeft = Cube.Left.GetRow(2);
            var currentRight = Cube.Right.GetRow(2);

            if (counterClockwise)
            {
                Cube.Left.SetRow(2, currentFront);
                Cube.Back.SetRow(2, currentLeft);
                Cube.Right.SetRow(2, currentBack);
                Cube.Front.SetRow(2, currentRight);
            }
            else
            {
                Cube.Right.SetRow(2, currentFront);
                Cube.Back.SetRow(2, currentRight);
                Cube.Left.SetRow(2, currentBack);
                Cube.Front.SetRow(2, currentLeft);
            }

            Cube.Down.Rotate(counterClockwise);
        }

        public void RotateFront(bool counterClockwise = false)
        {
            var currentUp = Cube.Up.GetRow(2);
            var currentDown = Cube.Down.GetRow(0);
            var currentLeft = Cube.Left.GetColumn(2);
            var currentRight = Cube.Right.GetColumn(0);

            if (counterClockwise)
            {
                Cube.Left.SetColumn(2, currentUp.Reverse().ToArray());
                Cube.Down.SetRow(0, currentLeft);
                Cube.Right.SetColumn(0, currentDown.Reverse().ToArray());
                Cube.Up.SetRow(2, currentRight);
            }
            else
            {
                Cube.Right.SetColumn(0, currentUp);
                Cube.Down.SetRow(0, currentRight.Reverse().ToArray());
                Cube.Left.SetColumn(2, currentDown);
                Cube.Up.SetRow(2, currentLeft.Reverse().ToArray());
            }

            Cube.Front.Rotate(counterClockwise);
        }

        public void RotateLeft(bool counterClockwise = false)
        {
            var currentFront = Cube.Front.GetColumn(0);
            var currentDown = Cube.Down.GetColumn(0);
            var currentBack = Cube.Back.GetColumn(2);
            var currentUp = Cube.Up.GetColumn(0);

            if (counterClockwise)
            {
                Cube.Up.SetColumn(0, currentFront);
                Cube.Back.SetColumn(2, currentUp.Reverse().ToArray());
                Cube.Down.SetColumn(0, currentBack.Reverse().ToArray());
                Cube.Front.SetColumn(0, currentDown);
            }
            else
            {
                Cube.Front.SetColumn(0, currentUp);
                Cube.Down.SetColumn(0, currentFront);
                Cube.Back.SetColumn(2, currentDown.Reverse().ToArray());
                Cube.Up.SetColumn(0, currentBack.Reverse().ToArray());
            }

            Cube.Left.Rotate(counterClockwise);
        }

        public void RotateRight(bool counterClockwise = false)
        {
            var currentFront = Cube.Front.GetColumn(2);
            var currentDown = Cube.Down.GetColumn(2);
            var currentBack = Cube.Back.GetColumn(0);
            var currentUp = Cube.Up.GetColumn(2);

            if (counterClockwise)
            {
                Cube.Up.SetColumn(2, currentBack);
                Cube.Front.SetColumn(2, currentUp);
                Cube.Down.SetColumn(2, currentFront);
                Cube.Back.SetColumn(0, currentDown.Reverse().ToArray());
            }
            else
            {
                Cube.Front.SetColumn(2, currentDown);
                Cube.Up.SetColumn(2, currentFront);
                Cube.Back.SetColumn(0, currentUp.Reverse().ToArray());
                Cube.Down.SetColumn(2, currentBack);
            }

            Cube.Right.Rotate(counterClockwise);
        }

        public void RotateUp(bool counterClockwise = false)
        {
            var currentFront = Cube.Front.GetRow(0);
            var currentBack = Cube.Back.GetRow(0);
            var currentLeft = Cube.Left.GetRow(0);
            var currentRight = Cube.Right.GetRow(0);

            if (counterClockwise)
            {
                Cube.Right.SetRow(0, currentFront);
                Cube.Back.SetRow(0, currentRight);
                Cube.Left.SetRow(0, currentBack);
                Cube.Front.SetRow(0, currentLeft);
            }
            else
            {
                Cube.Left.SetRow(0, currentFront);
                Cube.Back.SetRow(0, currentLeft);
                Cube.Right.SetRow(0, currentBack);
                Cube.Front.SetRow(0, currentRight);
            }

            Cube.Up.Rotate(counterClockwise);
        }

        public Cube Cube {
            get => _cube;
            private set
            {
                _cube = value;
            } 
        }
    }
}
