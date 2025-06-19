namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Proper motion and parallax.
        /// </summary>
        /// <param name="rc">ICRS RA,Dec at catalog epoch (radians)</param>
        /// <param name="dc">ICRS RA,Dec at catalog epoch (radians)</param>
        /// <param name="pr">RA proper motion (radians/year, Note 1)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="pmt">proper motion time interval (SSB, Julian years)</param>
        /// <param name="pob">SSB to observer vector (au)</param>
        /// <param name="pco">coordinate direction (BCRS unit vector)</param>
        public static void Pmpx(double rc, double dc, double pr, double pd,
                                double px, double rv, double pmt, double[] pob,
                                ref double[] pco)
        {
            /* Km/s to au/year */
            const double VF = DAYSEC * DJM / DAU;

            /* Light time for 1 au, Julian years */
            const double AULTY = AULT / DAYSEC / DJY;

            double sr, cr, sd, cd, x, y, z;
            var p = new double[3];
            double dt, pxr, w, pdz;
            var pm = new double[3];

            /* Spherical coordinates to unit vector (and useful functions). */
            sr = Sin(rc);
            cr = Cos(rc);
            sd = Sin(dc);
            cd = Cos(dc);
            p[0] = x = cr * cd;
            p[1] = y = sr * cd;
            p[2] = z = sd;

            /* Proper motion time interval (y) including Roemer effect. */
            dt = pmt + Pdp(p, pob) * AULTY;

            /* Space motion (radians per year). */
            pxr = px * DAS2R;
            w = VF * rv * pxr;
            pdz = pd * z;
            pm[0] = -pr * y - pdz * cr + w * x;
            pm[1] = pr * x - pdz * sr + w * y;
            pm[2] = pd * cd + w * z;

            /* Coordinate direction of star (unit vector, BCRS). */
            for (var i = 0; i < 3; i++)
            {
                p[i] += dt * pm[i] - pxr * pob[i];
            }
            Pn(p, out w, out pco);
        }
    }
}
