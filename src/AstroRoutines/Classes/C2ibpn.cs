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
        /// Form the celestial-to-intermediate matrix for a given date given the bias-precession-nutation matrix. IAU 2000.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rbpn">celestial-to-true matrix</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2ibpn(double date1, double date2, double[,] rbpn,
            ref double[,] rc2i)
        {
            /* Extract the X,Y coordinates. */
            Bpn2xy(rbpn, out var x, out var y);

            /* Form the celestial-to-intermediate matrix (n.b. IAU 2000 specific). */
            C2ixy(date1, date2, x, y, ref rc2i);
        }
    }
}
