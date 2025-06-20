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
		/// IAU 2000A nutation with adjustments to match the IAU 2006 precession.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="dpsi">nutation, luni-solar + planetary (Note 2)</param>
		/// <param name="deps">nutation, luni-solar + planetary (Note 2)</param>
        public static void Nut06a(double date1, double date2, out double dpsi, out double deps)
        {
            /* Interval between fundamental date J2000.0 and given date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;

            /* Factor correcting for secular variation of J2. */
            var fj2 = -2.7774e-6 * t;

            /* Obtain IAU 2000A nutation. */
            Nut00a(date1, date2, out var dp, out var de);

            /* Apply P03 adjustments (Wallace & Capitaine, 2006, Eqs.5). */
            dpsi = dp + dp * (0.4697e-6 + fj2);
            deps = de + de * fj2;

            /* Finished. */
        }
    }
}
