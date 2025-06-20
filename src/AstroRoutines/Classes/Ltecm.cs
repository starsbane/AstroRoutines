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
        /// ICRS equatorial to ecliptic rotation matrix, long-term.
        /// </summary>
        /// <param name="epj">Julian epoch (TT)</param>
        /// <param name="rm">ICRS to ecliptic rotation matrix</param>
        public static void Ltecm(double epj, double[,] rm)
        {
            /* Frame bias (IERS Conventions 2010, Eqs. 5.21 and 5.33) */
            const double dx = -0.016617 * DAS2R;
            const double de = -0.0068192 * DAS2R;
            const double dr = -0.0146 * DAS2R;

            var p = new double[3];
            var z = new double[3];
            var w = new double[3];
            double s;
            var y = new double[3];

            /* Equator pole. */
            Ltpequ(epj, ref p);

            /* Ecliptic pole (bottom row of equatorial to ecliptic matrix). */
            Ltpecl(epj, ref z);

            /* Equinox (top row of matrix). */
            Pxp(p, z, ref w);
            Pn(w, out s, out var x);

            /* Middle row of matrix. */
            Pxp(z, x, ref y);

            /* Combine with frame bias. */
            rm[0, 0] = x[0] - x[1] * dr + x[2] * dx;
            rm[0, 1] = x[0] * dr + x[1] + x[2] * de;
            rm[0, 2] = -x[0] * dx - x[1] * de + x[2];
            rm[1, 0] = y[0] - y[1] * dr + y[2] * dx;
            rm[1, 1] = y[0] * dr + y[1] + y[2] * de;
            rm[1, 2] = -y[0] * dx - y[1] * de + y[2];
            rm[2, 0] = z[0] - z[1] * dr + z[2] * dx;
            rm[2, 1] = z[0] * dr + z[1] + z[2] * de;
            rm[2, 2] = -z[0] * dx - z[1] * de + z[2];

            /* Finished. */
        }
    }
}
