using static System.Math;

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
        /// In the tangent plane projection, given the star's rectangular
        /// coordinates and the direction cosines of the tangent point, solve
        /// for the direction cosines of the star.
        /// </summary>
        /// <param name="xi">Rectangular coordinates of star image</param>
        /// <param name="eta">Rectangular coordinates of star image</param>
        /// <param name="v0">Direction cosines of the tangent point</param>
        /// <param name="v">Direction cosines of the star</param>
        public static void Tpstv(double xi, double eta, double[] v0, ref double[] v)
        {
            // Tangent point
            var x = v0[0];
            var y = v0[1];
            var z = v0[2];

            // Deal with polar case
            var r = Sqrt(x * x + y * y);
            if (r == 0.0)
            {
                r = 1e-20;
                x = r;
            }

            // Star vector length to tangent plane
            var f = Sqrt(1.0 + xi * xi + eta * eta);

            // Apply the transformation and normalize
            v[0] = (x - (xi * y + eta * x * z) / r) / f;
            v[1] = (y + (xi * x - eta * y * z) / r) / f;
            v[2] = (z + eta * r) / f;
        }
    }
}
