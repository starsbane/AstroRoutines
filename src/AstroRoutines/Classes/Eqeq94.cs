// Eqeq94.cs

using System;
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
        /// Equation of the equinoxes, IAU 1994 model.
        /// </summary>
        /// <param name="date1">TDB date (Note 1)</param>
        /// <param name="date2">TDB date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Eqeq94(double date1, double date2)
        {
            double deps;

            /* Interval between fundamental epoch J2000.0 and given date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;

            /* Longitude of the mean ascending node of the lunar orbit on the */
            /* ecliptic, measured from the mean equinox of date. */
            var om = Anpm((450160.280 + (-482890.539
                                         + (7.455 + 0.008 * t) * t) * t) * DAS2R
                          + ((-5.0 * t) % 1.0) * D2PI);

            /* Nutation components and mean obliquity. */
            Nut80(date1, date2, out var dpsi, out deps);
            var eps0 = Obl80(date1, date2);

            /* Equation of the equinoxes. */
            var ee = dpsi * Math.Cos(eps0) + DAS2R * (0.00264 * Math.Sin(om) + 0.000063 * Math.Sin(om + om));

            return ee;

            /* Finished. */
        }
    }
}
