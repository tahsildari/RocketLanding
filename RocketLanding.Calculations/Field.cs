using RocketLanding.Calculations.Responses;
using System;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public class Field
    {
        public int HorizontalCells { get; }
        public int VerticalCells { get; }
        public IPlatform Platform { get; }

        public Field(int x, int y, IPlatform platform)
        {
            HorizontalCells = x;
            VerticalCells = y;
            Platform = platform;
        }

        public LandingStatus QueryRocketLanding(Point rocket)
        {
            if (rocket.X > this.HorizontalCells || rocket.X < 0 ||
                rocket.Y > this.VerticalCells || rocket.Y < 0)
            {
                throw new ArgumentOutOfRangeException("Rocket is out of field!");
            }

            return 
        }
    }
}
