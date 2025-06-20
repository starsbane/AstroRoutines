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
        /// Time scale transformation: Terrestrial Time, TT, to Geocentric Coordinate Time, TCG.
        /// </summary>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <param name="tcg1">TCG as a 2-part Julian Date</param>
        /// <param name="tcg2">TCG as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Tttcg(double tt1, double tt2, ref double tcg1, ref double tcg2)
        {
            // 1977 Jan 1 00:00:32.184 TT, as MJD
            const double t77t = DJM77 + TTMTAI / DAYSEC;

            // TT to TCG rate
            const double elgg = ELG / (1.0 - ELG);

            // Result, safeguarding precision
            if (Abs(tt1) > Abs(tt2))
            {
                tcg1 = tt1;
                tcg2 = tt2 + ((tt1 - DJM0) + (tt2 - t77t)) * elgg;
            }
            else
            {
                tcg1 = tt1 + ((tt2 - DJM0) + (tt1 - t77t)) * elgg;
                tcg2 = tt2;
            }

            // Status (always OK)
            return 0;
        }
    }
}
