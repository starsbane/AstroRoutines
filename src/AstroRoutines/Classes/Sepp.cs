using System;

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
        /// Angular separation between two p-vectors.
        /// </summary>
        /// <param name="a">first p-vector (not necessarily unit length)</param>
        /// <param name="b">second p-vector (not necessarily unit length)</param>
        /// <returns>Angular separation (radians, always positive)</returns>
        public static double Sepp(double[] a, double[] b)
        {
            var axb = new double[3];

            /* Sine of angle between the vectors, multiplied by the two moduli. */
            Pxp(a, b, ref axb);
            var ss = Pm(axb);

            /* Cosine of the angle, multiplied by the two moduli. */
            var cs = Pdp(a, b);

            /* The angle. */
            var s = ((ss != 0.0) || (cs != 0.0)) ? Math.Atan2(ss, cs) : 0.0;

            return s;
        }
    }
}
