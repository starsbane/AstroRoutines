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
        /// Convert position/velocity from Cartesian to spherical coordinates
        /// </summary>
        /// <param name="pv">pv-vector</param>
        /// <param name="theta">Longitude angle (radians)</param>
        /// <param name="phi">Latitude angle (radians)</param>
        /// <param name="r">Radial distance</param>
        /// <param name="td">Rate of change of theta</param>
        /// <param name="pd">Rate of change of phi</param>
        /// <param name="rd">Rate of change of r</param>
        public static void Pv2s(double[,] pv, 
                                out double theta, out double phi, out double r,
                                out double td, out double pd, out double rd)
        {
            // Components of position/velocity vector
            var x = pv[0, 0];
            var y = pv[0, 1];
            var z = pv[0, 2];
            var xd = pv[1, 0];
            var yd = pv[1, 1];
            var zd = pv[1, 2];

            // Component of r in XY plane squared
            var rxy2 = x * x + y * y;

            // Modulus squared
            var r2 = rxy2 + z * z;

            // Modulus
            var rtrue = Sqrt(r2);

            // If null vector, move the origin along the direction of movement
            var rw = rtrue;
            if (rtrue == 0.0)
            {
                x = xd;
                y = yd;
                z = zd;
                rxy2 = x * x + y * y;
                r2 = rxy2 + z * z;
                rw = Sqrt(r2);
            }

            // Position and velocity in spherical coordinates
            var rxy = Sqrt(rxy2);
            var xyp = x * xd + y * yd;

            if (rxy2 != 0.0)
            {
                theta = Atan2(y, x);
                phi = Atan2(z, rxy);
                td = (x * yd - y * xd) / rxy2;
                pd = (zd * rxy2 - z * xyp) / (r2 * rxy);
            }
            else
            {
                theta = 0.0;
                phi = (z != 0.0) ? Atan2(z, rxy) : 0.0;
                td = 0.0;
                pd = 0.0;
            }

            r = rtrue;
            rd = (rw != 0.0) ? (xyp + z * zd) / rw : 0.0;
        }
    }
}
