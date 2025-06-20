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
        /// Earth rotation angle (IAU 2000 model).
        /// </summary>
        /// <param name="dj1">UT1 as a 2-part Julian Date</param>
        /// <param name="dj2">UT1 as a 2-part Julian Date</param>
        /// <returns>Earth rotation angle, radians</returns>
        public static double Era00(double dj1, double dj2)
        {
            double d1, d2;

            /* Days since fundamental epoch. */
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
            var t = d1 + (d2 - DJ00);

            /* Fractional part of T (days). */
            var f = (d1 % 1.0) + (d2 % 1.0);

            /* Earth rotation angle at this UT1. */
            var theta = Anp(D2PI * (f + 0.7790572732640 + 0.00273781191135448 * t));

            return theta;
        }
    }
}
