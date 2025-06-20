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
        /// In the star-independent astrometry parameters, update only the Earth rotation angle, supplied by the caller explicitly.
        /// </summary>
        /// <param name="theta">Earth rotation angle (radians, Note 2)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Aper(double theta, ref ASTROM astrom)
        {
            astrom.eral = theta + astrom.along;

            /* Finished. */
        }
    }
}
