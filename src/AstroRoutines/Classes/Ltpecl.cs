using static System.Math;
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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Long-term precession of the ecliptic.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="vec">ecliptic pole unit vector</param>
        public static void Ltpecl(double epj, ref double[] vec)
        {
            /* Obliquity at J2000.0 (radians). */
            const double eps0 = 84381.406 * DAS2R;

            /* Polynomial coefficients */
            const int NPOL = 4;
            double[,] pqpol = {
                { 5851.607687,
                    -0.1189000,
                    -0.00028913,
                     0.000000101},
                {-1600.886300,
                     1.1689818,
                    -0.00000020,
                    -0.000000437}
            };

            /* Periodic coefficients */
            double[,] pqper = {
                { 708.15,-5486.751211,-684.661560,  667.666730,-5523.863691},
                {2309.00,  -17.127623,2446.283880,-2354.886252, -549.747450},
                {1620.00, -617.517403, 399.671049, -428.152441, -310.998056},
                { 492.20,  413.442940,-356.652376,  376.202861,  421.535876},
                {1183.00,   78.614193,-186.387003,  184.778874,  -36.776172},
                { 622.00, -180.732815,-316.800070,  335.321713, -145.278396},
                { 882.00,  -87.676083, 198.296701, -185.138669,  -34.744450},
                { 547.00,   46.140315, 101.135679, -120.972830,   22.885731}
            };
            var NPER = pqper.GetLength(0);

            /* Miscellaneous */
            int i;
            double a, s, c;

            /* Centuries since J2000. */
            var t = (epj - 2000.0) / 100.0;

            /* Initialize P_A and Q_A accumulators. */
            var p = 0.0;
            var q = 0.0;

            /* Periodic terms. */
            var w = D2PI * t;
            for (i = 0; i < NPER; i++)
            {
                a = w / pqper[i, 0];
                s = Sin(a);
                c = Cos(a);
                p += c * pqper[i, 1] + s * pqper[i, 3];
                q += c * pqper[i, 2] + s * pqper[i, 4];
            }

            /* Polynomial terms. */
            w = 1.0;
            for (i = 0; i < NPOL; i++)
            {
                p += pqpol[0, i] * w;
                q += pqpol[1, i] * w;
                w *= t;
            }

            /* P_A and Q_A (radians). */
            p *= DAS2R;
            q *= DAS2R;

            /* Form the ecliptic pole vector. */
            w = 1.0 - p * p - q * q;
            w = w < 0.0 ? 0.0 : Sqrt(w);
            s = Sin(eps0);
            c = Cos(eps0);
            vec[0] = p;
            vec[1] = -q * c - w * s;
            vec[2] = -q * s + w * c;

            /* Finished. */
        }
    }
}
