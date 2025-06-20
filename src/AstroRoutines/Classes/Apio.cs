namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a terrestrial observer, prepare star-independent astrometry parameters for transformations between CIRS and observed coordinates.
        /// </summary>
        /// <param name="sp">the TIO locator s' (radians)</param>
        /// <param name="theta">Earth rotation angle (radians)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">geodetic latitude (radians)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic)</param>
        /// <param name="xp">polar motion coordinates (radians)</param>
        /// <param name="yp">polar motion coordinates (radians)</param>
        /// <param name="refa">refraction constant A (radians)</param>
        /// <param name="refb">refraction constant B (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apio(double sp, double theta, double elong, double phi, double hm,
                               double xp, double yp, double refa, double refb, ref ASTROM astrom)
        {
            var r = new double[3, 3];
            double a, b, eral, c;

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

            /* Observer's geocentric position and velocity (m, m/s, CIRS). */
            var pvc = new double[2, 3];
            Pvtob(elong, phi, hm, xp, yp, sp, theta, ref pvc);

            /* Magnitude of diurnal aberration vector. */
            var diurab = Sqrt(pvc[1, 0] * pvc[1, 0] + pvc[1, 1] * pvc[1, 1]) / CMPS;
            astrom.diurab = diurab;

            /* Refraction constants. */
            astrom.refa = refa;
            astrom.refb = refb;
        }
    }
}
