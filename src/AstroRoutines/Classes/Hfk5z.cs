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
        /// Transform a Hipparcos star position into FK5 J2000.0, assuming
        /// zero Hipparcos proper motion.
        /// </summary>
        /// <param name="rh">Hipparcos RA (radians)</param>
        /// <param name="dh">Hipparcos Dec (radians)</param>
        /// <param name="date1">TDB date</param>
        /// <param name="date2">TDB date</param>
        /// <param name="r5">RA (radians)</param>
        /// <param name="d5">Dec (radians)</param>
        /// <param name="dr5">RA proper motion (rad/year)</param>
        /// <param name="dd5">Dec proper motion (rad/year)</param>
        public static void Hfk5z(double rh, double dh, double date1, double date2,
                                out double r5, out double d5, out double dr5, out double dd5)
        {
            var ph = new double[3];
            var sh = new double[3];
            var vst = new double[3];
            var rst = new double[3, 3];
            var r5ht = new double[3, 3];
            var pv5e = new double[2, 3];
            var vv = new double[3];
            double r, v;

            /* Time interval from fundamental epoch J2000.0 to given date (JY). */
            var t = ((date1 - DJ00) + date2) / DJY;

            /* Hipparcos barycentric position vector (normalized). */
            S2c(rh, dh, ref ph);

            /* FK5 to Hipparcos orientation matrix and spin vector. */
            Fk5hip(out var r5h, out var s5h);

            /* Rotate the spin into the Hipparcos system. */
            Rxp(r5h, s5h, ref sh);

            /* Accumulated Hipparcos wrt FK5 spin over that interval. */
            Sxp(t, s5h, ref vst);

            /* Express the accumulated spin as a rotation matrix. */
            Rv2m(vst, ref rst);

            /* Rotation matrix:  accumulated spin, then FK5 to Hipparcos. */
            Rxr(r5h, rst, ref r5ht);

            /* De-orient & de-spin the Hipparcos position into FK5 J2000.0. */
            var pv5eRow0 = pv5e.GetRow(0);
            Trxp(r5ht, ph, ref pv5eRow0);
            pv5e.SetRow(0, pv5eRow0);

            /* Apply spin to the position giving a space motion. */
            Pxp(sh, ph, ref vv);

            /* De-orient & de-spin the Hipparcos space motion into FK5 J2000.0. */
            var pv5eRow1 = pv5e.GetRow(1);
            Trxp(r5ht, vv, ref pv5eRow1);
            pv5e.SetRow(1, pv5eRow1);

            /* FK5 position/velocity pv-vector to spherical. */
            Pv2s(pv5e, out var w, out d5, out r, out dr5, out dd5, out v);
            r5 = Anp(w);

            /* Finished. */
        }
    }
}
