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
        /// Convert a p-vector into modulus and unit vector.
        /// </summary>
        /// <param name="p">p-vector</param>
        /// <param name="r">modulus</param>
        /// <param name="u">unit vector</param>
        public static void Pn(double[] p, out double r, out double[] u)
        {
            /* Obtain the modulus and test for zero. */
            var w = Pm(p);
            u = new double[3];

            if (w == 0.0)
            {
                /* Null vector. */
                Zp(ref u);
            }
            else
            {
                /* Unit vector. */
                Sxp(1.0 / w, p, ref u);
            }

            /* Return the modulus. */
            r = w;
        }
    }
}
