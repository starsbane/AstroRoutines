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
		/// Nutation, IAU 1980 model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="dpsi">nutation in longitude (radians)</param>
		/// <param name="deps">nutation in obliquity (radians)</param>
        public static void Nut80(double date1, double date2, out double dpsi, out double deps)
        {
            double arg, s, c;
            int j;

            /* Units of 0.1 milliarcsecond to radians */
            const double U2R = DAS2R / 1e4;

            /* ------------------------------------------------ */
            /* Table of multiples of arguments and coefficients */
            /* ------------------------------------------------ */

            /* The units for the sine and cosine coefficients are 0.1 mas and */
            /* the same per Julian century */

            var x = new[]
            {
                /* 1-10 */
                new { nl = 0, nlp = 0, nf = 0, nd = 0, nom = 1, sp = -171996.0, spt = -174.2, ce = 92025.0, cet = 8.9 },
                new { nl = 0, nlp = 0, nf = 0, nd = 0, nom = 2, sp = 2062.0, spt = 0.2, ce = -895.0, cet = 0.5 },
                new { nl = -2, nlp = 0, nf = 2, nd = 0, nom = 1, sp = 46.0, spt = 0.0, ce = -24.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = -2, nd = 0, nom = 0, sp = 11.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = -2, nlp = 0, nf = 2, nd = 0, nom = 2, sp = -3.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 1, nlp = -1, nf = 0, nd = -1, nom = 0, sp = -3.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = -2, nf = 2, nd = -2, nom = 1, sp = -2.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = -2, nd = 0, nom = 1, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = -2, nom = 2, sp = -13187.0, spt = -1.6, ce = 5736.0, cet = -3.1 },
                new { nl = 0, nlp = 1, nf = 0, nd = 0, nom = 0, sp = 1426.0, spt = -3.4, ce = 54.0, cet = -0.1 },

                /* 11-20 */
                new { nl = 0, nlp = 1, nf = 2, nd = -2, nom = 2, sp = -517.0, spt = 1.2, ce = 224.0, cet = -0.6 },
                new { nl = 0, nlp = -1, nf = 2, nd = -2, nom = 2, sp = 217.0, spt = -0.5, ce = -95.0, cet = 0.3 },
                new { nl = 0, nlp = 0, nf = 2, nd = -2, nom = 1, sp = 129.0, spt = 0.1, ce = -70.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 0, nd = -2, nom = 0, sp = 48.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = -2, nom = 0, sp = -22.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 2, nf = 0, nd = 0, nom = 0, sp = 17.0, spt = -0.1, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 0, nd = 0, nom = 1, sp = -15.0, spt = 0.0, ce = 9.0, cet = 0.0 },
                new { nl = 0, nlp = 2, nf = 2, nd = -2, nom = 2, sp = -16.0, spt = 0.1, ce = 7.0, cet = 0.0 },
                new { nl = 0, nlp = -1, nf = 0, nd = 0, nom = 1, sp = -12.0, spt = 0.0, ce = 6.0, cet = 0.0 },
                new { nl = -2, nlp = 0, nf = 0, nd = 2, nom = 1, sp = -6.0, spt = 0.0, ce = 3.0, cet = 0.0 },

                /* 21-30 */
                new { nl = 0, nlp = -1, nf = 2, nd = -2, nom = 1, sp = -5.0, spt = 0.0, ce = 3.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 0, nd = -2, nom = 1, sp = 4.0, spt = 0.0, ce = -2.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 2, nd = -2, nom = 1, sp = 4.0, spt = 0.0, ce = -2.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 0, nd = -1, nom = 0, sp = -4.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 2, nlp = 1, nf = 0, nd = -2, nom = 0, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = -2, nd = 2, nom = 1, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = -2, nd = 2, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 0, nd = 0, nom = 2, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 0, nd = 1, nom = 1, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 2, nd = -2, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },

                /* 31-40 */
                new { nl = 0, nlp = 0, nf = 2, nd = 0, nom = 2, sp = -2274.0, spt = -0.2, ce = 977.0, cet = -0.5 },
                new { nl = 1, nlp = 0, nf = 0, nd = 0, nom = 0, sp = 712.0, spt = 0.1, ce = -7.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = 0, nom = 1, sp = -386.0, spt = -0.4, ce = 200.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = 0, nom = 2, sp = -301.0, spt = 0.0, ce = 129.0, cet = -0.1 },
                new { nl = 1, nlp = 0, nf = 0, nd = -2, nom = 0, sp = -158.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 2, nd = 0, nom = 2, sp = 123.0, spt = 0.0, ce = -53.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 0, nd = 2, nom = 0, sp = 63.0, spt = 0.0, ce = -2.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 0, nd = 0, nom = 1, sp = 63.0, spt = 0.1, ce = -33.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 0, nd = 0, nom = 1, sp = -58.0, spt = -0.1, ce = 32.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 2, nd = 2, nom = 2, sp = -59.0, spt = 0.0, ce = 26.0, cet = 0.0 },

                /* 41-50 */
                new { nl = 1, nlp = 0, nf = 2, nd = 0, nom = 1, sp = -51.0, spt = 0.0, ce = 27.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = 2, nom = 2, sp = -38.0, spt = 0.0, ce = 16.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 0, nd = 0, nom = 0, sp = 29.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = -2, nom = 2, sp = 29.0, spt = 0.0, ce = -12.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 2, nd = 0, nom = 2, sp = -31.0, spt = 0.0, ce = 13.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = 0, nom = 0, sp = 26.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 2, nd = 0, nom = 1, sp = 21.0, spt = 0.0, ce = -10.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 0, nd = 2, nom = 1, sp = 16.0, spt = 0.0, ce = -8.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 0, nd = -2, nom = 1, sp = -13.0, spt = 0.0, ce = 7.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 2, nd = 2, nom = 1, sp = -10.0, spt = 0.0, ce = 5.0, cet = 0.0 },

                /* 51-60 */
                new { nl = 1, nlp = 1, nf = 0, nd = -2, nom = 0, sp = -7.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 2, nd = 0, nom = 2, sp = 7.0, spt = 0.0, ce = -3.0, cet = 0.0 },
                new { nl = 0, nlp = -1, nf = 2, nd = 0, nom = 2, sp = -7.0, spt = 0.0, ce = 3.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = 2, nom = 2, sp = -8.0, spt = 0.0, ce = 3.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 0, nd = 2, nom = 0, sp = 6.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 2, nd = -2, nom = 2, sp = 6.0, spt = 0.0, ce = -3.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 0, nd = 2, nom = 1, sp = -6.0, spt = 0.0, ce = 3.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = 2, nom = 1, sp = -7.0, spt = 0.0, ce = 3.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = -2, nom = 1, sp = 6.0, spt = 0.0, ce = -3.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 0, nd = -2, nom = 1, sp = -5.0, spt = 0.0, ce = 3.0, cet = 0.0 },

                /* 61-70 */
                new { nl = 1, nlp = -1, nf = 0, nd = 0, nom = 0, sp = 5.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 2, nd = 0, nom = 1, sp = -5.0, spt = 0.0, ce = 3.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 0, nd = -2, nom = 0, sp = -4.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = -2, nd = 0, nom = 0, sp = 4.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 0, nd = 1, nom = 0, sp = -4.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 1, nf = 0, nd = 0, nom = 0, sp = -3.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = 0, nom = 0, sp = 3.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = -1, nf = 2, nd = 0, nom = 2, sp = -3.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = -1, nlp = -1, nf = 2, nd = 2, nom = 2, sp = -3.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = -2, nlp = 0, nf = 0, nd = 0, nom = 1, sp = -2.0, spt = 0.0, ce = 1.0, cet = 0.0 },

                /* 71-80 */
                new { nl = 3, nlp = 0, nf = 2, nd = 0, nom = 2, sp = -3.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 0, nlp = -1, nf = 2, nd = 2, nom = 2, sp = -3.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 1, nlp = 1, nf = 2, nd = 0, nom = 2, sp = 2.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 2, nd = -2, nom = 1, sp = -2.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 0, nd = 0, nom = 1, sp = 2.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 0, nd = 0, nom = 2, sp = -2.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 3, nlp = 0, nf = 0, nd = 0, nom = 0, sp = 2.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = 1, nom = 2, sp = 2.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 0, nd = 0, nom = 2, sp = 1.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 0, nd = -4, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },

                /* 81-90 */
                new { nl = -2, nlp = 0, nf = 2, nd = 2, nom = 2, sp = 1.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 2, nd = 4, nom = 2, sp = -2.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 0, nd = -4, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 1, nf = 2, nd = -2, nom = 2, sp = 1.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = 2, nom = 1, sp = -1.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = -2, nlp = 0, nf = 2, nd = 4, nom = 2, sp = -1.0, spt = 0.0, ce = 1.0, cet = 0.0 },
                new { nl = -1, nlp = 0, nf = 4, nd = 0, nom = 2, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = -1, nf = 0, nd = -2, nom = 0, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 2, nd = -2, nom = 1, sp = 1.0, spt = 0.0, ce = -1.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 2, nd = 2, nom = 2, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },

                /* 91-100 */
                new { nl = 1, nlp = 0, nf = 0, nd = 2, nom = 1, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 4, nd = -2, nom = 2, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 3, nlp = 0, nf = 2, nd = -2, nom = 2, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = 2, nd = -2, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 2, nd = 0, nom = 1, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = -1, nlp = -1, nf = 0, nd = 2, nom = 1, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = -2, nd = 0, nom = 1, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = -1, nom = 2, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 0, nd = 2, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = -2, nd = -2, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },

                /* 101-106 */
                new { nl = 0, nlp = -1, nf = 2, nd = 0, nom = 1, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 1, nf = 0, nd = -2, nom = 1, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 1, nlp = 0, nf = -2, nd = 2, nom = 0, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 2, nlp = 0, nf = 0, nd = 2, nom = 0, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 0, nf = 2, nd = 4, nom = 2, sp = -1.0, spt = 0.0, ce = 0.0, cet = 0.0 },
                new { nl = 0, nlp = 1, nf = 0, nd = 1, nom = 0, sp = 1.0, spt = 0.0, ce = 0.0, cet = 0.0 }
            };

            /* Number of terms in the series */
            var NT = x.Length;
            /* ------------------------------------------------------------------ */
            /* Interval between fundamental epoch J2000.0 and given date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;
            /* --------------------- */
            /* Fundamental arguments */
            /* --------------------- */
            /* Mean longitude of Moon minus mean longitude of Moon's perigee. */
            var el = Anpm(
                (485866.733 + (715922.633 + (31.310 + 0.064 * t) * t) * t)
                * DAS2R + (1325.0 * t % 1.0) * D2PI);

            /* Mean longitude of Sun minus mean longitude of Sun's perigee. */
            var elp = Anpm(
                (1287099.804 + (1292581.224 + (-0.577 - 0.012 * t) * t) * t)
                * DAS2R + (99.0 * t % 1.0) * D2PI);

            /* Mean longitude of Moon minus mean longitude of Moon's node. */
            var f = Anpm(
                (335778.877 + (295263.137 + (-13.257 + 0.011 * t) * t) * t)
                * DAS2R + (1342.0 * t % 1.0) * D2PI);

            /* Mean elongation of Moon from Sun. */
            var d = Anpm(
                (1072261.307 + (1105601.328 + (-6.891 + 0.019 * t) * t) * t)
                * DAS2R + (1236.0 * t % 1.0) * D2PI);

            /* Longitude of the mean ascending node of the lunar orbit on the */
            /* ecliptic, measured from the mean equinox of date. */
            var om = Anpm(
                (450160.280 + (-482890.539 + (7.455 + 0.008 * t) * t) * t)
                * DAS2R + (-5.0 * t % 1.0) * D2PI);
            /* --------------- */
            /* Nutation series */
            /* --------------- */
            /* Initialize nutation components. */
            var dp = 0.0;
            var de = 0.0;

            /* Sum the nutation terms, ending with the biggest. */
            for (j = NT - 1; j >= 0; j--)
            {
                /* Form argument for current term. */
                arg = (double)x[j].nl * el
                    + (double)x[j].nlp * elp
                    + (double)x[j].nf * f
                    + (double)x[j].nd * d
                    + (double)x[j].nom * om;

                /* Accumulate current nutation term. */
                s = x[j].sp + x[j].spt * t;
                c = x[j].ce + x[j].cet * t;
                if (s != 0.0) dp += s * Sin(arg);
                if (c != 0.0) de += c * Cos(arg);
            }

            /* Convert results from 0.1 mas units to radians. */
            dpsi = dp * U2R;
            deps = de * U2R;

            /* Finished. */
        }
    }
}
