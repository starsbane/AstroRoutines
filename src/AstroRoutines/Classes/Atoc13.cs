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
        /// Observed place at a groundbased site to to ICRS astrometric RA,Dec. The caller supplies UTC, site coordinates, ambient air conditions and observing wavelength.
        /// </summary>
        /// <param name="type">type of coordinates - "R", "H" or "A"</param>
        /// <param name="ob1">observed Az, HA or RA (radians; Az is N=0,E=90)</param>
        /// <param name="ob2">observed ZD or Dec (radians)</param>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">UT1-UTC (seconds)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic)</param>
        /// <param name="xp">polar motion coordinates (radians)</param>
        /// <param name="yp">polar motion coordinates (radians)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl">wavelength (micrometers)</param>
        /// <param name="rc">ICRS astrometric RA (radians)</param>
        /// <param name="dc">ICRS astrometric Dec (radians)</param>
        /// <returns>status: +1 = dubious year, 0 = OK, -1 = unacceptable date</returns>
        public static int Atoc13(string type, double ob1, double ob2,
            double utc1, double utc2, double dut1,
            double elong, double phi, double hm, double xp, double yp,
            double phpa, double tc, double rh, double wl,
            out double rc, out double dc)
        {
            var astrom = new ASTROM();
            double eo = 0;

            /* Star-independent astrometry parameters. */
            var j = Apco13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                phpa, tc, rh, wl, ref astrom, ref eo);

            /* Abort if bad UTC. */
            if (j < 0)
            {
                rc = dc = 0;
                return j;
            }

            /* Transform observed to CIRS. */
            Atoiq(type, ob1, ob2, ref astrom, out var ri, out var di);

            /* Transform CIRS to ICRS. */
            Aticq(ri, di, ref astrom, out rc, out dc);

            /* Return OK/warning status. */
            return j;
        }
    }
}
