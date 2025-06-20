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
        /// In the tangent plane projection, given the rectangular coordinates of a star and its spherical coordinates, determine the spherical coordinates of the tangent point.
        /// </summary>
        /// <param name="xi">rectangular coordinates of star image</param>
        /// <param name="eta">rectangular coordinates of star image</param>
        /// <param name="a">star's spherical coordinates</param>
        /// <param name="b">star's spherical coordinates</param>
        /// <param name="a01">tangent point's spherical coordinates, Soln. 1</param>
        /// <param name="b01">tangent point's spherical coordinates, Soln. 1</param>
        /// <param name="a02">tangent point's spherical coordinates, Soln. 2</param>
        /// <param name="b02">tangent point's spherical coordinates, Soln. 2</param>
        /// <returns>number of solutions: 0 = no solutions returned (Note 5), 1 = only the first solution is useful (Note 6), 2 = both solutions are useful (Note 6)</returns>
        public static int Tpors(double xi, double eta, double a, double b, out double a01, out double b01, out double a02, out double b02)
        {
            a01 = 0; b01 = 0; a02 = 0; b02 = 0;
            var xi2 = xi * xi;
            var r = Sqrt(1.0 + xi2 + eta * eta);
            var sb = Sin(b);
            var cb = Cos(b);
            var rsb = r * sb;
            var rcb = r * cb;
            var w2 = rcb * rcb - xi2;

            if (w2 >= 0.0)
            {
                var w = Sqrt(w2);
                var s = rsb - eta * w;
                var c = rsb * eta + w;
                if (xi == 0.0 && w == 0.0) w = 1.0;
                a01 = Anp(a - Atan2(xi, w));
                b01 = Atan2(s, c);
                w = -w;
                s = rsb - eta * w;
                c = rsb * eta + w;
                a02 = Anp(a - Atan2(xi, w));
                b02 = Atan2(s, c);
                return (Abs(rsb) < 1.0) ? 1 : 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
