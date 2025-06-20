// C2txy.cs

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
        /// Form the celestial to terrestrial matrix given the date, the UT1,
        /// the CIP coordinates and the polar motion.  IAU 2000.
        /// </summary>
        /// <param name="tta">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="ttb">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="uta">UT1 as a 2-part Julian Date (Note 1)</param>
        /// <param name="utb">UT1 as a 2-part Julian Date (Note 1)</param>
        /// <param name="x">Celestial Intermediate Pole (Note 2)</param>
        /// <param name="y">Celestial Intermediate Pole (Note 2)</param>
        /// <param name="xp">coordinates of the pole (radians, Note 3)</param>
        /// <param name="yp">coordinates of the pole (radians, Note 3)</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix (Note 4)</param>
        public static void C2txy(double tta, double ttb, double uta, double utb,
                      double x, double y, double xp, double yp,
                      out double[,] rc2t)
        {
            var rc2i = new double[3, 3];
            var rpom = new double[3, 3];

            /* Form the celestial-to-intermediate matrix for this TT. */
            C2ixy(tta, ttb, x, y, ref rc2i);

            /* Predict the Earth rotation angle for this UT1. */
            var era = Era00(uta, utb);

            /* Estimate s'. */
            var sp = Sp00(tta, ttb);

            /* Form the polar motion matrix. */
            Pom00(xp, yp, sp, ref rpom);

            /* Combine to form the celestial-to-terrestrial matrix. */
            C2tcio(rc2i, era, rpom, out rc2t);

            /* Finished. */
        }
    }
}
