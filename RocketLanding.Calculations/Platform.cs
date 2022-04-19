using RocketLanding.Calculations.Responses;
using System.Collections.Generic;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public class Platform : IPlatform
    {
        public int HorizontalCells { get; private set; }
        public int VerticalCells { get; private set; }
        public Point Start { get; private set; }
        public HashSet<Point> Landings { get; private set; }

        public void Configure(Point start, int x, int y)
        {
            HorizontalCells = x;
            VerticalCells = y;
            Start = start;
            Landings = new HashSet<Point>();
        }

        public LandingStatus QueryRocketLanding(Point rocket)
        {
            // check if rocket is out of platform
            if (rocket.X < Start.X &&
                rocket.X > Start.X + HorizontalCells &&
                rocket.Y < Start.Y &&
                rocket.Y > Start.Y + VerticalCells)
            {
                return LandingStatus.OutOfPlatform;
            }

            // check if rocket is clashing with another rocket
            for (int i = rocket.X-1; i <= rocket.X + 1; i++)
            {
                for (int j = rocket.Y - 1; j <= rocket.Y + 1; j++)
                {
                    if (Landings.Contains(new Point(i, j)))
                        return LandingStatus.Clash;
                }
            }

            return LandingStatus.OutOfPlatform;
        }

        public void Land(Point rocket) {
            Landings.Add(rocket);
        }
    }
}
