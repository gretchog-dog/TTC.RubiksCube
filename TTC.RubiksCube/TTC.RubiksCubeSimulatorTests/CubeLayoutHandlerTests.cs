using FluentAssertions;
using TTC.DataObjects;
using TTC.RubiksCubeSimulator;
using TTC.RubiksCubeSimulator.Display;
using Xunit;

namespace TTC.RubiksCubeSimulatorTests
{
    public class CubeLayoutHandlerTests
    {
        [Fact]
        internal void CubeLayoutHandlerDefaultsCube()
        {
            // Arrange
            Cube expected = new Cube();
            CubeLayoutHandler sut = new CubeLayoutHandler();

            // Act
            Cube actual = sut.Cube;

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        internal void CubeLayoutHandlerAllowsCubeToBeSet()
        {
            // Arrange
            Cube expected = new Cube();
            expected.Up = new Face(Colour.Green);
            expected.Front = new Face(Colour.White);
            CubeLayoutHandler sut = new CubeLayoutHandler();

            // Act
            sut.SetLayout(expected);
            Cube actual = sut.Cube;

            // Assert
            actual.Should().BeEquivalentTo(expected);
            actual.Up.Should().BeEquivalentTo(expected.Up);
            actual.Right.Should().BeEquivalentTo(expected.Right);
            actual.Front.Should().BeEquivalentTo(expected.Front);
        }

        [Fact]
        internal void CubeLayoutHandlerOutputsExpectedCubeLayout()
        {
            // Arrange
            CubeLayoutHandler sut = new CubeLayoutHandler();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                sut.WriteLayoutToConsole();

                // Assert
                var actual = ConsoleOutputHelper.CreateLayoutString(sut.Cube);

                sw.Flush();
            }

            Console.SetOut(new StreamWriter(Console.OpenStandardError()));
        }
    }
}
