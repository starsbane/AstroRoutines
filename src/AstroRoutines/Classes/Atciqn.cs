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
        /// Quick ICRS, epoch J2000.0, to CIRS transformation, given precomputed star-independent astrometry parameters plus a list of light-deflecting bodies.
        /// </summary>
        /// <param name="rc">ICRS RA at J2000.0 (radians)</param>
        /// <param name="dc">ICRS Dec at J2000.0 (radians)</param>
        /// <param name="pr">RA proper motion (radians/year)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="n">number of bodies</param>
        /// <param name="b">data for each of the n bodies</param>
        /// <param name="ri">CIRS RA (radians)</param>
        /// <param name="di">CIRS Dec (radians)</param>
        public static void Atciqn(double rc, double dc, double pr, double pd,
            double px, double rv, ref ASTROM astrom,
            int n, LDBODY[] b, out double ri, out double di)
        {
            var pco = new double[3];
            var pnat = new double[3];
            var ppr = new double[3];
            var pi = new double[3];

            /* Proper motion and parallax, giving BCRS coordinate direction. */
            Pmpx(rc, dc, pr, pd, px, rv, astrom.pmt, astrom.eb, ref pco);

            /* Light deflection, giving BCRS natural direction. */
            Ldn(n, b, astrom.eb, pco, ref pnat);

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
