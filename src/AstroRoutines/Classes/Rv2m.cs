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
        /// Form the r-matrix corresponding to a given r-vector.
        /// </summary>
        /// <param name="w">Rotation vector</param>
        /// <param name="r">Rotation matrix</param>
        public static void Rv2m(double[] w, ref double[,] r)
        {
            // Euler angle (magnitude of rotation vector) and functions
            var x = w[0];
            var y = w[1];
            var z = w[2];
            var phi = Sqrt(x * x + y * y + z * z);
            var s = Sin(phi);
            var c = Cos(phi);
            var f = 1.0 - c;

            // Euler axis (direction of rotation vector), perhaps null
            if (phi > 0.0)
            {
                x /= phi;
                y /= phi;
                z /= phi;
            }

            // Form the rotation matrix
            r[0, 0] = x * x * f + c;
            r[0, 1] = x * y * f + z * s;
            r[0, 2] = x * z * f - y * s;
            r[1, 0] = y * x * f - z * s;
            r[1, 1] = y * y * f + c;
            r[1, 2] = y * z * f + x * s;
            r[2, 0] = z * x * f + y * s;
            r[2, 1] = z * y * f - x * s;
            r[2, 2] = z * z * f + c;
        }
    }
}
