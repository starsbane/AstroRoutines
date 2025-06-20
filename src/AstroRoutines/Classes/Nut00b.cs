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
		/// Nutation, IAU 2000B model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="dpsi">nutation, luni-solar + planetary (Note 2)</param>
		/// <param name="deps">nutation, luni-solar + planetary (Note 2)</param>
        public static void Nut00b(double date1, double date2, out double dpsi, out double deps)
        {
            double arg,
                sarg, carg;
            int i;

            /* Units of 0.1 microarcsecond to radians */
            const double U2R = DAS2R / 1e7;

            /* ---------------------------------------- */
            /* Fixed offsets in lieu of planetary terms */
            /* ---------------------------------------- */

            const double DPPLAN = -0.135 * DMAS2R;
            const double DEPLAN = 0.388 * DMAS2R;

            /* --------------------------------------------------- */
            /* Luni-solar nutation: argument and term coefficients */
            /* --------------------------------------------------- */

            /* The units for the sine and cosine coefficients are */
            /* 0.1 microarcsec and the same per Julian century    */

            var x = new[]
            {
                /* 1-10 */
                new { nl = 0, nlp = 0, nf = 0, nd = 0, nom = 1,
                     ps = -172064161.0, pst = -174666.0, pc = 33386.0, ec = 92052331.0, ect = 9086.0, es = 15377.0},
                new { nl = 0, nlp = 0, nf = 2, nd = -2, nom = 2,
                     ps = -13170906.0, pst = -1675.0, pc = -13696.0, ec = 5730336.0, ect = -3015.0, es = -4587.0},
                new { nl = 0, nlp = 0, nf = 2, nd = 0, nom = 2,
                     ps = -2276413.0, pst = -234.0, pc = 2796.0, ec = 978459.0, ect = -485.0, es = 1374.0},
                new { nl = 0, nlp = 0, nf = 0, nd = 0, nom = 2,
                     ps = 2074554.0, pst = 207.0, pc = -698.0, ec = -897492.0, ect = 470.0, es = -291.0},
                new { nl = 0, nlp = 1, nf = 0, nd = 0, nom = 0,
                     ps = 1475877.0, pst = -3633.0, pc = 11817.0, ec = 73871.0, ect = -184.0, es = -1924.0},
                new { nl = 0, nlp = 1, nf = 2, nd = -2, nom = 2,
                     ps = -516821.0, pst = 1226.0, pc = -524.0, ec = 224386.0, ect = -677.0, es = -174.0},
                new { nl = 1, nlp = 0, nf = 0, nd = 0, nom = 0,
                     ps = 711159.0, pst = 73.0, pc = -872.0, ec = -6750.0, ect = 0.0, es = 358.0},
                new { nl = 0, nlp = 0, nf = 2, nd = 0, nom = 1,
                     ps = -387298.0, pst = -367.0, pc = 380.0, ec = 200728.0, ect = 18.0, es = 318.0},
                new { nl = 1, nlp = 0, nf = 2, nd = 0, nom = 2,
                     ps = -301461.0, pst = -36.0, pc = 816.0, ec = 129025.0, ect = -63.0, es = 367.0},
                new { nl = 0, nlp = -1, nf = 2, nd = -2, nom = 2,
                     ps = 215829.0, pst = -494.0, pc = 111.0, ec = -95929.0, ect = 299.0, es = 132.0},

                /* 11-20 */
                new { nl = 0, nlp = 0, nf = 2, nd = -2, nom = 1,
                     ps = 128227.0, pst = 137.0, pc = 181.0, ec = -68982.0, ect = -9.0, es = 39.0},
                new { nl = -1, nlp = 0, nf = 2, nd = 0, nom = 2,
                     ps = 123457.0, pst = 11.0, pc = 19.0, ec = -53311.0, ect = 32.0, es = -4.0},
                new { nl = -1, nlp = 0, nf = 0, nd = 2, nom = 0,
                     ps = 156994.0, pst = 10.0, pc = -168.0, ec = -1235.0, ect = 0.0, es = 82.0},
                new { nl = 1, nlp = 0, nf = 0, nd = 0, nom = 1,
                     ps = 63110.0, pst = 63.0, pc = 27.0, ec = -33228.0, ect = 0.0, es = -9.0},
                new { nl = -1, nlp = 0, nf = 0, nd = 0, nom = 1,
                     ps = -57976.0, pst = -63.0, pc = -189.0, ec = 31429.0, ect = 0.0, es = -75.0},
                new { nl = -1, nlp = 0, nf = 2, nd = 2, nom = 2,
                     ps = -59641.0, pst = -11.0, pc = 149.0, ec = 25543.0, ect = -11.0, es = 66.0},
                new { nl = 1, nlp = 0, nf = 2, nd = 0, nom = 1,
                     ps = -51613.0, pst = -42.0, pc = 129.0, ec = 26366.0, ect = 0.0, es = 78.0},
                new { nl = -2, nlp = 0, nf = 2, nd = 0, nom = 1,
                     ps = 45893.0, pst = 50.0, pc = 31.0, ec = -24236.0, ect = -10.0, es = 20.0},
                new { nl = 0, nlp = 0, nf = 0, nd = 2, nom = 0,
                     ps = 63384.0, pst = 11.0, pc = -150.0, ec = -1220.0, ect = 0.0, es = 29.0},
                new { nl = 0, nlp = 0, nf = 2, nd = 2, nom = 2,
                     ps = -38571.0, pst = -1.0, pc = 158.0, ec = 16452.0, ect = -11.0, es = 68.0},

                /* 21-30 */
                new { nl = 0, nlp = -2, nf = 2, nd = -2, nom = 2,
                     ps = 32481.0, pst = 0.0, pc = 0.0, ec = -13870.0, ect = 0.0, es = 0.0},
                new { nl = -2, nlp = 0, nf = 0, nd = 2, nom = 0,
                     ps = -47722.0, pst = 0.0, pc = -18.0, ec = 477.0, ect = 0.0, es = -25.0},
                new { nl = 2, nlp = 0, nf = 2, nd = 0, nom = 2,
                     ps = -31046.0, pst = -1.0, pc = 131.0, ec = 13238.0, ect = -11.0, es = 59.0},
                new { nl = 1, nlp = 0, nf = 2, nd = -2, nom = 2,
                     ps = 28593.0, pst = 0.0, pc = -1.0, ec = -12338.0, ect = 10.0, es = -3.0},
                new { nl = -1, nlp = 0, nf = 2, nd = 0, nom = 1,
                     ps = 20441.0, pst = 21.0, pc = 10.0, ec = -10758.0, ect = 0.0, es = -3.0},
                new { nl = 2, nlp = 0, nf = 0, nd = 0, nom = 0,
                     ps = 29243.0, pst = 0.0, pc = -74.0, ec = -609.0, ect = 0.0, es = 13.0},
                new { nl = 0, nlp = 0, nf = 2, nd = 0, nom = 0,
                     ps = 25887.0, pst = 0.0, pc = -66.0, ec = -550.0, ect = 0.0, es = 11.0},
                new { nl = 0, nlp = 1, nf = 0, nd = 0, nom = 1,
                     ps = -14053.0, pst = -25.0, pc = 79.0, ec = 8551.0, ect = -2.0, es = -45.0},
                new { nl = -1, nlp = 0, nf = 0, nd = 2, nom = 1,
                     ps = 15164.0, pst = 10.0, pc = 11.0, ec = -8001.0, ect = 0.0, es = -1.0},
                new { nl = 0, nlp = 2, nf = 2, nd = -2, nom = 2,
                     ps = -15794.0, pst = 72.0, pc = -16.0, ec = 6850.0, ect = -42.0, es = -5.0},

                /* 31-40 */
                new { nl = 0, nlp = 0, nf = -2, nd = 2, nom = 0,
                     ps = 21783.0, pst = 0.0, pc = 13.0, ec = -167.0, ect = 0.0, es = 13.0},
                new { nl = 1, nlp = 0, nf = 0, nd = -2, nom = 1,
                     ps = -12873.0, pst = -10.0, pc = -37.0, ec = 6953.0, ect = 0.0, es = -14.0},
                new { nl = 0, nlp = -1, nf = 0, nd = 0, nom = 1,
                     ps = -12654.0, pst = 11.0, pc = 63.0, ec = 6415.0, ect = 0.0, es = 26.0},
                new { nl = -1, nlp = 0, nf = 2, nd = 2, nom = 1,
                     ps = -10204.0, pst = 0.0, pc = 25.0, ec = 5222.0, ect = 0.0, es = 15.0},
                new { nl = 0, nlp = 2, nf = 0, nd = 0, nom = 0,
                     ps = 16707.0, pst = -85.0, pc = -10.0, ec = 168.0, ect = -1.0, es = 10.0},
                new { nl = 1, nlp = 0, nf = 2, nd = 2, nom = 2,
                     ps = -7691.0, pst = 0.0, pc = 44.0, ec = 3268.0, ect = 0.0, es = 19.0},
                new { nl = -2, nlp = 0, nf = 2, nd = 0, nom = 0,
                     ps = -11024.0, pst = 0.0, pc = -14.0, ec = 104.0, ect = 0.0, es = 2.0},
                new { nl = 0, nlp = 1, nf = 2, nd = 0, nom = 2,
                     ps = 7566.0, pst = -21.0, pc = -11.0, ec = -3250.0, ect = 0.0, es = -5.0},
                new { nl = 0, nlp = 0, nf = 2, nd = 2, nom = 1,
                     ps = -6637.0, pst = -11.0, pc = 25.0, ec = 3353.0, ect = 0.0, es = 14.0},
                new { nl = 0, nlp = -1, nf = 2, nd = 0, nom = 2,
                     ps = -7141.0, pst = 21.0, pc = 8.0, ec = 3070.0, ect = 0.0, es = 4.0},

                /* 41-50 */
                new { nl = 0, nlp = 0, nf = 0, nd = 2, nom = 1,
                     ps = -6302.0, pst = -11.0, pc = 2.0, ec = 3272.0, ect = 0.0, es = 4.0},
                new { nl = 1, nlp = 0, nf = 2, nd = -2, nom = 1,
                     ps = 5800.0, pst = 10.0, pc = 2.0, ec = -3045.0, ect = 0.0, es = -1.0},
                new { nl = 2, nlp = 0, nf = 2, nd = -2, nom = 2,
                     ps = 6443.0, pst = 0.0, pc = -7.0, ec = -2768.0, ect = 0.0, es = -4.0},
                new { nl = -2, nlp = 0, nf = 0, nd = 2, nom = 1,
                     ps = -5774.0, pst = -11.0, pc = -15.0, ec = 3041.0, ect = 0.0, es = -5.0},
                new { nl = 2, nlp = 0, nf = 2, nd = 0, nom = 1,
                     ps = -5350.0, pst = 0.0, pc = 21.0, ec = 2695.0, ect = 0.0, es = 12.0},
                new { nl = 0, nlp = -1, nf = 2, nd = -2, nom = 1,
                     ps = -4752.0, pst = -11.0, pc = -3.0, ec = 2719.0, ect = 0.0, es = -3.0},
                new { nl = 0, nlp = 0, nf = 0, nd = -2, nom = 1,
                     ps = -4940.0, pst = -11.0, pc = -21.0, ec = 2720.0, ect = 0.0, es = -9.0},
                new { nl = -1, nlp = -1, nf = 0, nd = 2, nom = 0,
                     ps = 7350.0, pst = 0.0, pc = -8.0, ec = -51.0, ect = 0.0, es = 4.0},
                new { nl = 2, nlp = 0, nf = 0, nd = -2, nom = 1,
                     ps = 4065.0, pst = 0.0, pc = 6.0, ec = -2206.0, ect = 0.0, es = 1.0},
                new { nl = 1, nlp = 0, nf = 0, nd = 2, nom = 0,
                     ps = 6579.0, pst = 0.0, pc = -24.0, ec = -199.0, ect = 0.0, es = 2.0},

                /* 51-60 */
                new { nl = 0, nlp = 1, nf = 2, nd = -2, nom = 1,
                     ps = 3579.0, pst = 0.0, pc = 5.0, ec = -1900.0, ect = 0.0, es = 1.0},
                new { nl = 1, nlp = -1, nf = 0, nd = 0, nom = 0,
                     ps = 4725.0, pst = 0.0, pc = -6.0, ec = -41.0, ect = 0.0, es = 3.0},
                new { nl = -2, nlp = 0, nf = 2, nd = 0, nom = 2,
                     ps = -3075.0, pst = 0.0, pc = -2.0, ec = 1313.0, ect = 0.0, es = -1.0},
                new { nl = 3, nlp = 0, nf = 2, nd = 0, nom = 2,
                     ps = -2904.0, pst = 0.0, pc = 15.0, ec = 1233.0, ect = 0.0, es = 7.0},
                new { nl = 0, nlp = -1, nf = 0, nd = 2, nom = 0,
                     ps = 4348.0, pst = 0.0, pc = -10.0, ec = -81.0, ect = 0.0, es = 2.0},
                new { nl = 1, nlp = -1, nf = 2, nd = 0, nom = 2,
                     ps = -2878.0, pst = 0.0, pc = 8.0, ec = 1232.0, ect = 0.0, es = 4.0},
                new { nl = 0, nlp = 0, nf = 0, nd = 1, nom = 0,
                     ps = -4230.0, pst = 0.0, pc = 5.0, ec = -20.0, ect = 0.0, es = -2.0},
                new { nl = -1, nlp = -1, nf = 2, nd = 2, nom = 2,
                     ps = -2819.0, pst = 0.0, pc = 7.0, ec = 1207.0, ect = 0.0, es = 3.0},
                new { nl = -1, nlp = 0, nf = 2, nd = 0, nom = 0,
                     ps = -4056.0, pst = 0.0, pc = 5.0, ec = 40.0, ect = 0.0, es = -2.0},
                new { nl = 0, nlp = -1, nf = 2, nd = 2, nom = 2,
                     ps = -2647.0, pst = 0.0, pc = 11.0, ec = 1129.0, ect = 0.0, es = 5.0},

                /* 61-70 */
                new { nl = -2, nlp = 0, nf = 0, nd = 0, nom = 1,
                     ps = -2294.0, pst = 0.0, pc = -10.0, ec = 1266.0, ect = 0.0, es = -4.0},
                new { nl = 1, nlp = 1, nf = 2, nd = 0, nom = 2,
                     ps = 2481.0, pst = 0.0, pc = -7.0, ec = -1062.0, ect = 0.0, es = -3.0},
                new { nl = 2, nlp = 0, nf = 0, nd = 0, nom = 1,
                     ps = 2179.0, pst = 0.0, pc = -2.0, ec = -1129.0, ect = 0.0, es = -2.0},
                new { nl = -1, nlp = 1, nf = 0, nd = 1, nom = 0,
                     ps = 3276.0, pst = 0.0, pc = 1.0, ec = -9.0, ect = 0.0, es = 0.0},
                new { nl = 1, nlp = 1, nf = 0, nd = 0, nom = 0,
                     ps = -3389.0, pst = 0.0, pc = 5.0, ec = 35.0, ect = 0.0, es = -2.0},
                new { nl = 1, nlp = 0, nf = 2, nd = 0, nom = 0,
                     ps = 3339.0, pst = 0.0, pc = -13.0, ec = -107.0, ect = 0.0, es = 1.0},
                new { nl = -1, nlp = 0, nf = 2, nd = -2, nom = 1,
                     ps = -1987.0, pst = 0.0, pc = -6.0, ec = 1073.0, ect = 0.0, es = -2.0},
                new { nl = 1, nlp = 0, nf = 0, nd = 0, nom = 2,
                     ps = -1981.0, pst = 0.0, pc = 0.0, ec = 854.0, ect = 0.0, es = 0.0},
                new { nl = -1, nlp = 0, nf = 0, nd = 1, nom = 0,
                     ps = 4026.0, pst = 0.0, pc = -353.0, ec = -553.0, ect = 0.0, es = -139.0},
                new { nl = 0, nlp = 0, nf = 2, nd = 1, nom = 2,
                     ps = 1660.0, pst = 0.0, pc = -5.0, ec = -710.0, ect = 0.0, es = -2.0},

                /* 71-77 */
                new { nl = -1, nlp = 0, nf = 2, nd = 4, nom = 2,
                     ps = -1521.0, pst = 0.0, pc = 9.0, ec = 647.0, ect = 0.0, es = 4.0},
                new { nl = -1, nlp = 1, nf = 0, nd = 1, nom = 1,
                     ps = 1314.0, pst = 0.0, pc = 0.0, ec = -700.0, ect = 0.0, es = 0.0},
                new { nl = 0, nlp = -2, nf = 2, nd = -2, nom = 1,
                     ps = -1283.0, pst = 0.0, pc = 0.0, ec = 672.0, ect = 0.0, es = 0.0},
                new { nl = 1, nlp = 0, nf = 2, nd = 2, nom = 1,
                     ps = -1331.0, pst = 0.0, pc = 8.0, ec = 663.0, ect = 0.0, es = 4.0},
                new { nl = -2, nlp = 0, nf = 2, nd = 2, nom = 2,
                     ps = 1383.0, pst = 0.0, pc = -2.0, ec = -594.0, ect = 0.0, es = -2.0},
                new { nl = -1, nlp = 0, nf = 0, nd = 0, nom = 2,
                     ps = 1405.0, pst = 0.0, pc = 4.0, ec = -610.0, ect = 0.0, es = 2.0},
                new { nl = 1, nlp = 1, nf = 2, nd = -2, nom = 2,
                     ps = 1290.0, pst = 0.0, pc = 0.0, ec = -556.0, ect = 0.0, es = 0.0}
            };

            /* Number of terms in the series */
            var NLS = x.Length;
            /* ------------------------------------------------------------------ */
            /* Interval between fundamental epoch J2000.0 and given date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;

            /* --------------------*/
            /* LUNI-SOLAR NUTATION */
            /* --------------------*/
            /* Fundamental (Delaunay) arguments from Simon et al. (1994) */
            /* Mean anomaly of the Moon. */
            var el = ((485868.249036 + (1717915923.2178) * t) % TURNAS) * DAS2R;

            /* Mean anomaly of the Sun. */
            var elp = ((1287104.79305 + (129596581.0481) * t) % TURNAS) * DAS2R;

            /* Mean argument of the latitude of the Moon. */
            var f = ((335779.526232 + (1739527262.8478) * t) % TURNAS) * DAS2R;

            /* Mean elongation of the Moon from the Sun. */
            var d = ((1072260.70369 + (1602961601.2090) * t) % TURNAS) * DAS2R;

            /* Mean longitude of the ascending node of the Moon. */
            var om = ((450160.398036 + (-6962890.5431) * t) % TURNAS) * DAS2R;

            /* Initialize the nutation values. */
            var dp = 0.0;
            var de = 0.0;

            /* Summation of luni-solar nutation series (smallest terms first). */
            for (i = NLS - 1; i >= 0; i--)
            {
                /* Argument and functions. */
                arg = ((double)x[i].nl * el +
                       (double)x[i].nlp * elp +
                       (double)x[i].nf * f +
                       (double)x[i].nd * d +
                       (double)x[i].nom * om) % D2PI;
                sarg = Sin(arg);
                carg = Cos(arg);

                /* Term. */
                dp += (x[i].ps + x[i].pst * t) * sarg + x[i].pc * carg;
                de += (x[i].ec + x[i].ect * t) * carg + x[i].es * sarg;
            }

            /* Convert from 0.1 microarcsec units to radians. */
            var dpsils = dp * U2R;
            var depsls = de * U2R;
            /* ------------------------------*/
            /* IN LIEU OF PLANETARY NUTATION */
            /* ------------------------------*/
            /* Fixed offset to correct for missing terms in truncated series. */
            var dpsipl = DPPLAN;
            var depspl = DEPLAN;
            /* --------*/
            /* RESULTS */
            /* --------*/
            /* Add luni-solar and planetary components. */
            dpsi = dpsils + dpsipl;
            deps = depsls + depspl;

            /* Finished. */
        }
    }
}
