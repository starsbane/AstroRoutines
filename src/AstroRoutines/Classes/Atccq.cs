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
        /// Quick transformation of a star's ICRS catalog entry (epoch J2000.0) into ICRS astrometric place, given precomputed star-independent astrometry parameters.
        /// </summary>
        /// <param name="rc">ICRS right ascension at J2000.0 (radians)</param>
        /// <param name="dc">ICRS declination at J2000.0 (radians)</param>
        /// <param name="pr">RA proper motion (radians/year)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="ra">ICRS astrometric RA (radians)</param>
        /// <param name="da">ICRS astrometric Dec (radians)</param>
        public static void Atccq(double rc, double dc, double pr, double pd, double px, double rv,
                                ref ASTROM astrom, ref double ra, ref double da)
        {
            var pco = new double[3];

            /* Proper motion and parallax, giving BCRS coordinate direction. */
            Pmpx(rc, dc, pr, pd, px, rv, astrom.pmt, astrom.eb, ref pco);

            /* ICRS astrometric RA,Dec to spherical coordinates. */
            C2s(pco, out var w, out da);
            ra = Anp(w);
        }
    }
}
