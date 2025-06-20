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
        /// Form the celestial-to-intermediate matrix for a given date using the IAU 2000A precession-nutation model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2i00a(double date1, double date2, ref double[,] rc2i)
        {
            /* Obtain the celestial-to-true matrix (IAU 2000A). */
            Pnm00a(date1, date2, out var rbpn);

            /* Form the celestial-to-intermediate matrix. */
            C2ibpn(date1, date2, rbpn, ref rc2i);
        }
    }
}
