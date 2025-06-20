// Epb.cs

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
        /// Julian Date to Besselian Epoch.
        /// </summary>
        /// <param name="dj1">Julian Date (Notes 3,4)</param>
        /// <param name="dj2">Julian Date (Notes 3,4)</param>
        /// <returns>Besselian Epoch.</returns>
        public static double Epb(double dj1, double dj2)
        {
            /* J2000.0-B1900.0 (2415019.81352) in days */
            const double D1900 = 36524.68648;

            return 1900.0 + ((dj1 - DJ00) + (dj2 + D1900)) / DTY;

            /* Finished. */
        }
    }
}
