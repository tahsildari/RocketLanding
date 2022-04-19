using RocketLanding.Calculations.Responses;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public interface IPlatform
    {
        void Configure(Point start, int x, int y);
        public LandingStatus QueryRocketLanding(Point rocket);
    }
}
