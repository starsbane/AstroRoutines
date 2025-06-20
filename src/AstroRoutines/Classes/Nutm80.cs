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
		/// Form the matrix of nutation for a given date, IAU 1980 model.
		/// </summary>
		/// <param name="date1">TDB date (Note 1)</param>
		/// <param name="date2">TDB date (Note 1)</param>
		/// <param name="rmatn">nutation matrix</param>
        public static void Nutm80(double date1, double date2, out double[,] rmatn)
        {
            /* Nutation components and mean obliquity. */
            Nut80(date1, date2, out var dpsi, out var deps);
            var epsa = Obl80(date1, date2);

            /* Build the rotation matrix. */
            Numat(epsa, dpsi, deps, out rmatn);

            /* Finished. */
        }
    }
}
