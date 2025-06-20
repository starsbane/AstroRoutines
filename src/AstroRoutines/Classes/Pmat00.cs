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
		/// Precession matrix (including frame bias) from GCRS to a specified
		/// date, IAU 2000 model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="rbp">bias-precession matrix (Note 2)</param>
        public static void Pmat00(double date1, double date2, ref double[,] rbp)
        {
            var rb = new double[3, 3];
            var rp = new double[3, 3];

            /* Obtain the required matrix (discarding others). */
            Bp00(date1, date2, out rb, out rp, out rbp);

            /* Finished. */
        }
    }
}
