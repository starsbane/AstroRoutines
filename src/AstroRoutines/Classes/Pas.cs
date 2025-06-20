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
		/// Position-angle from spherical coordinates.
		/// </summary>
		/// <param name="al">longitude of point A (e.g. RA) in radians</param>
		/// <param name="ap">latitude of point A (e.g. Dec) in radians</param>
		/// <param name="bl">longitude of point B</param>
		/// <param name="bp">latitude of point B</param>
		/// <returns>position angle of B with respect to A</returns>
        public static double Pas(double al, double ap, double bl, double bp)
        {
            var dl = bl - al;
            var y = Sin(dl) * Cos(bp);
            var x = Sin(bp) * Cos(ap) - Cos(bp) * Sin(ap) * Cos(dl);
            var pa = ((x != 0.0) || (y != 0.0)) ? Atan2(y, x) : 0.0;

            return pa;

            /* Finished. */
        }
    }
}
