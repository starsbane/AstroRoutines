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
		/// Long-term precession matrix.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="rp">precession matrix, J2000.0 to date</param>
        public static void Ltp(double epj, ref double[,] rp)
        {
            int i;
            var peqr = new double[3];
            var pecl = new double[3];
            var v = new double[3];
            double w;

            /* Equator pole (bottom row of matrix). */
            Ltpequ(epj, ref peqr);

            /* Ecliptic pole. */
            Ltpecl(epj, ref pecl);

            /* Equinox (top row of matrix). */
            Pxp(peqr, pecl, ref v);
            Pn(v, out w, out var eqx);

            /* Middle row of matrix. */
            Pxp(peqr, eqx, ref v);

            /* Assemble the matrix. */
            for (i = 0; i < 3; i++)
            {
                rp[0, i] = eqx[i];
                rp[1, i] = v[i];
                rp[2, i] = peqr[i];
            }

            /* Finished. */
        }
    }
}
