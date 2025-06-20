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
        /// Transform geocentric coordinates to geodetic using the specified
        /// reference ellipsoid.
        /// </summary>
        /// <param name="n">ellipsoid identifier</param>
        /// <param name="xyz">geocentric vector</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <returns>status: 0 = OK, -1 = illegal identifier, -2 = internal error</returns>
        public static int Gc2gd(int n, double[] xyz, out double elong, out double phi, out double height)
        {
            phi = 0;
            height = 0;
            elong = 0;

            /* Obtain reference ellipsoid parameters. */
            var j = Eform(n, out var a, out var f);

            /* If OK, transform x,y,z to longitude, geodetic latitude, height. */
            if (j == 0)
            {
                j = Gc2gde(a, f, xyz, out elong, out phi, out height);
                if (j < 0) j = -2;
            }

            /* Deal with any errors. */
            if (j < 0)
            {
                elong = -1e9;
                phi = -1e9;
                height = -1e9;
            }

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
