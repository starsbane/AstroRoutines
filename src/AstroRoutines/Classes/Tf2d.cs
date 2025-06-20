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
        /// Convert hours, minutes, seconds to days.
        /// </summary>
        /// <param name="s">sign: '-' = negative, otherwise positive</param>
        /// <param name="ihour">hours</param>
        /// <param name="imin">minutes</param>
        /// <param name="sec">seconds</param>
        /// <param name="days">interval in days</param>
        /// <returns>status: 0 = OK, 1 = ihour invalid, 2 = imin invalid, 3 = sec invalid</returns>
        public static int Tf2d(char s, int ihour, int imin, double sec, out double days)
        {
            days = (s == '-' ? -1.0 : 1.0) *
                   (60.0 * (60.0 * Abs(ihour) + Abs(imin)) + Abs(sec)) / DAYSEC;

            if (ihour < 0 || ihour > 23) return 1;
            if (imin < 0 || imin > 59) return 2;
            if (sec < 0.0 || sec >= 60.0) return 3;
            return 0;
        }
    }
}
