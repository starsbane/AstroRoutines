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
        /// ICRS equatorial to ecliptic rotation matrix, IAU 2006.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="rm">ICRS to ecliptic rotation matrix</param>
        public static void Ecm06(double date1, double date2, ref double[,] rm)
        {
            var bp = new double[3, 3];
            var e = new double[3, 3];

            /* Obliquity, IAU 2006. */
            var ob = Obl06(date1, date2);

            /* Precession-bias matrix, IAU 2006. */
            Pmat06(date1, date2, ref bp);

            /* Equatorial of date to ecliptic matrix. */
            Ir(ref e);
            Rx(ob, ref e);

            /* ICRS to ecliptic coordinates rotation matrix, IAU 2006. */
            Rxr(e, bp, ref rm);

            /* Finished. */
        }
    }
}
