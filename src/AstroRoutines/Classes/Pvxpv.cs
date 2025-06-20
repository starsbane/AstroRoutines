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
        /// Outer (vector/cross) product of two pv-vectors.
        /// </summary>
        /// <param name="a">First PV-vector</param>
        /// <param name="b">Second PV-vector</param>
        /// <param name="axb">Result of a x b</param>
        public static void Pvxpv(double[,] a, double[,] b, double[,] axb)
        {
            var wa = new double[2,3];
            var wb = new double[2,3];
            var axbd = new double[3];
            var adxb = new double[3];

            // Make copies of the inputs
            Cpv(a, wa);
            Cpv(b, wb);

            // a x b = position part of result
            var axbRow0 = new double[3];
            Pxp(wa.GetRow(0), wb.GetRow(0), ref axbRow0);
            axb.SetRow(0, axbRow0);

            // a x bdot + adot x b = velocity part of result
            Pxp(wa.GetRow(0), wb.GetRow(1), ref axbd);
            Pxp(wa.GetRow(1), wb.GetRow(0), ref adxb);
		
            var axbRow1 = new double[3];
            Ppp(axbd, adxb, ref axbRow1);
            axb.SetRow(1, axbRow1);
        }
    }
}
