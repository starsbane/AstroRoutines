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
        /// Precession-nutation, IAU 2006/2000A models: a multi-purpose function,
        /// supporting classical (equinox-based) use directly and CIO-based use
        /// indirectly.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="dpsi">Nutation (Note 2)</param>
        /// <param name="deps">Nutation (Note 2)</param>
        /// <param name="epsa">Mean obliquity (Note 3)</param>
        /// <param name="rb">Frame bias matrix (Note 4)</param>
        /// <param name="rp">Precession matrix (Note 5)</param>
        /// <param name="rbp">Bias-precession matrix (Note 6)</param>
        /// <param name="rn">Nutation matrix (Note 7)</param>
        /// <param name="rbpn">GCRS-to-true matrix (Notes 8,9)</param>
        public static void Pn06a(
            double date1, double date2,
            out double dpsi, out double deps, out double epsa,
            out double[,] rb, out double[,] rp, out double[,] rbp,
            out double[,] rn, out double[,] rbpn)
        {
            /* Nutation. */
            Nut06a(date1, date2, out dpsi, out deps);

            /* Remaining results. */
            Pn06(date1, date2, dpsi, deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);
        }
    }
}
