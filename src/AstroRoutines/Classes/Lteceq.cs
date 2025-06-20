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
        /// Transformation from ecliptic coordinates (mean equinox and ecliptic
        /// of date) to ICRS RA,Dec, using a long-term precession model.
        /// </summary>
        /// <param name="epj">Julian epoch (TT)</param>
        /// <param name="dl">ecliptic longitude (radians)</param>
        /// <param name="db">ecliptic latitude (radians)</param>
        /// <param name="dr">ICRS right ascension (radians)</param>
        /// <param name="dd">ICRS declination (radians)</param>
        public static void Lteceq(double epj, double dl, double db, ref double dr, ref double dd)
        {
            var rm = new double[3, 3];
            var v1 = new double[3];
            var v2 = new double[3];

            /* Spherical to Cartesian. */
            S2c(dl, db, ref v1);

            /* Rotation matrix, ICRS equatorial to ecliptic. */
            Ltecm(epj, rm);

            /* The transformation from ecliptic to ICRS. */
            Trxp(rm, v1, ref v2);

            /* Cartesian to spherical. */
            C2s(v2, out var a, out var b);

            /* Express in conventional ranges. */
            dr = Anp(a);
            dd = Anpm(b);

            /* Finished. */
        }
    }
}
