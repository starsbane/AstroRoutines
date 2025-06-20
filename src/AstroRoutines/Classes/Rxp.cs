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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a p-vector by an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix</param>
        /// <param name="p">p-vector</param>
        /// <param name="rp">r * p</param>
        public static void Rxp(double[,] r, double[] p, ref double[] rp)
        {
            double w;
            var wrp = new double[3];

            for (var j = 0; j < 3; j++)
            {
                w = 0.0;
                for (var i = 0; i < 3; i++)
                {
                    w += r[j, i] * p[i];
                }
                wrp[j] = w;
            }

            Cp(wrp, ref rp);
        }
    }
}
