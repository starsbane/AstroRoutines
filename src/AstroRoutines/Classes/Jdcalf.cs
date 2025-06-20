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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Julian Date to Gregorian Calendar, expressed in a form convenient
        /// for formatting messages:  rounded to a specified precision.
        /// </summary>
        /// <param name="ndp">number of decimal places of days in fraction</param>
        /// <param name="dj1">dj1+dj2 = Julian Date</param>
        /// <param name="dj2">dj1+dj2 = Julian Date</param>
        /// <param name="iymdf">year, month, day, fraction in Gregorian calendar</param>
        /// <returns>status: -1 = date out of range, 0 = OK, +1 = ndp not 0-9 (interpreted as 0)</returns>
        public static int Jdcalf(int ndp, double dj1, double dj2, ref int[] iymdf)
        {
            int j;
            double denom, d1, d2;

            /* Denominator of fraction (e.g. 100 for 2 decimal places). */
            if ((ndp >= 0) && (ndp <= 9))
            {
                j = 0;
                denom = Pow(10.0, ndp);
            }
            else
            {
                j = 1;
                denom = 1.0;
            }

            /* Copy the date, big then small. */
            if (Abs(dj1) >= Abs(dj2))
            {
                d1 = dj1;
                d2 = dj2;
            }
            else
            {
                d1 = dj2;
                d2 = dj1;
            }

            /* Realign to midnight (without rounding error). */
            d1 -= 0.5;

            /* Separate day and fraction (as precisely as possible). */
            var d = Round(d1);
            var f1 = d1 - d;
            var djd = d;
            d = Round(d2);
            var f2 = d2 - d;
            djd += d;
            d = Round(f1 + f2);
            var f = (f1 - d) + f2;
            if (f < 0.0)
            {
                f += 1.0;
                d -= 1.0;
            }
            djd += d;

            /* Round the total fraction to the specified number of places. */
            var rf = Round(f * denom) / denom;

            /* Re-align to noon. */
            djd += 0.5;

            /* Convert to Gregorian calendar. */
            var js = Jd2cal(djd, rf, out iymdf[0], out iymdf[1], out iymdf[2], out f);
            if (js == 0)
            {
                iymdf[3] = (int)Round(f * denom);
            }
            else
            {
                j = js;
            }

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
