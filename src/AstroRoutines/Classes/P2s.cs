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
		/// P-vector to spherical polar coordinates.
		/// </summary>
		/// <param name="p">p-vector</param>
		/// <param name="theta">longitude angle (radians)</param>
		/// <param name="phi">latitude angle (radians)</param>
		/// <param name="r">radial distance</param>
        public static void P2s(double[] p, out double theta, out double phi, out double r)
        {
            C2s(p, out theta, out phi);
            r = Pm(p);

            /* Finished. */
        }
    }
}
