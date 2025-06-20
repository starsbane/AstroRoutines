// Cpv.cs

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
        /// Copy a position/velocity vector.
        /// </summary>
        /// <param name="pv">position/velocity vector to be copied</param>
        /// <param name="c">copy</param>
        public static void Cpv(double[,] pv, double[,] c)
        {
            var p0 = pv.GetRow(0);
            var c0 = new double[3];
            var p1 = pv.GetRow(1);
            var c1 = new double[3];
            
            Cp(p0, ref c0);
            Cp(p1, ref c1);
            
            c[0, 0] = c0[0]; c[0, 1] = c0[1]; c[0, 2] = c0[2];
            c[1, 0] = c1[0]; c[1, 1] = c1[1]; c[1, 2] = c1[2];

            /* Finished. */
        }
    }
}
