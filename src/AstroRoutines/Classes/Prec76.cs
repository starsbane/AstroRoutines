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
        /// IAU 1976 precession model.
        /// </summary>
        /// <param name="date01">TDB starting date (Note 1)</param>
        /// <param name="date02">TDB starting date (Note 1)</param>
        /// <param name="date11">TDB ending date (Note 1)</param>
        /// <param name="date12">TDB ending date (Note 1)</param>
        /// <param name="zeta">1st rotation: radians cw around z</param>
        /// <param name="z">3rd rotation: radians cw around z</param>
        /// <param name="theta">2nd rotation: radians ccw around y</param>
        public static void Prec76(double date01, double date02, 
                                  double date11, double date12,
                                  out double zeta, out double z, out double theta)
        {
            // Interval between fundamental epoch J2000.0 and start date (JC)
            var t0 = ((date01 - DJ00) + date02) / DJC;

            // Interval over which precession required (JC)
            var t = ((date11 - date01) + (date12 - date02)) / DJC;

            // Euler angles
            var tas2r = t * DAS2R;
            var w = 2306.2181 + (1.39656 - 0.000139 * t0) * t0;

            zeta = (w + ((0.30188 - 0.000344 * t0) + 0.017998 * t) * t) * tas2r;

            z = (w + ((1.09468 + 0.000066 * t0) + 0.018203 * t) * t) * tas2r;

            theta = ((2004.3109 + (-0.85330 - 0.000217 * t0) * t0)
                   + ((-0.42665 - 0.000217 * t0) - 0.041833 * t) * t) * tas2r;
        }
    }
}
