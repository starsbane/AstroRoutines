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
        /// Time scale transformation: Universal Time, UT1, to Terrestrial Time, TT.
        /// </summary>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <param name="dt">TT-UT1 in seconds</param>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Ut1tt(double ut11, double ut12, double dt, 
                                ref double tt1, ref double tt2)
        {
            var dtd =
                // Result, safeguarding precision
                dt / DAYSEC;
            if (Abs(ut11) > Abs(ut12))
            {
                tt1 = ut11;
                tt2 = ut12 + dtd;
            }
            else
            {
                tt1 = ut11 + dtd;
                tt2 = ut12;
            }

            // Status (always OK)
            return 0;
        }
    }
}
