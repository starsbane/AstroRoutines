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
        /// Transformation from Galactic coordinates to ICRS.
        /// </summary>
        /// <param name="dl">Galactic longitude</param>
        /// <param name="db">Galactic latitude</param>
        /// <param name="dr">ICRS right ascension</param>
        /// <param name="dd">ICRS declination</param>
        public static void G2icrs(double dl, double db, out double dr, out double dd)
        {
            var v1 = new double[3];
            var v2 = new double[3];

            /*
             **  L2,B2 system of Galactic coordinates in the form presented in the
             **  Hipparcos Catalogue.  In degrees:
             **
             **  P = 192.85948    right ascension of the Galactic north pole in ICRS
             **  Q =  27.12825    declination of the Galactic north pole in ICRS
             **  R =  32.93192    Galactic longitude of the ascending node of
             **                   the Galactic equator on the ICRS equator
             **
             **  ICRS to Galactic rotation matrix, obtained by computing
             **  R_3(-R) R_1(pi/2-Q) R_3(pi/2+P) to the full precision shown:
             */
            var r = new double[,] {
                { -0.054875560416215368492398900454,
                    -0.873437090234885048760383168409,
                    -0.483835015548713226831774175116 },
                { 0.494109427875583673525222371358,
                    -0.444829629960011178146614061616,
                    0.746982244497218890527388004556 },
                { -0.867666149019004701181616534570,
                    -0.198076373431201528180486091412,
                    0.455983776175066922272100478348 }
            };

            /* Spherical to Cartesian. */
            S2c(dl, db, ref v1);

            /* Galactic to ICRS. */
            Trxp(r, v1, ref v2);

            /* Cartesian to spherical. */
            C2s(v2, out dr, out dd);

            /* Express in conventional ranges. */
            dr = Anp(dr);
            dd = Anpm(dd);
        }
    }
}
