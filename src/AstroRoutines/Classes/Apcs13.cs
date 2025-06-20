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
        /// For an observer whose geocentric position and velocity are known, prepare star-independent astrometry parameters for transformations between ICRS and GCRS.
        /// </summary>
        /// <param name="date1">TDB as a 2-part...</param>
        /// <param name="date2">...Julian Date (Note 1)</param>
        /// <param name="pv">observer's geocentric pos/vel (Note 3)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apcs13(double date1, double date2, double[,] pv, ref ASTROM astrom)
        {
            var ehpv = new double[2, 3];
            var ebpv = new double[2, 3];

            /* Earth barycentric & heliocentric position/velocity (au, au/d). */
            Epv00(date1, date2, ref ehpv, ref ebpv);

            /* Compute the star-independent astrometry parameters. */
            var ehp = ehpv.GetRow(0);
            Apcs(date1, date2, pv, ebpv, ehp, ref astrom);

            /* Finished. */
        }
    }
}
