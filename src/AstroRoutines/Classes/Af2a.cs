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
        /// Convert degrees, arcminutes, arcseconds to radians.
        /// </summary>
        /// <param name="s">sign: '-' = negative, otherwise positive</param>
        /// <param name="ideg">degrees</param>
        /// <param name="iamin">arcminutes</param>
        /// <param name="asec">arcseconds</param>
        /// <param name="rad">angle in radians</param>
        /// <returns>status: 0 = OK, 1 = ideg outside range 0-359, 2 = iamin outside range 0-59, 3 = asec outside range 0-59.999...</returns>
        public static int Af2a(char s, int ideg, int iamin, double asec, out double rad)
        {
            rad = (s == '-' ? -1.0 : 1.0) *
                  (60.0 * (60.0 * Abs(ideg) + Abs(iamin)) + Abs(asec)) * DAS2R;

            if (ideg < 0 || ideg > 359) return 1;
            if (iamin < 0 || iamin > 59) return 2;
            if (asec < 0.0 || asec >= 60.0) return 3;
            return 0;
        }
    }
}