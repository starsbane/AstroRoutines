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
		/// Form the matrix of nutation.
		/// </summary>
		/// <param name="epsa">mean obliquity of date (Note 1)</param>
		/// <param name="dpsi">nutation in longitude (Note 2)</param>
		/// <param name="deps">nutation in obliquity (Note 2)</param>
		/// <param name="rmatn">nutation matrix (Note 3)</param>
        public static void Numat(double epsa, double dpsi, double deps, out double[,] rmatn)
        {
            /* Build the rotation matrix. */
            rmatn = new double[3, 3];
            Ir(ref rmatn);
            Rx(epsa, ref rmatn);
            Rz(-dpsi, ref rmatn);
            Rx(-(epsa + deps), ref rmatn);

            /* Finished. */
        }
    }
}
