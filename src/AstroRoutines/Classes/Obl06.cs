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
		/// Mean obliquity of the ecliptic, IAU 2006 precession model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <returns>obliquity of the ecliptic (radians, Note 2)</returns>
        public static double Obl06(double date1, double date2)
        {
            /* Interval between fundamental date J2000.0 and given date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;

            /* Mean obliquity. */
            var eps0 = (84381.406 +
                        (-46.836769 +
                         (-0.0001831 +
                          (0.00200340 +
                           (-0.000000576 +
                            (-0.0000000434) * t) * t) * t) * t) * t) * DAS2R;

            return eps0;

            /* Finished. */
        }
    }
}
