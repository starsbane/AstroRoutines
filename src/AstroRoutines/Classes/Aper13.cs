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
        /// In the star-independent astrometry parameters, update only the Earth rotation angle.
        /// </summary>
        /// <param name="ut11">UT1 as a 2-part...</param>
        /// <param name="ut12">...Julian Date (Note 1)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Aper13(double ut11, double ut12, ref ASTROM astrom)
        {
            Aper(Era00(ut11, ut12), ref astrom);

            /* Finished. */
        }
    }
}
