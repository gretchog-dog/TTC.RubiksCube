using System.Text;
using TTC.DataObjects;

namespace TTC.RubiksCubeSimulator
{
    internal class ConsoleOutputHelper
    {
        private static StringBuilder sb = new StringBuilder();

        public static string CreateLayoutString(Cube cube)
        {
            OutputUpFace(cube.Up);
            OutputCenterFaces(cube.Left, cube.Front, cube.Right, cube.Back);
            OutputDownFace(cube.Down);
            sb.AppendLine();

            return sb.ToString();
        }

        private static void OutputUpFace(Face up)
        {
            OutputBlankLine();
            OutputLine(GetRow(up, 0));
            OutputBlankLine();
            OutputBlankLine();
            sb.AppendLine();
            OutputBlankLine();
            OutputLine(GetRow(up, 1));
            OutputBlankLine();
            OutputBlankLine();
            sb.AppendLine();
            OutputBlankLine();
            OutputLine(GetRow(up, 2));
            OutputBlankLine();
            OutputBlankLine();
            sb.AppendLine();
        }

        private static void OutputCenterFaces(Face left, Face front, Face right, Face back)
        {
            OutputLine(GetRow(left, 0));
            OutputLine(GetRow(front, 0));
            OutputLine(GetRow(right, 0));
            OutputLine(GetRow(back, 0));
            sb.AppendLine();
            OutputLine(GetRow(left, 1));
            OutputLine(GetRow(front, 1));
            OutputLine(GetRow(right, 1));
            OutputLine(GetRow(back, 1));
            sb.AppendLine();
            OutputLine(GetRow(left, 2));
            OutputLine(GetRow(front, 2));
            OutputLine(GetRow(right, 2));
            OutputLine(GetRow(back, 2));
            sb.AppendLine();
        }

        private static void OutputDownFace(Face down)
        {
            OutputBlankLine();
            OutputLine(GetRow(down, 0));
            OutputBlankLine();
            OutputBlankLine();
            sb.AppendLine();
            OutputBlankLine();
            OutputLine(GetRow(down, 1));
            OutputBlankLine();
            OutputBlankLine();
            sb.AppendLine();
            OutputBlankLine();
            OutputLine(GetRow(down, 2));
            OutputBlankLine();
            OutputBlankLine();
            sb.AppendLine();
        }

        private static void OutputLine(Spot[] line)
        {
            sb.Append(TranslateColour(line[0].Colour) + " ");
            sb.Append(TranslateColour(line[1].Colour) + " ");
            sb.Append(TranslateColour(line[2].Colour) + " ");
        }

        private static void OutputBlankLine()
        {
            sb.Append("      ");
        }

        private static string TranslateColour(Colour colour)
        {
            switch(colour)
            {
                case Colour.White:
                    return "W";
                case Colour.Orange:
                    return "O";
                case Colour.Red:
                    return "R";
                case Colour.Green:
                    return "G";
                case Colour.Yellow:
                    return "Y";
                case Colour.Blue:
                    return "B";
                default:
                    throw new ArgumentOutOfRangeException("Colour not recognised");
            }
        }

        private static Spot[] GetRow(Face face, int index)
        {
            return Enumerable.Range(0, 3)
                .Select(x => face.Spots[index, x])
                .ToArray();
        }
    }
}
