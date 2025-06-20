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
        /// Quick ICRS to CIRS transformation, given precomputed star-independent astrometry parameters, and assuming zero parallax and proper motion.
        /// </summary>
        /// <param name="rc">ICRS RA at J2000.0 (radians)</param>
        /// <param name="dc">ICRS Dec at J2000.0 (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="ri">CIRS RA (radians)</param>
        /// <param name="di">CIRS Dec (radians)</param>
        public static void Atciqz(double rc, double dc, ref ASTROM astrom,
            out double ri, out double di)
        {
            var pco = new double[3];
            var pnat = new double[3];
            var ppr = new double[3];
            var pi = new double[3];

            /* BCRS coordinate direction (unit vector). */
            S2c(rc, dc, ref pco);

            /* Light deflection by the Sun, giving BCRS natural direction. */
            Ldsun(pco, astrom.eh, astrom.em, ref pnat);

            /* Aberration, giving GCRS proper direction. */
            Ab(pnat, astrom.v, astrom.em, astrom.bm1, ref ppr);

            /* Bias-precession-nutation, giving CIRS proper direction. */
            Rxp(astrom.bpn, ppr, ref pi);

            /* CIRS RA,Dec. */
            C2s(pi, out var w, out di);
            ri = Anp(w);
        }
    }
}
