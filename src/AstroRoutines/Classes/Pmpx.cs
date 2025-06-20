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
        /// Proper motion and parallax.
        /// </summary>
        /// <param name="rc">ICRS RA,Dec at catalog epoch (radians)</param>
        /// <param name="dc">ICRS RA,Dec at catalog epoch (radians)</param>
        /// <param name="pr">RA proper motion (radians/year, Note 1)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="pmt">proper motion time interval (SSB, Julian years)</param>
        /// <param name="pob">SSB to observer vector (au)</param>
        /// <param name="pco">coordinate direction (BCRS unit vector)</param>
        public static void Pmpx(double rc, double dc, double pr, double pd,
                                double px, double rv, double pmt, double[] pob,
                                ref double[] pco)
        {
            /* Km/s to au/year */
            const double VF = DAYSEC * DJM / DAU;

            /* Light time for 1 au, Julian years */
            const double AULTY = AULT / DAYSEC / DJY;

            double x, y, z;
            var p = new double[3];
            var pm = new double[3];

            /* Spherical coordinates to unit vector (and useful functions). */
            var sr = Sin(rc);
            var cr = Cos(rc);
            var sd = Sin(dc);
            var cd = Cos(dc);
            p[0] = x = cr * cd;
            p[1] = y = sr * cd;
            p[2] = z = sd;

            /* Proper motion time interval (y) including Roemer effect. */
            var dt = pmt + Pdp(p, pob) * AULTY;

            /* Space motion (radians per year). */
            var pxr = px * DAS2R;
            var w = VF * rv * pxr;
            var pdz = pd * z;
            pm[0] = -pr * y - pdz * cr + w * x;
            pm[1] = pr * x - pdz * sr + w * y;
            pm[2] = pd * cd + w * z;

            /* Coordinate direction of star (unit vector, BCRS). */
            for (var i = 0; i < 3; i++)
            {
                p[i] += dt * pm[i] - pxr * pob[i];
            }
            Pn(p, out w, out pco);
        }
    }
}
