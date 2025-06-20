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
        /// Precession-rate part of the IAU 2000 precession-nutation models
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="dpsipr">Precession correction in longitude</param>
        /// <param name="depspr">Precession correction in obliquity</param>
        public static void Pr00(double date1, double date2, 
                                out double dpsipr, out double depspr)
        {
            // Precession and obliquity corrections (radians per century)
            const double PRECOR = -0.29965 * DAS2R;
            const double OBLCOR = -0.02524 * DAS2R;

            // Interval between fundamental epoch J2000.0 and given date (JC)
            var t = ((date1 - DJ00) + date2) / DJC;

            // Precession rate contributions with respect to IAU 1976/80
            dpsipr = PRECOR * t;
            depspr = OBLCOR * t;
        }
    }
}
