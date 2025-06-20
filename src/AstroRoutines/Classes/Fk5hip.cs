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
        /// FK5 to Hipparcos rotation and spin.
        /// </summary>
        /// <param name="r5h">r-matrix: FK5 rotation wrt Hipparcos</param>
        /// <param name="s5h">r-vector: FK5 spin wrt Hipparcos</param>
        public static void Fk5hip(out double[,] r5h, out double[] s5h)
        {
            var v = new double[3];
            r5h = new double[3, 3];

            /* FK5 wrt Hipparcos orientation and spin (radians, radians/year) */

            var epx = -19.9e-3 * DAS2R;
            var epy = -9.1e-3 * DAS2R;
            var epz = 22.9e-3 * DAS2R;

            var omx = -0.30e-3 * DAS2R;
            var omy = 0.60e-3 * DAS2R;
            var omz = 0.70e-3 * DAS2R;

            /* FK5 to Hipparcos orientation expressed as an r-vector. */
            v[0] = epx;
            v[1] = epy;
            v[2] = epz;

            /* Re-express as an r-matrix. */
            Rv2m(v, ref r5h);

            /* Hipparcos wrt FK5 spin expressed as an r-vector. */
            s5h = new double[] { omx, omy, omz };
        }
    }
}
