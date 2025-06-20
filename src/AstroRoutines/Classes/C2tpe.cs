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
        /// Form the celestial to terrestrial matrix given the date, the UT1, the nutation and the polar motion. IAU 2000.
        /// </summary>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="dpsi">nutation (radians)</param>
        /// <param name="deps">nutation (radians)</param>
        /// <param name="xp">coordinates of the pole (radians)</param>
        /// <param name="yp">coordinates of the pole (radians)</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix</param>
        public static void C2tpe(double tta, double ttb, double uta, double utb,
            double dpsi, double deps, double xp, double yp,
            out double[,] rc2t)
        {
            var rb = new double[3, 3];
            var rp = new double[3, 3];
            var rbp = new double[3, 3];
            var rn = new double[3, 3];
            var rpom = new double[3, 3];

            /* Form the celestial-to-true matrix for this TT. */
            Pn00(tta, ttb, dpsi, deps, out var epsa, out rb, out rp, out rbp, out rn, out var rbpn);

            /* Predict the Greenwich Mean Sidereal Time for this UT1 and TT. */
            var gmst = Gmst00(uta, utb, tta, ttb);

            /* Predict the equation of the equinoxes given TT and nutation. */
            var ee = Ee00(tta, ttb, epsa, dpsi);

            /* Estimate s'. */
            var sp = Sp00(tta, ttb);

            /* Form the polar motion matrix. */
            Pom00(xp, yp, sp, ref rpom);

            /* Combine to form the celestial-to-terrestrial matrix. */
            C2teqx(rbpn, gmst + ee, rpom, out rc2t);
        }
    }
}
