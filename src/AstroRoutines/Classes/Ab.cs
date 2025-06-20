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
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Apply aberration to transform natural direction into proper direction.
        /// </summary>
        /// <param name="pnat">natural direction to the source (unit vector)</param>
        /// <param name="v">observer barycentric velocity in units of c</param>
        /// <param name="s">distance between the Sun and the observer (au)</param>
        /// <param name="bm1">sqrt(1-|v|^2): reciprocal of Lorenz factor</param>
        /// <param name="ppr">proper direction to source (unit vector)</param>
        public static void Ab(double[] pnat, double[] v, double s, double bm1, ref double[] ppr)
        {
            var pdv = Pdp(pnat, v);
            var w1 = 1.0 + pdv / (1.0 + bm1);
            var w2 = SRS / s;
            var r2 = 0.0;
            var p = new double[3];

            for (var i = 0; i < 3; i++)
            {
                var w = pnat[i] * bm1 + w1 * v[i] + w2 * (v[i] - pdv * pnat[i]);
                p[i] = w;
                r2 += w * w;
            }

            var r = Sqrt(r2);
            for (var i = 0; i < 3; i++)
            {
                ppr[i] = p[i] / r;
            }
        }
    }
}
