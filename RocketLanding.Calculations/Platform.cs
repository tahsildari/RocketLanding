using RocketLanding.Calculations.Responses;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public class Platform : IPlatform
    {
        public int HorizontalCells { get; private set; } = 10;
        public int VerticalCells { get; private set; } = 10;
        public Point Start { get; private set; } = new Point(5, 5);

        /// <summary>
        /// List of cells in which rockets have already landed
        /// </summary>
        public HashSet<Point> Landings { get; private set; } = new HashSet<Point>();

        public IPlatform Configure(Point start, int x, int y)
        {
            HorizontalCells = x;
            VerticalCells = y;
            Start = start;
            return this;
        }

        public LandingStatus QueryRocketLanding(Point rocket)
        {
            if (IsOutOfPlatform(rocket))
                return LandingStatus.OutOfPlatform;

            if (CellIsAlreadyOccupiedOrAdjacent(rocket))
                return LandingStatus.Clash;

            // I assume rocket lands after successful query for the sake of test simplicity
            Land(rocket);
            return LandingStatus.Ok;
        }

        /// <summary>
        /// Check if rocket is clashing with another rocket
        /// </summary>
        /// <param name="rocket">position of rocket</param>
        /// <returns>True : Clash | False : Ok</returns>
        private bool CellIsAlreadyOccupiedOrAdjacent(Point rocket)
        {
            if (Landings.Count == 0)
                return false;

            // The code below can potentially check -1,-1 in case of 0,0 rocket.
            // I could have ignored the cells which are out of bounds,
            // but I am not checking it twice because of two reasons:
            // 1. IsOutOfPlatform() already checks it
            // 2. There isn't much performance difference between this check and checking the list.Contains

            for (int i = rocket.X - 1; i <= rocket.X + 1; i++)
            {
                for (int j = rocket.Y - 1; j <= rocket.Y + 1; j++)
                {
                    if (Landings.Contains(new Point(i, j)))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if rocket is out of platform
        /// </summary>
        /// <param name="rocket">position of rocket</param>
        /// <returns>True : Out | False : In</returns>
        private bool IsOutOfPlatform(Point rocket) =>
            rocket.X < Start.X ||
            rocket.X > Start.X + HorizontalCells -1 ||
            rocket.Y < Start.Y ||
            rocket.Y > Start.Y + VerticalCells -1;

        /// <summary>
        /// Sets the block as landed (occupied)
        /// </summary>
        /// <param name="rocket">position of rocket</param>
        public void Land(Point rocket)
        {
            Landings.Add(rocket);
        }


    }
}
