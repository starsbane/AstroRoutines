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
		/// Extend a p-vector to a pv-vector by appending a zero velocity.
		/// </summary>
		/// <param name="p">p-vector</param>
		/// <param name="pv">pv-vector</param>
        public static void P2pv(double[] p, ref double[,] pv)
        {
            var pvRow0 = pv.GetRow(0);
            Cp(p, ref pvRow0);
            pv.SetRow(0, pvRow0);

            var pvRow1 = pv.GetRow(1);
            Zp(ref pvRow1);
            pv.SetRow(1, pvRow1);

            /* Finished. */
        }
    }
}
