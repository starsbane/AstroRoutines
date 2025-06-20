using static System.Math;
using static AstroRoutines.Constants;

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
        /// Transform geocentric coordinates to geodetic for a reference
        /// ellipsoid of specified form.
        /// </summary>
        /// <param name="a">equatorial radius</param>
        /// <param name="f">flattening</param>
        /// <param name="xyz">geocentric vector</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <returns>status: 0 = OK, -1 = illegal f, -2 = illegal a</returns>
        public static int Gc2gde(double a, double f, double[] xyz, out double elong, out double phi, out double height)
        {
            double p, s0, pn, zc,
                          c0, c02, c03, s02, s03, a02, a0, a03, d0, f0, b0, s1,
                          cc, s12, cc2;
            phi = height = elong = 0;

            /* ------------- */
            /* Preliminaries */
            /* ------------- */

            /* Validate ellipsoid parameters. */
            if (f < 0.0 || f >= 1.0) return -1;
            if (a <= 0.0) return -2;

            /* Functions of ellipsoid parameters (with further validation of f). */
            var aeps2 = a * a * 1e-32;
            var e2 = (2.0 - f) * f;
            var e4t = e2 * e2 * 1.5;
            var ec2 = 1.0 - e2;
            if (ec2 <= 0.0) return -1;
            var ec = Sqrt(ec2);
            var b = a * ec;

            /* Cartesian components. */
            var x = xyz[0];
            var y = xyz[1];
            var z = xyz[2];

            /* Distance from polar axis squared. */
            var p2 = x * x + y * y;

            /* Longitude. */
            elong = p2 > 0.0 ? Atan2(y, x) : 0.0;

            /* Unsigned z-coordinate. */
            var absz = Abs(z);

            /* Proceed unless polar case. */
            if (p2 > aeps2)
            {
                /* Distance from polar axis. */
                p = Sqrt(p2);

                /* Normalization. */
                s0 = absz / a;
                pn = p / a;
                zc = ec * s0;

                /* Prepare Newton correction factors. */
                c0 = ec * pn;
                c02 = c0 * c0;
                c03 = c02 * c0;
                s02 = s0 * s0;
                s03 = s02 * s0;
                a02 = c02 + s02;
                a0 = Sqrt(a02);
                a03 = a02 * a0;
                d0 = zc * a03 + e2 * s03;
                f0 = pn * a03 - e2 * c03;

                /* Prepare Halley correction factor. */
                b0 = e4t * s02 * c02 * pn * (a0 - ec);
                s1 = d0 * f0 - b0 * s0;
                cc = ec * (f0 * f0 - b0 * c0);

                /* Evaluate latitude and height. */
                phi = Atan(s1 / cc);
                s12 = s1 * s1;
                cc2 = cc * cc;
                height = (p * cc + absz * s1 - a * Sqrt(ec2 * s12 + cc2)) /
                                                              Sqrt(s12 + cc2);
            }
            else
            {
                /* Exception: pole. */
                phi = DPI / 2.0;
                height = absz - b;
            }

            /* Restore sign of latitude. */
            if (z < 0) phi = -phi;

            /* OK status. */
            return 0;

            /* Finished. */
        }
    }
}
