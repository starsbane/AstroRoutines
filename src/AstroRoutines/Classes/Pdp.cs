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
		/// p-vector inner (=scalar=dot) product.
		/// </summary>
		/// <param name="a">first p-vector</param>
		/// <param name="b">second p-vector</param>
		/// <returns>a . b</returns>
        public static double Pdp(double[] a, double[] b)
        {
            var w = a[0] * b[0]
                    + a[1] * b[1]
                    + a[2] * b[2];

            return w;

            /* Finished. */
        }
    }
}
