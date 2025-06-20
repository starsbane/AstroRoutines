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
        /// The CIO locator s, positioning the Celestial Intermediate Origin on the equator of the Celestial Intermediate Pole.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <returns>The CIO locator s in radians</returns>
        public static double S06a(double date1, double date2)
        {
            var rnpb = new double[3, 3];

            /* Bias-precession-nutation-matrix, IAU 2006/2000A. */
            Pnm06a(date1, date2, ref rnpb);

            /* Extract the CIP coordinates. */
            Bpn2xy(rnpb, out var x, out var y);

            /* Compute the CIO locator s, given the CIP coordinates. */
            var s = S06(date1, date2, x, y);

            return s;
        }
    }
}
