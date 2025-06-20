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
        /// Compute the X,Y coordinates of the Celestial Intermediate Pole 
        /// and the CIO locator s, using the IAU 2000B precession-nutation model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="x">Celestial Intermediate Pole X coordinate</param>
        /// <param name="y">Celestial Intermediate Pole Y coordinate</param>
        /// <param name="s">CIO locator s in radians</param>
        public static void Xys00b(double date1, double date2, 
                                  ref double x, ref double y, ref double s)
        {
            var rbpn = new double[3, 3];

            // Form the bias-precession-nutation matrix, IAU 2000B
            Pnm00b(date1, date2, ref rbpn);

            // Extract X,Y
            Bpn2xy(rbpn, out x, out y);

            // Obtain s
            s = S00(date1, date2, x, y);
        }
    }
}
