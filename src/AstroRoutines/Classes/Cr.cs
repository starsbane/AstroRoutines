// Cr.cs

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
        /// Copy an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix to be copied</param>
        /// <param name="c">copy</param>
        public static void Cr(double[,] r, ref double[,] c)
        {
            var r0 = r.GetRow(0);
            var c0 = new double[3];
            Cp(r0, ref c0);
            c.SetRow(0, c0);

            var r1 = r.GetRow(1);
            var c1 = new double[3];
            Cp(r1, ref c1);
            c.SetRow(1, c1);

            var r2 = r.GetRow(2);
            var c2 = new double[3];
            Cp(r2, ref c2);
            c.SetRow(2, c2);
        }
    }
}
