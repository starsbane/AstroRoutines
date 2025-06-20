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
        /// Precession-nutation calculation using IAU 2000 model.
        /// </summary>
        /// <remarks>
        /// Computes precession and nutation matrices, mean obliquity, and related parameters
        /// using the IAU 2000 model.
        /// 
        /// This method provides comprehensive celestial coordinate transformation matrices:
        /// - Frame bias matrix
        /// - Precession matrix
        /// - Bias-precession matrix
        /// - Nutation matrix
        /// - Combined bias-precession-nutation matrix
        /// 
        /// Includes precession-rate adjustments and consistent mean obliquity calculations.
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="dpsi">Nutation in longitude (radians)</param>
        /// <param name="deps">Nutation in obliquity (radians)</param>
        /// <param name="epsa">Mean obliquity of date (output, radians)</param>
        /// <param name="rb">Frame bias matrix (output)</param>
        /// <param name="rp">Precession matrix (output)</param>
        /// <param name="rbp">Bias-precession matrix (output)</param>
        /// <param name="rn">Nutation matrix (output)</param>
        /// <param name="rbpn">Bias-precession-nutation matrix (output)</param>
        public static void Pn00(double date1, double date2, double dpsi, double deps,
                                out double epsa,
                                out double[,] rb, out double[,] rp, out double[,] rbp,
                                out double[,] rn, out double[,] rbpn)
        {
            double dpsipr;
            rbp = new double[3, 3];
            rn = new double[3, 3];

            /* IAU 2000 precession-rate adjustments. */
            Pr00(date1, date2, out dpsipr, out var depspr);

            /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
            epsa = Obl80(date1, date2) + depspr;

            /* Frame bias and precession matrices and their product. */
            Bp00(date1, date2, out rb, out rp, out var rbpw);
            Cr(rbpw, ref rbp);

            /* Nutation matrix. */
            Numat(epsa, dpsi, deps, out var rnw);
            Cr(rnw, ref rn);

            rbpn = new double[3, 3];
            /* Bias-precession-nutation matrix (classical). */
            Rxr(rnw, rbpw, ref rbpn);
        }
    }
}
