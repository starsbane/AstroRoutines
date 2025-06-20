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
        /// Horizon to equatorial coordinates: transform azimuth and altitude to hour angle and declination.
        /// </summary>
        /// <param name="az">azimuth</param>
        /// <param name="el">altitude (informally, elevation)</param>
        /// <param name="phi">site latitude</param>
        /// <param name="ha">hour angle (local)</param>
        /// <param name="dec">declination</param>
        public static void Ae2hd(double az, double el, double phi, out double ha, out double dec)
        {
            var sa = Sin(az);
            var ca = Cos(az);
            var se = Sin(el);
            var ce = Cos(el);
            var sp = Sin(phi);
            var cp = Cos(phi);

            var x = -ca * ce * sp + se * cp;
            var y = -sa * ce;
            var z = ca * ce * cp + se * sp;

            var r = Sqrt(x * x + y * y);
            ha = (r != 0.0) ? Atan2(y, x) : 0.0;
            dec = Atan2(z, r);
        }
    }
}
