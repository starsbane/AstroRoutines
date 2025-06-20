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
        /// Equation of the origins, given the classical NPB matrix and the
        /// quantity s.
        /// </summary>
        /// <param name="rnpb">classical nutation x precession x bias matrix</param>
        /// <param name="s">the quantity s (the CIO locator) in radians</param>
        /// <returns>the equation of the origins in radians</returns>
        public static double Eors(double[,] rnpb, double s)
        {
            /* Evaluate Wallace & Capitaine (2006) expression (16). */
            var x = rnpb[2, 0];
            var ax = x / (1.0 + rnpb[2, 2]);
            var xs = 1.0 - ax * x;
            var ys = -ax * rnpb[2, 1];
            var zs = -x;
            var p = rnpb[0, 0] * xs + rnpb[0, 1] * ys + rnpb[0, 2] * zs;
            var q = rnpb[1, 0] * xs + rnpb[1, 1] * ys + rnpb[1, 2] * zs;
            var eo = ((p != 0.0) || (q != 0.0)) ? s - Atan2(q, p) : s;

            return eo;

            /* Finished. */
        }
    }
}
