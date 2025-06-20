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
        /// Form the matrix of precession/nutation for a given date, IAU 1976
        /// precession model, IAU 1980 nutation model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="rmatpn">Combined precession/nutation matrix</param>
        public static void Pnm80(double date1, double date2, out double[,] rmatpn)
        {
            var rmatp = new double[3, 3];

            // Precession matrix, J2000.0 to date
            Pmat76(date1, date2, ref rmatp);

            // Nutation matrix
            Nutm80(date1, date2, out var rmatn);

            // Combine the matrices: PN = N x P
            rmatpn = new double[3, 3];
            Rxr(rmatn, rmatp, ref rmatpn);
        }
    }
}
