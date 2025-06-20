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
        /// Form the celestial to intermediate-frame-of-date matrix given the CIP X,Y and the CIO locator s.
        /// </summary>
        /// <param name="x">Celestial Intermediate Pole X coordinate</param>
        /// <param name="y">Celestial Intermediate Pole Y coordinate</param>
        /// <param name="s">the CIO locator s (radians)</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2ixys(double x, double y, double s, ref double[,] rc2i)
        {
            /* Obtain the spherical angles E and d. */
            var r2 = x * x + y * y;
            var e = (r2 > 0.0) ? Atan2(y, x) : 0.0;
            var d = Atan(Sqrt(r2 / (1.0 - r2)));

            /* Form the matrix. */
            Ir(ref rc2i);
            Rz(e, ref rc2i);
            Ry(d, ref rc2i);
            Rz(-(e + s), ref rc2i);
        }
    }
}
