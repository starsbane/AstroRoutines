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
        /// Time scale transformation: Coordinated Universal Time, UTC, to Universal Time, UT1.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">Delta UT1 = UT1-UTC in seconds</param>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <returns>
        /// Status:
        /// +1 = dubious year
        /// 0 = OK
        /// -1 = unacceptable date
        /// </returns>
        public static int Utcut1(double utc1, double utc2, double dut1, 
                                 ref double ut11, ref double ut12)
        {
            double w;

            // Look up TAI-UTC
            if (Jd2cal(utc1, utc2, out var iy, out var im, out var id, out w) != 0) return -1;
            var js = Dat(iy, im, id, 0.0, out var dat);
            if (js < 0) return -1;

            // Form UT1-TAI
            var dta = dut1 - dat;

            // UTC to TAI to UT1
            var jw = Utctai(utc1, utc2, out var tai1, out var tai2);
            if (jw < 0)
            {
                return -1;
            }
            else if (jw > 0)
            {
                js = jw;
            }
            if (Taiut1(tai1, tai2, dta, out ut11, out ut12) != 0) return -1;

            // Status
            return js;
        }
    }
}
