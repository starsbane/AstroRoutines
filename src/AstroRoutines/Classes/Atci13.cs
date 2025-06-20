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
		/// Transform ICRS star data, epoch J2000.0, to CIRS.
		/// </summary>
		/// <param name="rc">ICRS right ascension at J2000.0 (radians)</param>
		/// <param name="dc">ICRS declination at J2000.0 (radians)</param>
		/// <param name="pr">RA proper motion (radians/year)</param>
		/// <param name="pd">Dec proper motion (radians/year)</param>
		/// <param name="px">parallax (arcsec)</param>
		/// <param name="rv">radial velocity (km/s, +ve if receding)</param>
		/// <param name="date1">TDB as a 2-part Julian Date</param>
		/// <param name="date2">TDB as a 2-part Julian Date</param>
		/// <param name="ri">CIRS geocentric RA (radians)</param>
		/// <param name="di">CIRS geocentric Dec (radians)</param>
		/// <param name="eo">equation of the origins (ERA-GST, radians)</param>
        public static void Atci13(double rc, double dc, double pr, double pd, double px, double rv,
                                  double date1, double date2,
                                  ref double ri, ref double di, ref double eo)
        {
            /* Star-independent astrometry parameters */
            var astrom = new ASTROM();

            /* The transformation parameters. */
            Apci13(date1, date2, ref astrom, out eo);

            /* ICRS (epoch J2000.0) to CIRS. */
            Atciq(rc, dc, pr, pd, px, rv, ref astrom, out ri, out di);
        }
    }
}
