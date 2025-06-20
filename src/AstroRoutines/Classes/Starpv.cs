using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert star catalog coordinates to position/velocity vector.
        /// </summary>
        /// <param name="ra">right ascension (radians)</param>
        /// <param name="dec">declination (radians)</param>
        /// <param name="pmr">RA proper motion (radians/year)</param>
        /// <param name="pmd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcseconds)</param>
        /// <param name="rv">radial velocity (km/s, +ve = receding)</param>
        /// <param name="pv">position/velocity vector</param>
        /// <returns>status: 0 = OK, 1 = warning, 2 = warning, 3 = warning</returns>
        public static int Starpv(double ra, double dec,
                                 double pmr, double pmd, double px, double rv,
                                 ref double[,] pv)
        {
            double[] usr = new double[3], 
                ust = new double[3], ur = new double[3], ut = new double[3];
            int i, iwarn;
            double w,
                dd, ddel, 
            d = 0.0, del = 0.0,       /* to prevent */
            odd = 0.0, oddel = 0.0,   /* compiler   */
            od = 0.0, odel = 0.0;     /* warnings   */
            double[] pvRow1;


            /* Smallest allowed parallax */
            const double PXMIN = 1e-7;

            /* Largest allowed speed (fraction of c) */
            const double VMAX = 0.5;

            /* Maximum number of iterations for relativistic solution */
            const int IMAX = 100;

            /* Distance (au). */
            if (px >= PXMIN)
            {
                w = px;
                iwarn = 0;
            }
            else
            {
                w = PXMIN;
                iwarn = 1;
            }
            var r = DR2AS / w;

            /* Radial speed (au/day). */
            var rd = DAYSEC * rv * 1e3 / DAU;

            /* Proper motion (radian/day). */
            var rad = pmr / DJY;
            var decd = pmd / DJY;

            /* To pv-vector (au,au/day). */
            S2pv(ra, dec, r, rad, decd, rd, ref pv);

            /* If excessive velocity, arbitrarily set it to zero. */
            var v = Pm(pv.GetRow(1));
            if (v / DC > VMAX)
            {
                pvRow1 = pv.GetRow(1);
                Zp(ref pvRow1);
                pv.SetRow(1, pvRow1);

                iwarn += 2;
            }

            /* Isolate the radial component of the velocity (au/day). */
            Pn(pv.GetRow(0), out w, out var pu);
            var vsr = Pdp(pu, pv.GetRow(1));
            Sxp(vsr, pu, ref usr);

            /* Isolate the transverse component of the velocity (au/day). */
            Pmp(pv.GetRow(1), usr, ref ust);
            var vst = Pm(ust);

            /* Special-relativity dimensionless parameters. */
            var betsr = vsr / DC;
            var betst = vst / DC;

            /* Determine the observed-to-inertial correction terms. */
            var bett = betst;
            var betr = betsr;
            for (i = 0; i < IMAX; i++)
            {
                d = 1.0 + betr;
                w = betr * betr + bett * bett;
                del = -w / (Sqrt(1.0 - w) + 1.0);
                betr = d * betsr + del;
                bett = d * betst;
                if (i > 0)
                {
                    dd = Abs(d - od);
                    ddel = Abs(del - odel);
                    if ((i > 1) && (dd >= odd) && (ddel >= oddel)) break;
                    odd = dd;
                    oddel = ddel;
                }
                od = d;
                odel = del;
            }
            if (i >= IMAX) iwarn += 4;

            /* Scale observed tangential velocity vector into inertial (au/d). */
            Sxp(d, ust, ref ut);

            /* Compute inertial radial velocity vector (au/d). */
            Sxp(DC * (d * betsr + del), pu, ref ur);

            /* Combine the two to obtain the inertial space velocity vector. */
            pvRow1 = new double[3];
            Ppp(ur, ut, ref pvRow1);
            pv.SetRow(1, pvRow1);

            /* Return the status. */
            return iwarn;
        }
    }
}
