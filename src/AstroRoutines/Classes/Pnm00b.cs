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
        /// Forms the matrix of precession-nutation for a given date using IAU 2000B model.
        /// </summary>
        /// <remarks>
        /// Generates a bias-precession-nutation matrix for coordinate transformations.
        /// 
        /// Key characteristics:
        /// - Includes frame bias
        /// - Uses equinox-based IAU 2000B model
        /// - Provides a faster (but slightly less accurate) alternative to IAU 2000A model
        /// 
        /// The matrix transforms vectors from the Geocentric Celestial 
        /// Reference System (GCRS) to the true equatorial triad of the specified date.
        /// 
        /// Approximately 1 milliarcsecond less accurate compared to IAU 2000A model.
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="rbpn">Bias-precession-nutation matrix (output)</param>
        public static void Pnm00b(double date1, double date2, ref double[,] rbpn)
        {
            double dpsi, deps, epsa;
            var rb = new double[3, 3];
            var rp = new double[3, 3];
            var rbp = new double[3, 3];
            var rn = new double[3, 3];

            /* Obtain the required matrix (discarding other results). */
            Pn00b(date1, date2, out dpsi, out deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);
        }
    }
}
