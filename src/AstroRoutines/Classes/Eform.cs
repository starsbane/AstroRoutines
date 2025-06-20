// Eform.cs

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
        /// Earth reference ellipsoids.
        /// </summary>
        /// <param name="n">ellipsoid identifier (Note 1)</param>
        /// <param name="a">equatorial radius (meters, Note 2)</param>
        /// <param name="f">flattening (Note 2)</param>
        /// <returns>status:  0 = OK
        /// -1 = illegal identifier (Note 3)</returns>
        public static int Eform(int n, out double a, out double f)
        {
            /* Look up a and f for the specified reference ellipsoid. */
            switch (n)
            {
                case WGS84:
                    a = 6378137.0;
                    f = 1.0 / 298.257223563;
                    break;

                case GRS80:
                    a = 6378137.0;
                    f = 1.0 / 298.257222101;
                    break;

                case WGS72:
                    a = 6378135.0;
                    f = 1.0 / 298.26;
                    break;

                default:
                    /* Invalid identifier. */
                    a = 0.0;
                    f = 0.0;
                    return -1;
            }

            /* OK status. */
            return 0;

            /* Finished. */
        }
    }
}
