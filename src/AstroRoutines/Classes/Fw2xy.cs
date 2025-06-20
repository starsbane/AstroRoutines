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
        /// CIP X,Y given Fukushima-Williams bias-precession-nutation angles.
        /// </summary>
        /// <param name="gamb">F-W angle gamma_bar</param>
        /// <param name="phib">F-W angle phi_bar</param>
        /// <param name="psi">F-W angle psi</param>
        /// <param name="eps">F-W angle epsilon</param>
        /// <param name="x">CIP unit vector X</param>
        /// <param name="y">CIP unit vector Y</param>
        public static void Fw2xy(double gamb, double phib, double psi, double eps, out double x, out double y)
        {
            var r = new double[3, 3];

            /* Form NxPxB matrix. */
            Fw2m(gamb, phib, psi, eps, ref r);

            /* Extract CIP X,Y. */
            Bpn2xy(r, out x, out y);
        }
    }
}
