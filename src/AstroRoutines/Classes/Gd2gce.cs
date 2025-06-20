using static System.Math;

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
        /// Transform geodetic coordinates to geocentric for a reference
        /// ellipsoid of specified form.
        /// </summary>
        /// <param name="a">equatorial radius</param>
        /// <param name="f">flattening</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <param name="xyz">geocentric vector</param>
        /// <returns>status: 0 = OK, -1 = illegal case</returns>
        public static int Gd2gce(double a, double f, double elong, double phi, double height, out double[] xyz)
        {
            xyz = new double[3];

            /* Functions of geodetic latitude. */
            var sp = Sin(phi);
            var cp = Cos(phi);
            var w = 1.0 - f;
            w = w * w;
            var d = cp * cp + w * sp * sp;
            if (d <= 0.0) return -1;
            var ac = a / Sqrt(d);
            var _as = w * ac;

            /* Geocentric vector. */
            var r = (ac + height) * cp;
            xyz[0] = r * Cos(elong);
            xyz[1] = r * Sin(elong);
            xyz[2] = (_as + height) * sp;

            /* Success. */
            return 0;

            /* Finished. */
        }
    }
}
