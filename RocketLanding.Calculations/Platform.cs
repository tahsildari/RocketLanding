using RocketLanding.Calculations.Responses;
using System.Collections.Generic;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public class Platform : IPlatform
    {
        public int HorizontalCells { get; private set; } = 10;
        public int VerticalCells { get; private set; } = 10;
        public Point Start { get; private set; } = new Point(0, 0);
        public HashSet<Point> Landings { get; private set; }

        public IPlatform Configure(Point start, int x, int y)
        {
            HorizontalCells = x;
            VerticalCells = y;
            Start = start;
            Landings = new HashSet<Point>();
            return this;
        }

        public LandingStatus QueryRocketLanding(Point rocket)
        {
            // check if rocket is out of platform
            if (rocket.X < Start.X ||
                rocket.X > Start.X + HorizontalCells ||
                rocket.Y < Start.Y ||
                rocket.Y > Start.Y + VerticalCells)
            {
                return LandingStatus.OutOfPlatform;
            }

            // check if rocket is clashing with another rocket
            if (Landings.Count > 0)
                for (int i = rocket.X - 1; i <= rocket.X + 1; i++)
                {
                    for (int j = rocket.Y - 1; j <= rocket.Y + 1; j++)
                    {
                        if (Landings.Contains(new Point(i, j)))
                            return LandingStatus.Clash;
                    }
                }

            Land(rocket);
            return LandingStatus.Ok;
        }

        public void Land(Point rocket)
        {
            Landings.Add(rocket);
        }


    }
}
