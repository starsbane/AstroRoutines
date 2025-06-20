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
        /// Universal Time to Greenwich mean sidereal time (IAU 1982 model).
        /// </summary>
        /// <param name="dj1">UT1 Julian Date</param>
        /// <param name="dj2">UT1 Julian Date</param>
        /// <returns>Greenwich mean sidereal time (radians)</returns>
        public static double Gmst82(double dj1, double dj2)
        {
            /* Coefficients of IAU 1982 GMST-UT1 model */
            var A = 24110.54841 - DAYSEC / 2.0;
            var B = 8640184.812866;
            var C = 0.093104;
            var D = -6.2e-6;

            /* The first constant, A, has to be adjusted by 12 hours because the */
            /* UT1 is supplied as a Julian date, which begins at noon.           */

            double d1, d2;

            /* Julian centuries since fundamental epoch. */
            if (dj1 < dj2)
            {
                d1 = dj1;
                d2 = dj2;
            }
            else
            {
                d1 = dj2;
                d2 = dj1;
            }
            var t = (d1 + (d2 - DJ00)) / DJC;

            /* Fractional part of JD(UT1), in seconds. */
            var f = DAYSEC * (d1 % 1.0 + d2 % 1.0);

            /* GMST at this UT1. */
            var gmst = Anp(DS2R * ((A + (B + (C + D * t) * t) * t) + f));

            return gmst;

            /* Finished. */
        }
    }
}
