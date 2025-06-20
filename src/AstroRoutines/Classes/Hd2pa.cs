using static System.Math;

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
        /// Parallactic angle for a given hour angle and declination.
        /// </summary>
        /// <param name="ha">hour angle</param>
        /// <param name="dec">declination</param>
        /// <param name="phi">site latitude</param>
        /// <returns>parallactic angle</returns>
        public static double Hd2pa(double ha, double dec, double phi)
        {
            var cp = Cos(phi);
            var sqsz = cp * Sin(ha);
            var cqsz = Sin(phi) * Cos(dec) - cp * Sin(dec) * Cos(ha);
            return ((sqsz != 0.0 || cqsz != 0.0) ? Atan2(sqsz, cqsz) : 0.0);

            /* Finished. */
        }
    }
}
