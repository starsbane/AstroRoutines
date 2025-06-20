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
        /// Time scale transformation: Coordinated Universal Time, UTC, to International Atomic Time, TAI.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <returns>
        /// Status:
        /// +1 = dubious year
        /// 0 = OK
        /// -1 = unacceptable date
        /// </returns>
        public static int Utctai(double utc1, double utc2, 
                                 out double tai1, out double tai2)
        {
            double u1, u2, w;
            tai1 = tai2 = 0;

            // Put the two parts of the UTC into big-first order
            var big1 = (Abs(utc1) >= Abs(utc2));
            if (big1)
            {
                u1 = utc1;
                u2 = utc2;
            }
            else
            {
                u1 = utc2;
                u2 = utc1;
            }

            // Get TAI-UTC at 0h today
            var j = Jd2cal(u1, u2, out var iy, out var im, out var id, out var fd);
            if (j != 0) return j;
            j = Dat(iy, im, id, 0.0, out var dat0);
            if (j < 0) return j;

            // Get TAI-UTC at 12h today (to detect drift)
            j = Dat(iy, im, id, 0.5, out var dat12);
            if (j < 0) return j;

            // Get TAI-UTC at 0h tomorrow (to detect jumps)
            j = Jd2cal(u1 + 1.5, u2 - fd, out var iyt, out var imt, out var idt, out w);
            if (j != 0) return j;
            j = Dat(iyt, imt, idt, 0.0, out var dat24);
            if (j < 0) return j;

            // Separate TAI-UTC change into per-day (DLOD) and any jump (DLEAP)
            var dlod = 2.0 * (dat12 - dat0);
            var dleap = dat24 - (dat0 + dlod);

            // Remove any scaling applied to spread leap into preceding day
            fd *= (DAYSEC + dleap) / DAYSEC;

            // Scale from (pre-1972) UTC seconds to SI seconds
            fd *= (DAYSEC + dlod) / DAYSEC;

            // Today's calendar date to 2-part JD
            if (Cal2jd(iy, im, id, out var z1, out var z2) != 0) return -1;

            // Assemble the TAI result, preserving the UTC split and order
            var a2 = z1 - u1;
            a2 += z2;
            a2 += fd + dat0 / DAYSEC;
            if (big1)
            {
                tai1 = u1;
                tai2 = a2;
            }
            else
            {
                tai1 = a2;
                tai2 = u1;
            }

            // Status
            return j;
        }
    }
}
