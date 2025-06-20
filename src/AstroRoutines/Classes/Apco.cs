namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a terrestrial observer, prepare star-independent astrometry parameters for transformations between ICRS and observed coordinates.
        /// </summary>
        /// <param name="date1">TDB as a 2-part...</param>
        /// <param name="date2">...Julian Date (Note 1)</param>
        /// <param name="ebpv">Earth barycentric PV (au, au/day, Note 2)</param>
        /// <param name="ehp">Earth heliocentric P (au, Note 2)</param>
        /// <param name="x">CIP X (components of unit vector)</param>
        /// <param name="y">CIP Y (components of unit vector)</param>
        /// <param name="s">the CIO locator s (radians)</param>
        /// <param name="theta">Earth rotation angle (radians)</param>
        /// <param name="elong">longitude (radians, east +ve, Note 3)</param>
        /// <param name="phi">latitude (geodetic, radians, Note 3)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic, Note 3)</param>
        /// <param name="xp">polar motion coordinates (radians, Note 4)</param>
        /// <param name="yp">polar motion coordinates (radians, Note 4)</param>
        /// <param name="sp">the TIO locator s' (radians, Note 4)</param>
        /// <param name="refa">refraction constant A (radians, Note 5)</param>
        /// <param name="refb">refraction constant B (radians, Note 5)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apco(double date1, double date2, double[,] ebpv, double[] ehp,
                               double x, double y, double s, double theta,
                               double elong, double phi, double hm,
                               double xp, double yp, double sp,
                               double refa, double refb, ref ASTROM astrom)
        {
            var r = new double[3, 3];
            double a, b, eral, c;
            var pvc = new double[2, 3];
            var pv = new double[2, 3];

            /* Form the rotation matrix, CIRS to apparent [HA,Dec]. */
            Ir(ref r);
            Rz(theta + sp, ref r);
            Ry(-xp, ref r);
            Rx(-yp, ref r);
            Rz(elong, ref r);

            /* Solve for local Earth rotation angle. */
            a = r[0, 0];
            b = r[0, 1];
            eral = (a != 0.0 || b != 0.0) ? Atan2(b, a) : 0.0;
            astrom.eral = eral;

            /* Solve for polar motion [X,Y] with respect to local meridian. */
            a = r[0, 0];
            c = r[0, 2];
            astrom.xpl = Atan2(c, Sqrt(a * a + b * b));
            a = r[1, 2];
            b = r[2, 2];
            astrom.ypl = (a != 0.0 || b != 0.0) ? -Atan2(a, b) : 0.0;

            /* Adjusted longitude. */
            astrom.along = Anpm(eral - theta);

            /* Functions of latitude. */
            astrom.sphi = Sin(phi);
            astrom.cphi = Cos(phi);

            /* Refraction constants. */
            astrom.refa = refa;
            astrom.refb = refb;

            /* Disable the (redundant) diurnal aberration step. */
            astrom.diurab = 0.0;

            /* CIO based BPN matrix. */
            C2ixys(x, y, s, ref r);

            /* Observer's geocentric position and velocity (m, m/s, CIRS). */
            Pvtob(elong, phi, hm, xp, yp, sp, theta, ref pvc);

            /* Rotate into GCRS. */
            Trxpv(r, pvc, ref pv);

            /* ICRS <-> GCRS parameters. */
            Apcs(date1, date2, pv, ebpv, ehp, ref astrom);

            /* Store the CIO based BPN matrix. */
            Cr(r, ref astrom.bpn);

            /* Finished. */
        }
    }
}
