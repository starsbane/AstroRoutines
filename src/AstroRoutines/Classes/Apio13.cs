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
        /// For a terrestrial observer, prepare star-independent astrometry parameters for transformations between CIRS and observed coordinates.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part...</param>
        /// <param name="utc2">...quasi Julian Date (Notes 1,2)</param>
        /// <param name="dut1">UT1-UTC (seconds, Note 3)</param>
        /// <param name="elong">longitude (radians, east +ve, Note 4)</param>
        /// <param name="phi">geodetic latitude (radians, Note 4)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic, Notes 4,6)</param>
        /// <param name="xp">polar motion coordinates (radians, Note 5)</param>
        /// <param name="yp">polar motion coordinates (radians, Note 5)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB, Note 6)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl">wavelength (micrometers, Note 7)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <returns>status: +1 = dubious year (Note 2), 0 = OK, -1 = unacceptable date</returns>
        public static int Apio13(double utc1, double utc2, double dut1,
                                double elong, double phi, double hm, double xp, double yp,
                                double phpa, double tc, double rh, double wl,
                                ref ASTROM astrom)
        {
            double ut11 = 0, ut12 = 0;

            /* UTC to other time scales. */
            var j = Utctai(utc1, utc2, out var tai1, out var tai2);
            if (j < 0) return -1;
            j = Taitt(tai1, tai2, out var tt1, out var tt2);
            j = Utcut1(utc1, utc2, dut1, ref ut11, ref ut12);
            if (j < 0) return -1;

            /* TIO locator s'. */
            var sp = Sp00(tt1, tt2);

            /* Earth rotation angle. */
            var theta = Era00(ut11, ut12);

            /* Refraction constants A and B. */
            Refco(phpa, tc, rh, wl, out var refa, out var refb);

            /* CIRS <-> observed astrometry parameters. */
            Apio(sp, theta, elong, phi, hm, xp, yp, refa, refb, ref astrom);

            /* Return any warning status. */
            return j;

            /* Finished. */
        }
    }
}
