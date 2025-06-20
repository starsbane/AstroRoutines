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
		/// Precession matrix from J2000.0 to a specified date, IAU 1976 model.
		/// </summary>
		/// <param name="date1">ending date, TT (Note 1)</param>
		/// <param name="date2">ending date, TT (Note 1)</param>
		/// <param name="rmatp">precession matrix, J2000.0 -> date1+date2</param>
        public static void Pmat76(double date1, double date2, ref double[,] rmatp)
        {
            var wmat = new double[3, 3];

            /* Precession Euler angles, J2000.0 to specified date. */
            Prec76(DJ00, 0.0, date1, date2, out var zeta, out var z, out var theta);

            /* Form the rotation matrix. */
            Ir(ref wmat);
            Rz(-zeta, ref wmat);
            Ry(theta, ref wmat);
            Rz(-z, ref wmat);
            Cr(wmat, ref rmatp);

            /* Finished. */
        }
    }
}
