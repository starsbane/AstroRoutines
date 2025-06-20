// Eqec06.cs

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
        /// Transformation from ICRS equatorial coordinates to ecliptic
        /// coordinates (mean equinox and ecliptic of date) using IAU 2006
        /// precession model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="dr">ICRS right ascension and declination (radians)</param>
        /// <param name="dd">ICRS right ascension and declination (radians)</param>
        /// <param name="dl">ecliptic longitude and latitude (radians)</param>
        /// <param name="db">ecliptic longitude and latitude (radians)</param>
        public static void Eqec06(double date1, double date2, double dr, double dd,
                       ref double dl, ref double db)
        {
            var rm = new double[3, 3];
            var v1 = new double[3];
            var v2 = new double[3];

            /* Spherical to Cartesian. */
            S2c(dr, dd, ref v1);

            /* Rotation matrix, ICRS equatorial to ecliptic. */
            Ecm06(date1, date2, ref rm);

            /* The transformation from ICRS to ecliptic. */
            Rxp(rm, v1, ref v2);

            /* Cartesian to spherical. */
            C2s(v2, out var a, out var b);

            /* Express in conventional ranges. */
            dl = Anp(a);
            db = Anpm(b);

            /* Finished. */
        }
    }
}
