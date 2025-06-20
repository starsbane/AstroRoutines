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
        /// Greenwich mean sidereal time (consistent with IAU 2006 precession).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <returns>Greenwich mean sidereal time (radians)</returns>
        public static double Gmst06(double uta, double utb, double tta, double ttb)
        {
            /* TT Julian centuries since J2000.0. */
            var t = ((tta - DJ00) + ttb) / DJC;

            /* Greenwich mean sidereal time, IAU 2006. */
            var gmst = Anp(Era00(uta, utb) +
                           (0.014506 +
                            (4612.156534 +
                             (1.3915817 +
                              (-0.00000044 +
                               (-0.000029956 +
                                (-0.0000000368)
                                * t) * t) * t) * t) * t) * DAS2R);

            return gmst;

            /* Finished. */
        }
    }
}
