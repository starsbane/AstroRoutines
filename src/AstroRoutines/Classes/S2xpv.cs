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
        /// Multiply a pv-vector by two scalars.
        /// </summary>
        /// <param name="s1">scalar to multiply position component by</param>
        /// <param name="s2">scalar to multiply velocity component by</param>
        /// <param name="pv">pv-vector</param>
        /// <param name="spv">scaled pv-vector</param>
        public static void S2xpv(double s1, double s2, double[,] pv, ref double[,] spv)
        {
            var spvRow0 = new double[3];
            var spvRow1 = new double[3];

            Sxp(s1, pv.GetRow(0), ref spvRow0);
            spv.SetRow(0, spvRow0);

            Sxp(s2, pv.GetRow(1), ref spvRow1);
            spv.SetRow(1, spvRow1);
        }
    }
}
