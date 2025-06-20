using static System.Math;

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
        /// Julian Date to Gregorian year, month, day, and fraction of a day.
        /// </summary>
        /// <param name="dj1">Julian Date</param>
        /// <param name="dj2">Julian Date</param>
        /// <param name="iy">year</param>
        /// <param name="im">month</param>
        /// <param name="id">day</param>
        /// <param name="fd">fraction of day</param>
        /// <returns>status: 0 = OK, -1 = unacceptable date</returns>
        public static int Jd2cal(double dj1, double dj2, out int iy, out int im, out int id, out double fd)
        {
            /* Minimum and maximum allowed JD */
            const double DJMIN = -68569.5;
            const double DJMAX = 1e9;

            long i;
            double x, t;
            var v = new double[2];
            iy = im = id = 0;
            fd = 0;

            /* Verify date is acceptable. */
            var dj = dj1 + dj2;
            if (dj < DJMIN || dj > DJMAX) return -1;

            /* Separate day and fraction (where -0.5 <= fraction < 0.5). */
            var d = Round(dj1);
            var f1 = dj1 - d;
            var jd = (long)d;
            d = Round(dj2);
            var f2 = dj2 - d;
            jd += (long)d;

            /* Compute f1+f2+0.5 using compensated summation (Klein 2006). */
            var s = 0.5;
            var cs = 0.0;
            v[0] = f1;
            v[1] = f2;
            for (i = 0; i < 2; i++)
            {
                x = v[i];
                t = s + x;
                cs += Abs(s) >= Abs(x) ? (s - t) + x : (x - t) + s;
                s = t;
                if (s >= 1.0)
                {
                    jd++;
                    s -= 1.0;
                }
            }
            var f = s + cs;
            cs = f - s;

            /* Deal with negative f. */
            if (f < 0.0)
            {
                /* Compensated summation: assume that |s| <= 1.0. */
                f = s + 1.0;
                cs += (1.0 - f) + s;
                s = f;
                f = s + cs;
                cs = f - s;
                jd--;
            }

            /* Deal with f that is 1.0 or more (when rounded to double). */
            if ((f - 1.0) >= -double.Epsilon / 4.0)
            {
                /* Compensated summation: assume that |s| <= 1.0. */
                t = s - 1.0;
                cs += (s - t) - 1.0;
                s = t;
                f = s + cs;
                if (-double.Epsilon / 2.0 < f)
                {
                    jd++;
                    f = Max(f, 0.0);
                }
            }

            /* Express day in Gregorian calendar. */
            var l = jd + 68569L;
            var n = (4L * l) / 146097L;
            l -= (146097L * n + 3L) / 4L;
            i = (4000L * (l + 1L)) / 1461001L;
            l -= (1461L * i) / 4L - 31L;
            var k = (80L * l) / 2447L;
            id = (int)(l - (2447L * k) / 80L);
            l = k / 11L;
            im = (int)(k + 2L - 12L * l);
            iy = (int)(100L * (n - 49L) + i + l);
            fd = f;

            /* Success. */
            return 0;

            /* Finished. */
        }
    }
}
