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
        /// Multiply a pv-vector by an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix</param>
        /// <param name="pv">pv-vector</param>
        /// <param name="rpv">r * pv</param>
        public static void Rxpv(double[,] r, double[,] pv, ref double[,] rpv)
        {
            var rpvRow0 = new double[3];
            var rpvRow1 = new double[3];
            Rxp(r, pv.GetRow(0), ref rpvRow0);
            rpv.SetRow(0, rpvRow0);

            Rxp(r, pv.GetRow(1), ref rpvRow1);
            rpv.SetRow(1, rpvRow1);
        }
    }
}
