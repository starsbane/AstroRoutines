using static AstroRoutines.Constants;

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
        /// Frame bias and precession, IAU 2006.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rb">frame bias matrix</param>
        /// <param name="rp">precession matrix</param>
        /// <param name="rbp">bias-precession matrix</param>
        public static void Bp06(double date1, double date2,
            out double[,] rb, out double[,] rp, out double[,] rbp)
        {
            var rbpw = new double[3, 3];
            var rbt = new double[3, 3];
            rb = new double[3,3];
            /* B matrix. */
            Pfw06(DJM0, DJM00, out var gamb, out var phib, out var psib, out var epsa);
            Fw2m(gamb, phib, psib, epsa, ref rb);

            /* PxB matrix (temporary). */
            Pmat06(date1, date2, ref rbpw);

            /* P matrix. */
            Tr(rb, ref rbt);
            rp = new double[3, 3];
            Rxr(rbpw, rbt, ref rp);

            /* PxB matrix. */
            rbp = rbpw;
        }
    }
}
