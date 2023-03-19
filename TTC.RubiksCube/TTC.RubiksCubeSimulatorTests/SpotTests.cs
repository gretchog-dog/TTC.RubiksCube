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
    public class SpotTests
    {
        [Fact]
        internal void SpotColourDefaultsToWhiteIfNotSet()
        {
            // Act
            Spot sut = new Spot();

            // Assert
            sut.Colour.Should().Be(Colour.White);
        }

        [Theory]
        [InlineData(Colour.Blue)]
        [InlineData(Colour.Yellow)]
        internal void SpotColourCanBeSet(Colour expectedColour)
        {
            // Act
            Spot sut = new Spot(expectedColour);

            // Assert
            sut.Colour.Should().Be(expectedColour);
        }
    }
}
