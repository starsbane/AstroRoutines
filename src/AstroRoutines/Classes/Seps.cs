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
        /// Angular separation between two sets of spherical coordinates.
        /// </summary>
        /// <param name="al">first longitude (radians)</param>
        /// <param name="ap">first latitude (radians)</param>
        /// <param name="bl">second longitude (radians)</param>
        /// <param name="bp">second latitude (radians)</param>
        /// <returns>Angular separation (radians)</returns>
        public static double Seps(double al, double ap, double bl, double bp)
        {
            var ac = new double[3];
            var bc = new double[3];

            /* Spherical to Cartesian. */
            S2c(al, ap, ref ac);
            S2c(bl, bp, ref bc);

            /* Angle between the vectors. */
            var s = Sepp(ac, bc);

            return s;
        }
    }
}
