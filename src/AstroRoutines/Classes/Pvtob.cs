using static System.Math;
using static AstroRoutines.Constants;

//
// Copyright 2025 Alex Man (Starsbane)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Software Routines from the IAU SOFA Collection were used. 
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Position and velocity of a terrestrial observing station.
        /// </summary>
        /// <param name="elong">Longitude (radians, east +ve)</param>
        /// <param name="phi">Latitude (geodetic, radians)</param>
        /// <param name="hm">Height above ref. ellipsoid (geodetic, m)</param>
        /// <param name="xp">Pole coordinates x (radians)</param>
        /// <param name="yp">Pole coordinates y (radians)</param>
        /// <param name="sp">TIO locator s' (radians)</param>
        /// <param name="theta">Earth rotation angle (radians)</param>
        /// <param name="pv">Position/velocity vector (m, m/s, CIRS)</param>
        public static void Pvtob(double elong, double phi, double hm,
                                 double xp, double yp, double sp, double theta,
                                 ref double[,] pv)
        {
            // Earth rotation rate in radians per UT1 second
            const double OM = 1.00273781191135448 * D2PI / DAYSEC;

            var rpm = new double[3,3];
            var xyz = new double[3];

            // Geodetic to geocentric transformation (WGS84)
            Gd2gc(1, elong, phi, hm, out var xyzm);

            // Polar motion and TIO position
            Pom00(xp, yp, sp, ref rpm);
            Trxp(rpm, xyzm, ref xyz);
            var x = xyz[0];
            var y = xyz[1];
            var z = xyz[2];

            // Functions of ERA
            var s = Sin(theta);
            var c = Cos(theta);

            // Position
            pv[0, 0] = c * x - s * y;
            pv[0, 1] = s * x + c * y;
            pv[0, 2] = z;

            // Velocity
            pv[1, 0] = OM * (-s * x - c * y);
            pv[1, 1] = OM * (c * x - s * y);
            pv[1, 2] = 0.0;
        }
    }
}
