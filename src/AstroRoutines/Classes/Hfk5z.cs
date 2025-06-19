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
                                ref double r5, ref double d5, ref double dr5, ref double dd5)
        {
            double t;
            double[] ph = new double[3];
            double[,] r5h = new double[3, 3];
            double[] s5h = new double[3];
            double[] sh = new double[3];
            double[] vst = new double[3];
            double[,] rst = new double[3, 3];
            double[,] r5ht = new double[3, 3];
            double[,] pv5e = new double[2, 3];
            double[] vv = new double[3];
            double w, r, v;

            /* Time interval from fundamental epoch J2000.0 to given date (JY). */
            t = ((date1 - DJ00) + date2) / DJY;

            /* Hipparcos barycentric position vector (normalized). */
            S2c(rh, dh, ref ph);

            /* FK5 to Hipparcos orientation matrix and spin vector. */
            Fk5hip(out r5h, out s5h);

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
            Pv2s(pv5e, out w, out d5, out r, out dr5, out dd5, out v);
            r5 = Anp(w);

            /* Finished. */
        }
    }
}
