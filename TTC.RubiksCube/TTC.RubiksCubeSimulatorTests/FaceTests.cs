using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTC.DataObjects;
using Xunit;

namespace TTC.RubiksCubeSimulatorTests
{
    public class FaceTests
    {
        internal void FaceDefaultsSpotColourToWhiteIfNotSet()
        {
            // Act
            Face sut = new Face();

            // Assert
            foreach(Spot spot in sut.Spots)
            {
                spot.Should().NotBeNull();
                spot.Colour.Should().Be(Colour.White);
            }
        }

        [Theory]
        [InlineData(Colour.Red)]
        [InlineData(Colour.Blue)]
        internal void FaceSetsAllSpotsToChosenColour(Colour colour)
        {
            // Act
            Face sut = new Face(colour);

            // Assert
            foreach(Spot spot in sut.Spots)
            {
                spot.Should().NotBeNull();
                spot.Colour.Should().Be(colour);
            }
        }

        [Fact]
        internal void FaceSetsSpotsIfProvidedValid2DArray()
        {
            // Arrange
            Spot[,] spots = new Spot[3, 3] { { new Spot(Colour.White), new Spot(Colour.White), new Spot(Colour.White) },
                                            { new Spot(Colour.Red), new Spot(Colour.Red), new Spot(Colour.Red) },
                                            { new Spot(Colour.Blue), new Spot(Colour.Blue), new Spot(Colour.Blue) } };

            // Act
            Face sut = new Face(spots);

            // Assert
            for (int xIndex = 0; xIndex < 3; xIndex++)
            {
                for (int yIndex = 0; yIndex < 3; yIndex++)
                {
                    switch (xIndex)
                    {
                        case 0:
                            sut.Spots[xIndex, yIndex].Should().NotBeNull();
                            sut.Spots[xIndex, yIndex].Colour.Should().Be(Colour.White);
                            break;
                        case 1:
                            sut.Spots[xIndex, yIndex].Should().NotBeNull();
                            sut.Spots[xIndex, yIndex].Colour.Should().Be(Colour.Red);
                            break;
                        case 2:
                            sut.Spots[xIndex, yIndex].Should().NotBeNull();
                            sut.Spots[xIndex, yIndex].Colour.Should().Be(Colour.Blue);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        [Fact]
        internal void FaceCtorThrowsErrorIfSpotsArrayLengthIsInvalid()
        {
            // Arrange
            Spot[,] spots = new Spot[2, 3] { { new Spot(Colour.White), new Spot(Colour.White), new Spot(Colour.White) },
                                            { new Spot(Colour.Red), new Spot(Colour.Red), new Spot(Colour.Red) } };

            // Act
            Action act = () => new Face(spots);

            ArgumentException expectedException = Assert.Throws<ArgumentException>(act);
            expectedException.Message.Should().Be("Face must be defined as a 3x3 grid");
        }

        [Fact]
        internal void FaceCtorThrowsErrorIfSpotsArrayHasInvalidEntry()
        {
            // Arrange
            // Arrange
            Spot[,] spots = new Spot[3, 3];

            // Act
            Action act = () => new Face(spots);

            ArgumentException expectedException = Assert.Throws<ArgumentException>(act);
            expectedException.Message.Should().Be("A face must have all spots defined");
        }
    }
}
