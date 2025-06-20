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
        /// Form the matrix of polar motion for a given date, IAU 2000
        /// </summary>
        /// <param name="xp">Coordinates of the pole (radians)</param>
        /// <param name="yp">Coordinates of the pole (radians)</param>
        /// <param name="sp">The TIO locator s' (radians)</param>
        /// <param name="rpom">Polar-motion matrix</param>
        public static void Pom00(double xp, double yp, double sp, ref double[,] rpom)
        {
            // Construct the matrix
            Ir(ref rpom);
            Rz(sp, ref rpom);
            Ry(-xp, ref rpom);
            Rx(-yp, ref rpom);
        }
    }
}
