using static System.Math;

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
        /// Rotate an r-matrix about the y-axis.
        /// </summary>
        /// <param name="theta">Angle (radians)</param>
        /// <param name="r">R-matrix, rotated</param>
        public static void Ry(double theta, ref double[,] r)
        {
            var s = Sin(theta);
            var c = Cos(theta);

            var a00 = c * r[0, 0] - s * r[2, 0];
            var a01 = c * r[0, 1] - s * r[2, 1];
            var a02 = c * r[0, 2] - s * r[2, 2];
            var a20 = s * r[0, 0] + c * r[2, 0];
            var a21 = s * r[0, 1] + c * r[2, 1];
            var a22 = s * r[0, 2] + c * r[2, 2];

            r[0, 0] = a00;
            r[0, 1] = a01;
            r[0, 2] = a02;
            r[2, 0] = a20;
            r[2, 1] = a21;
            r[2, 2] = a22;
        }
    }
}
