// Ee06a.cs

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
        /// Equation of the equinoxes, compatible with IAU 2000 resolutions and
        /// IAU 2006/2000A precession-nutation.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Ee06a(double date1, double date2)
        {
            /* Apparent and mean sidereal times. */
            var gst06a = Gst06a(0.0, 0.0, date1, date2);
            var gmst06 = Gmst06(0.0, 0.0, date1, date2);

            /* Equation of the equinoxes. */
            var ee = Anpm(gst06a - gmst06);

            return ee;

            /* Finished. */
        }
    }
}
