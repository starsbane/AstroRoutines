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
        /// Transform FK5 (J2000.0) star data into the Hipparcos system.
        /// </summary>
        /// <param name="r5">FK5 RA</param>
        /// <param name="d5">FK5 Dec</param>
        /// <param name="dr5">FK5 proper motion in RA</param>
        /// <param name="dd5">FK5 proper motion in Dec</param>
        /// <param name="px5">FK5 parallax</param>
        /// <param name="rv5">FK5 radial velocity</param>
        /// <param name="rh">Hipparcos RA</param>
        /// <param name="dh">Hipparcos Dec</param>
        /// <param name="drh">Hipparcos proper motion in RA</param>
        /// <param name="ddh">Hipparcos proper motion in Dec</param>
        /// <param name="pxh">Hipparcos parallax</param>
        /// <param name="rvh">Hipparcos radial velocity</param>
        public static void Fk52h(double r5, double d5, double dr5, double dd5, double px5, double rv5,
            out double rh, out double dh, out double drh, out double ddh, out double pxh, out double rvh)
        {
            int i;
            var pv5 = new double[2, 3];
            var wxp = new double[3];
            var vv = new double[3];
            var pvh = new double[2, 3];

            /* FK5 barycentric position/velocity pv-vector (normalized). */
            Starpv(r5, d5, dr5, dd5, px5, rv5, ref pv5);

            /* FK5 to Hipparcos orientation matrix and spin vector. */
            Fk5hip(out var r5h, out var s5h);

            /* Make spin units per day instead of per year. */
            for (i = 0; i < 3; i++)
            {
                s5h[i] /= 365.25;
            }

            /* Orient the FK5 position into the Hipparcos system. */
            var pv5_0 = new double[3];
            for (i = 0; i < 3; i++) pv5_0[i] = pv5[0, i];
            var pvh_0 = new double[3];
            Rxp(r5h, pv5_0, ref pvh_0);
            for (i = 0; i < 3; i++) pvh[0, i] = pvh_0[i];

            /* Apply spin to the position giving an extra space motion component. */
            Pxp(pv5_0, s5h, ref wxp);

            /* Add this component to the FK5 space motion. */
            var pv5_1 = new double[3];
            for (i = 0; i < 3; i++) pv5_1[i] = pv5[1, i];
            Ppp(wxp, pv5_1, ref vv);

            /* Orient the FK5 space motion into the Hipparcos system. */
            var pvh_1 = new double[3];
            Rxp(r5h, vv, ref pvh_1);
            for (i = 0; i < 3; i++) pvh[1, i] = pvh_1[i];

            /* Hipparcos pv-vector to spherical. */
            Pvstar(pvh, out rh, out dh, out drh, out ddh, out pxh, out rvh);
        }
    }
}
