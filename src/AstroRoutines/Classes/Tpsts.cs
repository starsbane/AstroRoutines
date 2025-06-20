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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the tangent plane projection, given the star's rectangular
        /// coordinates and the spherical coordinates of the tangent point,
        /// solve for the spherical coordinates of the star.
        /// </summary>
        /// <param name="xi">Rectangular coordinates of star image</param>
        /// <param name="eta">Rectangular coordinates of star image</param>
        /// <param name="a0">Tangent point's spherical coordinates</param>
        /// <param name="b0">Tangent point's spherical coordinates</param>
        /// <param name="a">Star's spherical coordinates</param>
        /// <param name="b">Star's spherical coordinates</param>
        public static void Tpsts(double xi, double eta, double a0, double b0, 
                                 ref double a, ref double b)
        {
            var sb0 = Sin(b0);
            var cb0 = Cos(b0);
            var d = cb0 - eta * sb0;
            a = Anp(Atan2(xi, d) + a0);
            b = Atan2(sb0 + eta * cb0, Sqrt(xi * xi + d * d));
        }
    }
}
