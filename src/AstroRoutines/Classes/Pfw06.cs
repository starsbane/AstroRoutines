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
		/// Precession angles, IAU 2006 (Fukushima-Williams 4-angle formulation).
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="gamb">F-W angle gamma_bar (radians)</param>
		/// <param name="phib">F-W angle phi_bar (radians)</param>
		/// <param name="psib">F-W angle psi_bar (radians)</param>
		/// <param name="epsa">F-W angle epsilon_A (radians)</param>
        public static void Pfw06(double date1, double date2,
                                out double gamb, out double phib, out double psib, out double epsa)
        {
            var t =
                /* Interval between fundamental date J2000.0 and given date (JC). */
                ((date1 - DJ00) + date2) / DJC;

            /* P03 bias+precession angles. */
            gamb = (-0.052928 +
                    (10.556378 +
                     (0.4932044 +
                      (-0.00031238 +
                       (-0.000002788 +
                        (0.0000000260)
                        * t) * t) * t) * t) * t) * DAS2R;
            phib = (84381.412819 +
                   (-46.811016 +
                   (0.0511268 +
                   (0.00053289 +
                   (-0.000000440 +
                   (-0.0000000176)
                   * t) * t) * t) * t) * t) * DAS2R;
            psib = (-0.041775 +
                   (5038.481484 +
                   (1.5584175 +
                   (-0.00018522 +
                   (-0.000026452 +
                   (-0.0000000148)
                   * t) * t) * t) * t) * t) * DAS2R;
            epsa = Obl06(date1, date2);

            /* Finished. */
        }
    }
}
