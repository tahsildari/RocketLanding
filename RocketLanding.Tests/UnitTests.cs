using RocketLanding.Calculations;
using RocketLanding.Calculations.Responses;
using System;
using System.Drawing;
using Xunit;

namespace RocketLanding.Tests
{
    public class UnitTests
    {
        IPlatform platform = new Platform();
        Field field;

        [Fact]
        public void Platform_WhenNotConfigured_IsDefaultedTo10By10Cells() {
            //Arrange
            field = new Field(100, 100, platform);

            //Act
            var result1 = field.QueryRocketLanding(new Point(5, 5));
            var result2 = field.QueryRocketLanding(new Point(14, 14));
            var result3 = field.QueryRocketLanding(new Point(15, 15));

            //Assert
            Assert.True(result1 == LandingStatus.Ok);
            Assert.True(result2 == LandingStatus.Ok);
            Assert.True(result3 == LandingStatus.OutOfPlatform);
        }

        [Fact]
        public void Query_WhenRocketOutOfField_ThrowsException()
        {
            //Arrange
            field = new Field(100, 100, platform);

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => field.QueryRocketLanding(new Point(105, 10)));
            Assert.Throws<ArgumentOutOfRangeException>(() => field.QueryRocketLanding(new Point(-1, -1)));
        }

        [Fact]
        public void Query_WhenRocketInsidePlatform_ReturnsOk()
        {
            //Arrange
            field = new Field(100, 100, platform);

            //Act
            var result1 = field.QueryRocketLanding(new Point(8, 8));

            //Assert
            Assert.True(result1 == LandingStatus.Ok);
        }

        [Fact]
        public void Query_WhenMultipleRocketsInsidePlatform_ReturnsOk()
        {
            //Arrange
            field = new Field(100, 100, platform);

            //Act
            var result1 = field.QueryRocketLanding(new Point(8, 8));
            var result2 = field.QueryRocketLanding(new Point(13, 10));

            //Assert
            Assert.True(result1 == LandingStatus.Ok);
            Assert.True(result2 == LandingStatus.Ok);
        }

        [Fact]
        public void Query_WhenBlockAlreadyOccupied_ReturnsClash()
        {
            //Arrange
            field = new Field(100, 100, platform);

            //Act
            var result1 = field.QueryRocketLanding(new Point(8, 8));
            var result2 = field.QueryRocketLanding(new Point(8, 8));

            //Assert
            Assert.True(result1 == LandingStatus.Ok);
            Assert.True(result2 == LandingStatus.Clash);
        }

        [Fact]
        public void Query_WhenAdjacentBlockAlreadyOccupied_ReturnsClash()
        {
            //Arrange
            field = new Field(100, 100, platform);

            //Act
            var result1 = field.QueryRocketLanding(new Point(8, 8));
            var result2 = field.QueryRocketLanding(new Point(9, 8));

            //Assert
            Assert.True(result1 == LandingStatus.Ok);
            Assert.True(result2 == LandingStatus.Clash);
        }

        [Fact]
        public void Query_WhenPlatformIsCustomized_Works()
        {
            //Arrange
            platform.Configure(new Point(50, 50), 5, 5);
            field = new Field(100, 100, platform);

            //Act
            var result1 = field.QueryRocketLanding(new Point(50, 50));
            var result2 = field.QueryRocketLanding(new Point(53, 53));
            var result3 = field.QueryRocketLanding(new Point(52, 52));
            var result4 = field.QueryRocketLanding(new Point(5, 5));

            //Assert
            Assert.True(result1 == LandingStatus.Ok);
            Assert.True(result2 == LandingStatus.Ok);
            Assert.True(result3 == LandingStatus.Clash);
            Assert.True(result4 == LandingStatus.OutOfPlatform);
        }

    }
}
