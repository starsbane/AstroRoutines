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
        /// Initialize an r-matrix to the null matrix.
        /// </summary>
        /// <param name="r">R-matrix to be zeroed</param>
        public static void Zr(ref double[,] r)
        {
            r[0,0] = 0.0;
            r[0,1] = 0.0;
            r[0,2] = 0.0;
            r[1,0] = 0.0;
            r[1,1] = 0.0;
            r[1,2] = 0.0;
            r[2,0] = 0.0;
            r[2,1] = 0.0;
            r[2,2] = 0.0;
        }
    }
}
