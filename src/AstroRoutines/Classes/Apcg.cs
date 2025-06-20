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
        /// For a geocentric observer, prepare star-independent astrometry parameters for transformations between ICRS and GCRS coordinates.
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="ebpv">Earth barycentric pos/vel (au, au/day)</param>
        /// <param name="ehp">Earth heliocentric position (au)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apcg(double date1, double date2, double[,] ebpv, double[] ehp, ref ASTROM astrom)
        {
            var pv = new double[2, 3];
            for (var i = 0; i < 2; i++)
                for (var j = 0; j < 3; j++)
                    pv[i, j] = 0.0;

            Apcs(date1, date2, pv, ebpv, ehp, ref astrom);
        }
    }
}
