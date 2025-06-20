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
		/// Long-term precession matrix, including ICRS frame bias.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="rpb">precession+bias matrix, J2000.0 to date</param>
        public static void Ltpb(double epj, ref double[,] rpb)
        {
            /* Frame bias (IERS Conventions 2010, Eqs. 5.21 and 5.33) */
            const double dx = -0.016617 * DAS2R;
            const double de = -0.0068192 * DAS2R;
            const double dr = -0.0146 * DAS2R;

            int i;
            var rp = new double[3, 3];

            /* Precession matrix. */
            Ltp(epj, ref rp);

            /* Apply the bias. */
            for (i = 0; i < 3; i++)
            {
                rpb[i, 0] = rp[i, 0] - rp[i, 1] * dr + rp[i, 2] * dx;
                rpb[i, 1] = rp[i, 0] * dr + rp[i, 1] + rp[i, 2] * de;
                rpb[i, 2] = -rp[i, 0] * dx - rp[i, 1] * de + rp[i, 2];
            }

            /* Finished. */
        }
    }
}
