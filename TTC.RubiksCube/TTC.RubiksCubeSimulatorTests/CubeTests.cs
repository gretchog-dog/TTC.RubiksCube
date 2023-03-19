using FluentAssertions;
using TTC.DataObjects;
using Xunit;

namespace TTC.RubiksCubeSimulatorTests
{
    public class CubeTests
    {
        [Fact]
        internal void CubeConstructorDefaultsFacesIfCubeNotSet()
        {
            // Act
            Cube sut = new Cube();

            // Assert
            foreach(Spot spot in sut.Up.Spots)
            {
                spot.Colour.Should().Be(Colour.White);
            }
            foreach(Spot spot in sut.Left.Spots)
            {
                spot.Colour.Should().Be(Colour.Orange);
            }
            foreach(Spot spot in sut.Back.Spots)
            {
                spot.Colour.Should().Be(Colour.Blue);
            }
            foreach(Spot spot in sut.Front.Spots)
            {
                spot.Colour.Should().Be(Colour.Green);
            }
            foreach(Spot spot in sut.Right.Spots)
            {
                spot.Colour.Should().Be(Colour.Red);
            }
            foreach(Spot spot in sut.Down.Spots)
            {
                spot.Colour.Should().Be(Colour.Yellow);
            }
        }
    }
}
