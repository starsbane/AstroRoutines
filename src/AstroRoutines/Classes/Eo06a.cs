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
        /// Equation of the origins, IAU 2006 precession and IAU 2000A nutation.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>the equation of the origins in radians</returns>
        public static double Eo06a(double date1, double date2)
        {
            var r = new double[3, 3];

            /* Classical nutation x precession x bias matrix. */
            Pnm06a(date1, date2, ref r);

            /* Extract CIP coordinates. */
            Bpn2xy(r, out var x, out var y);

            /* The CIO locator, s. */
            var s = S06(date1, date2, x, y);

            /* Solve for the EO. */
            var eo = Eors(r, s);

            return eo;

            /* Finished. */
        }
    }
}
