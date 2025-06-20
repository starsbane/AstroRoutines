using static System.Math;
using static AstroRoutines.Constants;

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
        /// Equatorial to horizon coordinates:  transform hour angle and
        /// declination to azimuth and altitude.
        /// </summary>
        /// <param name="ha">hour angle (local)</param>
        /// <param name="dec">declination</param>
        /// <param name="phi">site latitude</param>
        /// <param name="az">azimuth</param>
        /// <param name="el">altitude (informally, elevation)</param>
        public static void Hd2ae(double ha, double dec, double phi, out double az, out double el)
        {
            /* Useful trig functions. */
            var sh = Sin(ha);
            var ch = Cos(ha);
            var sd = Sin(dec);
            var cd = Cos(dec);
            var sp = Sin(phi);
            var cp = Cos(phi);

            /* Az,Alt unit vector. */
            var x = -ch * cd * sp + sd * cp;
            var y = -sh * cd;
            var z = ch * cd * cp + sd * sp;

            /* To spherical. */
            var r = Sqrt(x * x + y * y);
            var a = (r != 0.0) ? Atan2(y, x) : 0.0;
            az = (a < 0.0) ? a + D2PI : a;
            el = Atan2(z, r);

            /* Finished. */
        }
    }
}
