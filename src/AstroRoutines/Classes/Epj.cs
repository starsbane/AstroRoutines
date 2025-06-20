// Epj.cs

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
        /// Julian Date to Julian Epoch.
        /// </summary>
        /// <param name="dj1">Julian Date (Note 4)</param>
        /// <param name="dj2">Julian Date (Note 4)</param>
        /// <returns>Julian Epoch</returns>
        public static double Epj(double dj1, double dj2)
        {
            var epj = 2000.0 + ((dj1 - DJ00) + dj2) / DJY;

            return epj;

            /* Finished. */
        }
    }
}
