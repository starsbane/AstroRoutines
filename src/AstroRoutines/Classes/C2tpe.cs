namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial to terrestrial matrix given the date, the UT1, the nutation and the polar motion. IAU 2000.
        /// </summary>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="dpsi">nutation (radians)</param>
        /// <param name="deps">nutation (radians)</param>
        /// <param name="xp">coordinates of the pole (radians)</param>
        /// <param name="yp">coordinates of the pole (radians)</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix</param>
        public static void C2tpe(double tta, double ttb, double uta, double utb,
            double dpsi, double deps, double xp, double yp,
            out double[,] rc2t)
        {
            double epsa;
            double[,] rb = new double[3, 3];
            double[,] rp = new double[3, 3];
            double[,] rbp = new double[3, 3];
            double[,] rn = new double[3, 3];
            double[,] rbpn = new double[3, 3];
            double gmst, ee, sp;
            double[,] rpom = new double[3, 3];

            /* Form the celestial-to-true matrix for this TT. */
            Pn00(tta, ttb, dpsi, deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);

            /* Predict the Greenwich Mean Sidereal Time for this UT1 and TT. */
            gmst = Gmst00(uta, utb, tta, ttb);

            /* Predict the equation of the equinoxes given TT and nutation. */
            ee = Ee00(tta, ttb, epsa, dpsi);

            /* Estimate s'. */
            sp = Sp00(tta, ttb);

            /* Form the polar motion matrix. */
            Pom00(xp, yp, sp, ref rpom);

            /* Combine to form the celestial-to-terrestrial matrix. */
            C2teqx(rbpn, gmst + ee, rpom, out rc2t);
        }
    }
}
