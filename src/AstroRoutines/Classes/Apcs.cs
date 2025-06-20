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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For an observer whose geocentric position and velocity are known, prepare star-independent astrometry parameters for transformations between ICRS and GCRS.
        /// </summary>
        /// <param name="date1">TDB as a 2-part...</param>
        /// <param name="date2">...Julian Date (Note 1)</param>
        /// <param name="pv">observer's geocentric pos/vel (m, m/s)</param>
        /// <param name="ebpv">Earth barycentric PV (au, au/day)</param>
        /// <param name="ehp">Earth heliocentric P (au)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apcs(double date1, double date2, double[,] pv,
                               double[,] ebpv, double[] ehp, ref ASTROM astrom)
        {
            /* au/d to m/s */
            const double AUDMS = DAU / DAYSEC;

            /* Light time for 1 au (day) */
            const double CR = AULT / DAYSEC;

            int i;
            double dp, dv, w;
            var pb = new double[3];
            var vb = new double[3];
            var ph = new double[3];

            /* Time since reference epoch, years (for proper motion calculation). */
            astrom.pmt = ((date1 - DJ00) + date2) / DJY;

            /* Adjust Earth ephemeris to observer. */
            for (i = 0; i < 3; i++)
            {
                dp = pv[0, i] / DAU;
                dv = pv[1, i] / AUDMS;
                pb[i] = ebpv[0, i] + dp;
                vb[i] = ebpv[1, i] + dv;
                ph[i] = ehp[i] + dp;
            }

            /* Barycentric position of observer (au). */
            Cp(pb, ref astrom.eb);

            /* Heliocentric direction and distance (unit vector and au). */
            Pn(ph, out astrom.em,out astrom.eh);

            /* Barycentric vel. in units of c, and reciprocal of Lorenz factor. */
            var v2 = 0.0;
            for (i = 0; i < 3; i++)
            {
                w = vb[i] * CR;
                astrom.v[i] = w;
                v2 += w * w;
            }
            astrom.bm1 = Sqrt(1.0 - v2);

            /* Reset the NPB matrix. */
            Ir(ref astrom.bpn);

            /* Finished. */
        }
    }
}
