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
        /// Transform geodetic coordinates to geocentric using the specified
        /// reference ellipsoid.
        /// </summary>
        /// <param name="n">ellipsoid identifier</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <param name="xyz">geocentric vector</param>
        /// <returns>status: 0 = OK, -1 = illegal identifier, -2 = illegal case</returns>
        public static int Gd2gc(int n, double elong, double phi, double height, out double[] xyz)
        {
            xyz = new double[3];

            /* Obtain reference ellipsoid parameters. */
            var j = Eform(n, out var a, out var f);

            /* If OK, transform longitude, geodetic latitude, height to x,y,z. */
            if (j == 0)
            {
                j = Gd2gce(a, f, elong, phi, height, out xyz);
                if (j != 0) j = -2;
            }

            /* Deal with any errors. */
            if (j != 0) Zp(ref xyz);

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
