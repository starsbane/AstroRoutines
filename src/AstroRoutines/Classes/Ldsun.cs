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
        /// Deflection of starlight by the Sun.
        /// </summary>
        /// <param name="p">direction from observer to star (unit vector)</param>
        /// <param name="e">direction from Sun to observer (unit vector)</param>
        /// <param name="em">distance from Sun to observer (au)</param>
        /// <param name="p1">observer to deflected star (unit vector)</param>
        public static void Ldsun(double[] p, double[] e, double em, ref double[] p1)
        {
            /* Deflection limiter (smaller for distant observers). */
            var em2 = em * em;
            if (em2 < 1.0) em2 = 1.0;
            var dlim = 1e-6 / (em2 > 1.0 ? em2 : 1.0);

            /* Apply the deflection. */
            Ld(1.0, p, p, e, em, dlim, ref p1);

            /* Finished. */
        }
    }
}
