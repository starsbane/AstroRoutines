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
        /// Star proper motion: update star catalog data for space motion, with special handling to handle the zero parallax case.
        /// </summary>
        /// <param name="ra1">right ascension (radians), before</param>
        /// <param name="dec1">declination (radians), before</param>
        /// <param name="pmr1">RA proper motion (radians/year), before</param>
        /// <param name="pmd1">Dec proper motion (radians/year), before</param>
        /// <param name="px1">parallax (arcseconds), before</param>
        /// <param name="rv1">radial velocity (km/s, +ve = receding), before</param>
        /// <param name="ep1a">"before" epoch, part A (Note 1)</param>
        /// <param name="ep1b">"before" epoch, part B (Note 1)</param>
        /// <param name="ep2a">"after" epoch, part A (Note 1)</param>
        /// <param name="ep2b">"after" epoch, part B (Note 1)</param>
        /// <param name="ra2">right ascension (radians), after</param>
        /// <param name="dec2">declination (radians), after</param>
        /// <param name="pmr2">RA proper motion (radians/year), after</param>
        /// <param name="pmd2">Dec proper motion (radians/year), after</param>
        /// <param name="px2">parallax (arcseconds), after</param>
        /// <param name="rv2">radial velocity (km/s, +ve = receding), after</param>
        /// <returns>status code</returns>
        public static int Pmsafe(double ra1, double dec1, double pmr1, double pmd1,
                                 double px1, double rv1,
                                 double ep1a, double ep1b, double ep2a, double ep2b,
                                 ref double ra2, ref double dec2, ref double pmr2, ref double pmd2,
                                 ref double px2, ref double rv2)
        {
            /* Minimum allowed parallax (arcsec) */
            const double PXMIN = 5e-7;

            /* Factor giving maximum allowed transverse speed of about 1% c */
            const double F = 326.0;

            /* Proper motion in one year (radians). */
            var pm = Seps(ra1, dec1, ra1 + pmr1, dec1 + pmd1);

            /* Override the parallax to reduce the chances of a warning status. */
            var jpx = 0;
            var px1a = px1;
            pm *= F;
            if (px1a < pm) { jpx = 1; px1a = pm; }
            if (px1a < PXMIN) { jpx = 1; px1a = PXMIN; }

            /* Carry out the transformation using the modified parallax. */
            var j = Starpm(ra1, dec1, pmr1, pmd1, px1a, rv1,
                ep1a, ep1b, ep2a, ep2b,
                out ra2, out dec2, out pmr2, out pmd2, out px2, out rv2);

            /* Revise and return the status. */
            if ((j % 2) == 0) j += jpx;
            return j;
        }
    }
}
