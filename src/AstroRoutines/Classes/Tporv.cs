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
        /// In the tangent plane projection, given the rectangular coordinates of a star and its direction cosines, determine the direction cosines of the tangent point.
        /// </summary>
        /// <param name="xi">rectangular coordinates of star image</param>
        /// <param name="eta">rectangular coordinates of star image</param>
        /// <param name="v">star's direction cosines</param>
        /// <param name="v01">tangent point's direction cosines, Solution 1</param>
        /// <param name="v02">tangent point's direction cosines, Solution 2</param>
        /// <returns>number of solutions: 0 = no solutions returned (Note 5), 1 = only the first solution is useful (Note 6), 2 = both solutions are useful (Note 6)</returns>
        public static int Tporv(double xi, double eta, double[] v, ref double[] v01, ref double[] v02)
        {
            var x = v[0];
            var y = v[1];
            var z = v[2];
            var rxy2 = x * x + y * y;
            var xi2 = xi * xi;
            var eta2p1 = eta * eta + 1.0;
            var r = Sqrt(xi2 + eta2p1);
            var rsb = r * z;
            var rcb = r * Sqrt(rxy2);
            var w2 = rcb * rcb - xi2;

            if (w2 > 0.0)
            {
                var w = Sqrt(w2);
                var c_val = (rsb * eta + w) / (eta2p1 * Sqrt(rxy2 * (w2 + xi2)));
                v01[0] = c_val * (x * w + y * xi);
                v01[1] = c_val * (y * w - x * xi);
                v01[2] = (rsb - eta * w) / eta2p1;
                w = -w;
                c_val = (rsb * eta + w) / (eta2p1 * Sqrt(rxy2 * (w2 + xi2)));
                v02[0] = c_val * (x * w + y * xi);
                v02[1] = c_val * (y * w - x * xi);
                v02[2] = (rsb - eta * w) / eta2p1;
                return (Abs(rsb) < 1.0) ? 1 : 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
