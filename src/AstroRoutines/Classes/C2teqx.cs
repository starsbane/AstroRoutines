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
        /// Assemble the celestial to terrestrial matrix from equinox-based components (the celestial-to-true matrix, the Greenwich Apparent Sidereal Time and the polar motion matrix).
        /// </summary>
        /// <param name="rbpn">celestial-to-true matrix</param>
        /// <param name="gst">Greenwich (apparent) Sidereal Time (radians)</param>
        /// <param name="rpom">polar-motion matrix</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix</param>
        public static void C2teqx(double[,] rbpn, double gst, double[,] rpom,
            out double[,] rc2t)
        {
            var r = new double[3, 3];

            /* Construct the matrix. */
            Cr(rbpn, ref r);
            Rz(gst, ref r);
            rc2t = new double[3, 3];
            Rxr(rpom, r, ref rc2t);
        }
    }
}
