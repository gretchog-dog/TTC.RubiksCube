using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;
using TTC.RubiksCubeSimulator.Display;
using TTC.RubiksCubeSimulator.Rotate;

namespace TTC.RubiksCubeSimulator.Manipulate
{
    internal class CubeManipulator : ICubeManipulator
    {
        private ICubeRotator _cubeRotator;
        private ICubeLayoutHandler _cubeLayoutHandler;
        private bool _allowDemo;

        public CubeManipulator(
            ICubeRotator cubeRotator,
            ICubeLayoutHandler cubeLayoutHandler)
        {
            Cube cube = new Cube();

            _cubeRotator = cubeRotator;
            _cubeLayoutHandler = cubeLayoutHandler;

            _cubeRotator.Initialise(cube);
            _cubeLayoutHandler.SetLayout(cube);

            _allowDemo = true;
        }

        public void ActOnUserInput(int input)
        {
            switch (input)
            {
                case 1:
                    ShowCubeLayout();
                    break;
                case 2:
                    RandomiseCube();
                    break;
                case 3:
                    RunDemonstration();
                    break;
                default:
                    throw new Exception("unexpected input");
            }
        }

        public void Greet()
        {
            var cube = new Cube();
            _cubeLayoutHandler.SetLayout(cube);

            Console.WriteLine("Hello! Welcome to the Rubik's Cube puzzle generator.");
            Console.WriteLine("This application will allow you to create a Rubik's Cube puzzle from a default cube state, using either a demonstration or a random end state.");
            DisplayOptions();
        }

        private void DisplayOptions()
        {
            Console.WriteLine("Please select from the options below:");
            Console.WriteLine("1. Show current cube layout");
            Console.WriteLine("2. Randomise cube from its current state");
            if (_allowDemo)
            {
                Console.WriteLine("3. Run the demonstration");
            }
            ReadInput();
        }

        private void ReadInput()
        {
            ValidateInput(Console.ReadLine());
        }

        private void ValidateInput(string input)
        {
            string feedback = "either 1 or 2";
            if (_allowDemo)
            {
                feedback = "1, 2 or 3";
            }

            int parsedInput;
            bool success = int.TryParse(input, out parsedInput);

            int[] allowedValues = new int[] { 1, 2 };
            if (_allowDemo) 
                allowedValues = allowedValues.Append(3).ToArray();

            if (!success || !allowedValues.Contains(parsedInput))
            {
                Console.WriteLine("Please type {0}", feedback);
                ReadInput();
            }

            ActOnUserInput(parsedInput);
            DisplayOptions();
        }

        private void ShowCubeLayout()
        {
            _cubeLayoutHandler.WriteLayoutToConsole();
        }

        private void RandomiseCube()
        {
            var randomiser = Random.Shared;
            char[] commands = new char[6] { 'F', 'R', 'U', 'B', 'L', 'D' };

            List<string> rotations = new List<string>();

            int iterations = randomiser.Next(5, 15);

            for (int i = 0; i < iterations; i++)
            {
                char command = commands[randomiser.Next(0, 5)];
                bool counterclockwise = randomiser.NextDouble() >= 0.5;

                string rotation = commands[randomiser.Next(0, 5)].ToString();
                if (counterclockwise)
                    rotation = rotation + "'";

                rotations.Add(rotation);
            }

            _cubeRotator.ApplyRotations(rotations);
            _cubeLayoutHandler.SetLayout(_cubeRotator.Cube);
            _cubeLayoutHandler.WriteLayoutToConsole();

            _allowDemo = false;
        }

        private void RunDemonstration()
        {
            List<string> rotations = new List<string>()
            {
                "F",
                "R'",
                "U",
                "B'",
                "L",
                "D'"
            };

            _cubeRotator.ApplyRotations(rotations);
            _cubeLayoutHandler.SetLayout(_cubeRotator.Cube);
            _cubeLayoutHandler.WriteLayoutToConsole();

            _allowDemo = false;
        }
    }
}
