using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;

namespace TTC.RubiksCubeSimulator.Extensions
{
    internal static class FaceExtensions
    {
        public static Colour[] GetRow(this Face face, int index)
        {
            if (index < 0 || index > 2)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return Enumerable.Range(0, 3)
                .Select(x => face.Spots[index, x].Colour)
                .ToArray();
        }

        public static Colour[] GetColumn(this Face face, int index)
        {
            if (index < 0 || index > 2)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return Enumerable.Range(0, 3)
                .Select(x => face.Spots[x, index].Colour)
                .ToArray();
        }

        public static void SetRow(this Face face, int index, Colour[] newColours)
        {
            if (index < 0 || index > 2)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (newColours.Length != 3)
            {
                throw new ArgumentException("New colours could not be set");
            }

            face.Spots[index, 0].Colour = newColours[0];
            face.Spots[index, 1].Colour = newColours[1];
            face.Spots[index, 2].Colour = newColours[2];
        }

        public static void SetColumn(this Face face, int index, Colour[] newColours)
        {
            if (index < 0 || index > 2)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (newColours.Length != 3)
            {
                throw new ArgumentException("New colours could not be set");
            }

            face.Spots[0, index].Colour = newColours[0];
            face.Spots[1, index].Colour = newColours[1];
            face.Spots[2, index].Colour = newColours[2];
        }

        public static void Rotate(this Face face, bool counterClockwise)
        {
            var topRow =  Enumerable.Range(0, 3)
                .Select(x => face.Spots[0, x].Colour)
                .ToArray();

            var midRow = Enumerable.Range(0, 3)
                .Select(x => face.Spots[1, x].Colour)
                .ToArray();

            var botRow = Enumerable.Range(0, 3)
                .Select(x => face.Spots[2, x].Colour)
                .ToArray();

            if (counterClockwise)
            {
                face.SetColumn(0, topRow.Reverse().ToArray());
                face.SetColumn(1, midRow.Reverse().ToArray());
                face.SetColumn(2, botRow.Reverse().ToArray());
            }
            else
            {
                face.SetColumn(0, botRow);
                face.SetColumn(1, midRow);
                face.SetColumn(2, topRow);
            }
        }
    }
}
