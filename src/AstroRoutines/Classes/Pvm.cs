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
        /// Modulus of pv-vector
        /// </summary>
        /// <param name="pv">pv-vector</param>
        /// <param name="r">Modulus of position component</param>
        /// <param name="s">Modulus of velocity component</param>
        public static void Pvm(double[,] pv, out double r, out double s)
        {
            // Distance
            r = Pm(pv.GetRow(0));

            // Speed
            s = Pm(pv.GetRow(1));
        }

        // Reuse the GetRow extension method from Pv2p
    }
}
