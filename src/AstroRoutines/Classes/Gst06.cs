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
        /// Greenwich apparent sidereal time, IAU 2006, given the NPB matrix.
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <param name="rnpb">nutation x precession x bias matrix</param>
        /// <returns>Greenwich apparent sidereal time (radians)</returns>
        public static double Gst06(double uta, double utb, double tta, double ttb, double[,] rnpb)
        {
            /* Extract CIP coordinates. */
            Bpn2xy(rnpb, out var x, out var y);

            /* The CIO locator, s. */
            var s = S06(tta, ttb, x, y);

            /* Greenwich apparent sidereal time. */
            var era = Era00(uta, utb);
            var eors = Eors(rnpb, s);
            var gst = Anp(era - eors);

            return gst;

            /* Finished. */
        }
    }
}
