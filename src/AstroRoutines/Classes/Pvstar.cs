namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert star position+velocity vector to catalog coordinates.
        /// </summary>
        /// <param name="pv">pv-vector (au, au/day)</param>
        /// <param name="ra">Right ascension (radians)</param>
        /// <param name="dec">Declination (radians)</param>
        /// <param name="pmr">RA proper motion (radians/year)</param>
        /// <param name="pmd">Dec proper motion (radians/year)</param>
        /// <param name="px">Parallax (arcsec)</param>
        /// <param name="rv">Radial velocity (km/s, positive = receding)</param>
        /// <returns>Status: 0 = OK, -1 = superluminal speed, -2 = null position vector</returns>
        public static int Pvstar(double[,] pv, out double ra, out double dec,
                                  out double pmr, out double pmd, out double px, out double rv)
        {
            ra = 0;
            dec = 0;
            pmr = 0;
            pmd = 0;
            px = 0;
            rv = 0;

            double r;
            var pu = new double[3];
            double vr, vt;
            var ur = new double[3];
            var ut = new double[3];
            double bett, betr, d, w, del;
            var usr = new double[3];
            var ust = new double[3];
            double a, rad, decd, rd;

            // Isolate the radial component of the velocity (au/day, inertial)
            Pn(pv.GetRow(0), out r, out pu);
            vr = Pdp(pu, pv.GetRow(1));
            Sxp(vr, pu, ref ur);

            // Isolate the transverse component of the velocity (au/day, inertial)
            Pmp(pv.GetRow(1), ur, ref ut);
            vt = Pm(ut);

            // Special-relativity dimensionless parameters
            bett = vt / DC;
            betr = vr / DC;

            // The observed-to-inertial correction terms
            d = 1.0 + betr;
            w = betr * betr + bett * bett;
            if (d == 0.0 || w > 1.0) return -1;
            del = -w / (Sqrt(1.0 - w) + 1.0);

            // Scale inertial tangential velocity vector into observed (au/d)
            Sxp(1.0 / d, ut, ref ust);

            // Compute observed radial velocity vector (au/d)
            Sxp(DC * (betr - del) / d, pu, ref usr);

            var pvRow1 = pv.GetRow(1);
            // Combine the two to obtain the observed velocity vector
            Ppp(usr, ust, ref pvRow1);
            pv.SetRow(1, pvRow1);

            // Cartesian to spherical
            Pv2s(pv, out a, out dec, out r, out rad, out decd, out rd);
            if (r == 0.0) return -2;

            // Return RA in range 0 to 2pi
            ra = Anp(a);

            // Return proper motions in radians per year
            pmr = rad * DJY;
            pmd = decd * DJY;

            // Return parallax in arcsec
            px = DR2AS / r;

            // Return radial velocity in km/s
            rv = 1e-3 * rd * DAU / DAYSEC;

            return 0;
        }
    }
}
