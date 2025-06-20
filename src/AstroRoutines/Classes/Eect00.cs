// Eect00.cs

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
        private struct Eect00_TERM
        {
            public int[] nfa;      /* coefficients of l,l',F,D,Om,LVe,LE,pA */
            public double s, c;     /* sine and cosine coefficients */

            public Eect00_TERM(int[] nfa, double s, double c)
            {
                this.nfa = nfa;
                this.s = s;
                this.c = c;
            }
        }

        /// <summary>
        /// Equation of the equinoxes complementary terms, consistent with
        /// IAU 2000 resolutions.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>complementary terms (Note 2)</returns>
        public static double Eect00(double date1, double date2)
        {
            /* Time since J2000.0, in Julian centuries */

            /* Miscellaneous */
            int i, j;
            double a;

            /* Fundamental arguments */
            var fa = new double[14];

            /* Returned value. */

            /* ----------------------------------------- */
            /* The series for the EE complementary terms */
            /* ----------------------------------------- */


            /* Terms of order t^0 */
            var e0 =
                new[]
                {
                    /* 1-10 */
                    new Eect00_TERM(new[] { 0, 0, 0, 0, 1, 0, 0, 0 }, 2640.96e-6, -0.39e-6),
                    new Eect00_TERM(new[] { 0, 0, 0, 0, 2, 0, 0, 0 }, 63.52e-6, -0.02e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, -2, 3, 0, 0, 0 }, 11.75e-6, 0.01e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, -2, 1, 0, 0, 0 }, 11.21e-6, 0.01e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, -2, 2, 0, 0, 0 }, -4.55e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, 0, 3, 0, 0, 0 }, 2.02e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, 0, 1, 0, 0, 0 }, 1.98e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 0, 0, 3, 0, 0, 0 }, -1.72e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 1, 0, 0, 1, 0, 0, 0 }, -1.41e-6, -0.01e-6),
                    new Eect00_TERM(new[] { 0, 1, 0, 0, -1, 0, 0, 0 }, -1.26e-6, -0.01e-6),

                    /* 11-20 */
                    new Eect00_TERM(new[] { 1, 0, 0, 0, -1, 0, 0, 0 }, -0.63e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, 0, 0, 1, 0, 0, 0 }, -0.63e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 1, 2, -2, 3, 0, 0, 0 }, 0.46e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 1, 2, -2, 1, 0, 0, 0 }, 0.45e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 4, -4, 4, 0, 0, 0 }, 0.36e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 1, -1, 1, -8, 12, 0 }, -0.24e-6, -0.12e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, 0, 0, 0, 0, 0 }, 0.32e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 2, 0, 2, 0, 0, 0 }, 0.28e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, 2, 0, 3, 0, 0, 0 }, 0.27e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, 2, 0, 1, 0, 0, 0 }, 0.26e-6, 0.00e-6),

                    /* 21-30 */
                    new Eect00_TERM(new[] { 0, 0, 2, -2, 0, 0, 0, 0 }, -0.21e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 1, -2, 2, -3, 0, 0, 0 }, 0.19e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 1, -2, 2, -1, 0, 0, 0 }, 0.18e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 0, 0, 0, 8, -13, -1 }, -0.10e-6, 0.05e-6),
                    new Eect00_TERM(new[] { 0, 0, 0, 2, 0, 0, 0, 0 }, 0.15e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 2, 0, -2, 0, -1, 0, 0, 0 }, -0.14e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, 0, -2, 1, 0, 0, 0 }, 0.14e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 1, 2, -2, 2, 0, 0, 0 }, -0.14e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, 0, -2, -1, 0, 0, 0 }, 0.14e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 0, 0, 4, -2, 4, 0, 0, 0 }, 0.13e-6, 0.00e-6),

                    /* 31-33 */
                    new Eect00_TERM(new[] { 0, 0, 2, -2, 4, 0, 0, 0 }, -0.11e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, -2, 0, -3, 0, 0, 0 }, 0.11e-6, 0.00e-6),
                    new Eect00_TERM(new[] { 1, 0, -2, 0, -1, 0, 0, 0 }, 0.11e-6, 0.00e-6)
                };

            /* Terms of order t^1 */
            var e1 =
                new[] { new Eect00_TERM(new[] { 0, 0, 0, 0, 1, 0, 0, 0 }, -0.87e-6, 0.00e-6) };

            /* Number of terms in the series */
            var NE0 = e0.Length;
            var NE1 = e1.Length;
            /* ------------------------------------------------------------------ */
            /* Interval between fundamental epoch J2000.0 and current date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;
            /* Fundamental Arguments (from IERS Conventions 2003) */
            /* Mean anomaly of the Moon. */
            fa[0] = Fal03(t);

            /* Mean anomaly of the Sun. */
            fa[1] = Falp03(t);

            /* Mean longitude of the Moon minus that of the ascending node. */
            fa[2] = Faf03(t);

            /* Mean elongation of the Moon from the Sun. */
            fa[3] = Fad03(t);

            /* Mean longitude of the ascending node of the Moon. */
            fa[4] = Faom03(t);

            /* Mean longitude of Venus. */
            fa[5] = Fave03(t);

            /* Mean longitude of Earth. */
            fa[6] = Fae03(t);

            /* General precession in longitude. */
            fa[7] = Fapa03(t);

            /* Evaluate the EE complementary terms. */
            var s0 = 0.0;
            var s1 = 0.0;

            for (i = NE0 - 1; i >= 0; i--)
            {
                a = 0.0;
                for (j = 0; j < 8; j++)
                {
                    a += (double)(e0[i].nfa[j]) * fa[j];
                }
                s0 += e0[i].s * Sin(a) + e0[i].c * Cos(a);
            }

            for (i = NE1 - 1; i >= 0; i--)
            {
                a = 0.0;
                for (j = 0; j < 8; j++)
                {
                    a += (double)(e1[i].nfa[j]) * fa[j];
                }
                s1 += e1[i].s * Sin(a) + e1[i].c * Cos(a);
            }

            var eect = (s0 + s1 * t) * DAS2R;

            return eect;

            /* Finished. */
        }
    }
}
