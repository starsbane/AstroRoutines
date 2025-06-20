// Ee00b.cs

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
        /// Equation of the equinoxes, compatible with IAU 2000 resolutions but
        /// using the truncated nutation model IAU 2000B.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Ee00b(double date1, double date2)
        {
            double dpsipr, deps;

            /* IAU 2000 precession-rate adjustments. */
            Pr00(date1, date2, out dpsipr, out var depspr);

            /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
            var epsa = Obl80(date1, date2) + depspr;

            /* Nutation in longitude. */
            Nut00b(date1, date2, out var dpsi, out deps);

            /* Equation of the equinoxes. */
            var ee = Ee00(date1, date2, epsa, dpsi);

            return ee;

            /* Finished. */
        }
    }
}
