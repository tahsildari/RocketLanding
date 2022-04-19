using RocketLanding.Calculations.Responses;
using System.Drawing;

namespace RocketLanding.Calculations
{
    public interface IPlatform
    {
        IPlatform Configure(Point start, int x, int y);
        public LandingStatus QueryRocketLanding(Point rocket);
    }
}
