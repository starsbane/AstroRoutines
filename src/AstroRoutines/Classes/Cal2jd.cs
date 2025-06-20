// Cal2jd.cs

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
        /// Gregorian Calendar to Julian Date.
        /// </summary>
        /// <param name="iy">year, month, day in Gregorian calendar (Note 1)</param>
        /// <param name="im">year, month, day in Gregorian calendar (Note 1)</param>
        /// <param name="id">year, month, day in Gregorian calendar (Note 1)</param>
        /// <param name="djm0">MJD zero-point: always 2400000.5</param>
        /// <param name="djm">Modified Julian Date for 0 hrs</param>
        /// <returns>status:
        /// 0 = OK
        /// -1 = bad year   (Note 3: JD not computed)
        /// -2 = bad month  (JD not computed)
        /// -3 = bad day    (JD computed)</returns>
        public static int Cal2jd(int iy, int im, int id, out double djm0, out double djm)
        {
            djm0 = 0;
            djm = 0;

            /* Earliest year allowed (4800BC) */
            const int IYMIN = -4799;

            /* Month lengths in days */
            int[] mtab = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            /* Preset status. */
            var j = 0;

            /* Validate year and month. */
            if (iy < IYMIN) return -1;
            if (im < 1 || im > 12) return -2;

            /* If February in a leap year, 1, otherwise 0. */
            var ly = ((im == 2) && (iy % 4 == 0) && (iy % 100 != 0 || iy % 400 == 0)) ? 1 : 0;

            /* Validate day, taking into account leap years. */
            if ((id < 1) || (id > (mtab[im - 1] + ly))) j = -3;

            /* Return result. */
            var my = (im - 14) / 12;
            var iypmy = (long)(iy + my);
            djm0 = DJM0;
            djm = (double)((1461L * (iypmy + 4800L)) / 4L
                          + (367L * (long)(im - 2 - 12 * my)) / 12L
                          - (3L * ((iypmy + 4900L) / 100L)) / 4L
                          + (long)id - 2432076L);

            /* Return status. */
            return j;

            /* Finished. */
        }
    }
}
