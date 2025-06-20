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
        /// Convert position/velocity from spherical to Cartesian coordinates.
        /// </summary>
        /// <param name="theta">longitude angle (radians)</param>
        /// <param name="phi">latitude angle (radians)</param>
        /// <param name="r">radial distance</param>
        /// <param name="td">rate of change of theta</param>
        /// <param name="pd">rate of change of phi</param>
        /// <param name="rd">rate of change of r</param>
        /// <param name="pv">pv-vector</param>
        public static void S2pv(double theta, double phi, double r,
                                double td, double pd, double rd,
                                ref double[,] pv)
        {
            var st = Sin(theta);
            var ct = Cos(theta);
            var sp = Sin(phi);
            var cp = Cos(phi);
            var rcp = r * cp;
            var x = rcp * ct;
            var y = rcp * st;
            var rpd = r * pd;
            var w = rpd * sp - cp * rd;

            pv[0, 0] = x;
            pv[0, 1] = y;
            pv[0, 2] = r * sp;
            pv[1, 0] = -y * td - w * ct;
            pv[1, 1] = x * td - w * st;
            pv[1, 2] = rpd * cp + sp * rd;
        }
    }
}
