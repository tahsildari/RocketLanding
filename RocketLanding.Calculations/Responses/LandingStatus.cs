using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLanding.Calculations.Responses
{
    public enum LandingStatus
    {
        /// <summary>
        /// Ok for Landing
        /// </summary>
        Ok,
        /// <summary>
        /// Block is out of Platform
        /// </summary>
        OutOfPlatform,
        /// <summary>
        /// Clash with another rocket (either same block or adjacent blocks)
        /// </summary>
        Clash
    }
}
