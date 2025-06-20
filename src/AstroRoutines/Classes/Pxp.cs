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
        /// P-vector outer (vector/cross) product.
        /// </summary>
        /// <param name="a">First p-vector</param>
        /// <param name="b">Second p-vector</param>
        /// <param name="axb">Result of a x b</param>
        public static void Pxp(double[] a, double[] b, ref double[] axb)
        {
            var xa = a[0];
            var ya = a[1];
            var za = a[2];
            var xb = b[0];
            var yb = b[1];
            var zb = b[2];
            axb[0] = ya*zb - za*yb;
            axb[1] = za*xb - xa*zb;
            axb[2] = xa*yb - ya*xb;
        }
    }
}
