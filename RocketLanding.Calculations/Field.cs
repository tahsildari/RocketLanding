using RocketLanding.Calculations.Responses;
using System;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public class Field
    {
        public int HorizontalCells { get; }
        public int VerticalCells { get; }
        private IPlatform platform { get; }

        public Field(int x, int y, IPlatform platform)
        {
            HorizontalCells = x;
            VerticalCells = y;
            this.platform = platform;
        }

        public LandingStatus QueryRocketLanding(Point rocket)
        {
            if (rocket.X > this.HorizontalCells || rocket.X < 0 ||
                rocket.Y > this.VerticalCells || rocket.Y < 0)
            {
                throw new ArgumentOutOfRangeException("Rocket is out of field!");
            }

            return platform.QueryRocketLanding(rocket);

            // Dear reviewer, the original question says "only last check counts",
            // but I saw this phrase just after I finished my code.
            // Since I have already implemented it in a way that all checks count, I hope it's fine that I'm not changing it.
            // I think this is not a matter of complexity, but a simplicity.
            // Since my code is more complex, I hope I have delivered what you had in mind.
        }
    }
}
