namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transform Hipparcos star data into the FK5 (J2000.0) system.
        /// </summary>
        /// <param name="rh">RA (radians)</param>
        /// <param name="dh">Dec (radians)</param>
        /// <param name="drh">proper motion in RA (dRA/dt, rad/Jyear)</param>
        /// <param name="ddh">proper motion in Dec (dDec/dt, rad/Jyear)</param>
        /// <param name="pxh">parallax (arcsec)</param>
        /// <param name="rvh">radial velocity (km/s, positive = receding)</param>
        /// <param name="r5">RA (radians)</param>
        /// <param name="d5">Dec (radians)</param>
        /// <param name="dr5">proper motion in RA (dRA/dt, rad/Jyear)</param>
        /// <param name="dd5">proper motion in Dec (dDec/dt, rad/Jyear)</param>
        /// <param name="px5">parallax (arcsec)</param>
        /// <param name="rv5">radial velocity (km/s, positive = receding)</param>
        public static void H2fk5(double rh, double dh,
                                 double drh, double ddh, double pxh, double rvh,
                                 ref double r5, ref double d5,
                                 ref double dr5, ref double dd5, ref double px5, ref double rv5)
        {
            int i;
            var pvh = new double[2, 3];
            var r5h = new double[3, 3];
            var s5h = new double[3];
            var sh = new double[3];
            var wxp = new double[3];
            var vv = new double[3];
            var pv5 = new double[2, 3];

            /* Hipparcos barycentric position/velocity pv-vector (normalized). */
            Starpv(rh, dh, drh, ddh, pxh, rvh, ref pvh);

            /* FK5 to Hipparcos orientation matrix and spin vector. */
            Fk5hip(out r5h, out s5h);

            /* Make spin units per day instead of per year. */
            for (i = 0; i < 3; s5h[i++] /= 365.25) ;

            /* Orient the spin into the Hipparcos system. */
            Rxp(r5h, s5h, ref sh);

            var pvhRow0 = pvh.GetRow(0);
            var pv5Row0 = pv5.GetRow(0);
            /* De-orient the Hipparcos position into the FK5 system. */
            Trxp(r5h, pvhRow0, ref pv5Row0);
            pv5.SetRow(0, pv5Row0);

            /* Apply spin to the position giving an extra space motion component. */
            Pxp(pvhRow0, sh, ref wxp);

            /* Subtract this component from the Hipparcos space motion. */
            Pmp(pvh.GetRow(1), wxp, ref vv);

            var pv5Row1 = pv5.GetRow(1);
            /* De-orient the Hipparcos space motion into the FK5 system. */
            Trxp(r5h, vv, ref pv5Row1);
            pv5.SetRow(1, pv5Row1);

            /* FK5 pv-vector to spherical. */
            Pvstar(pv5, out r5, out d5, out dr5, out dd5, out px5, out rv5);

            /* Finished. */
        }
    }
}
