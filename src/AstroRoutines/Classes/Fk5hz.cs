namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Transform an FK5 (J2000.0) star position into the system of the Hipparcos catalog, assuming zero Hipparcos proper motion.
    /// </summary>
    /// <param name="r5">FK5 RA</param>
    /// <param name="d5">FK5 Dec</param>
    /// <param name="date1">TDB date</param>
    /// <param name="date2">TDB date</param>
    /// <param name="rh">Hipparcos RA</param>
    /// <param name="dh">Hipparcos Dec</param>
    public static void Fk5hz(double r5, double d5, double date1, double date2, out double rh, out double dh)
    {
        double t;
        double[] p5e = new double[3];
        double[,] r5h = new double[3, 3];
        double[] s5h = new double[3];
        double[] vst = new double[3];
        double[,] rst = new double[3, 3];
        double[] p5 = new double[3];
        double[] ph = new double[3];
        double w;

        /* Interval from given date to fundamental epoch J2000.0 (JY). */
        t = -((date1 - DJ00) + date2) / DJY;

        /* FK5 barycentric position vector. */
        S2c(r5, d5, ref p5e);

        /* FK5 to Hipparcos orientation matrix and spin vector. */
        Fk5hip(out r5h, out s5h);

        /* Accumulated Hipparcos wrt FK5 spin over that interval. */
        Sxp(t, s5h, ref vst);

        /* Express the accumulated spin as a rotation matrix. */
        Rv2m(vst, ref rst);

        /* Derotate the vector's FK5 axes back to date. */
        Trxp(rst, p5e, ref p5);

        /* Rotate the vector into the Hipparcos system. */
        Rxp(r5h, p5, ref ph);

        /* Hipparcos vector to spherical. */
        C2s(ph, out w, out dh);
        rh = Anp(w);
    }
}
