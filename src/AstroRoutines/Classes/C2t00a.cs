namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial to terrestrial matrix given the date, the UT1 and the polar motion, using the IAU 2000A precession-nutation model.
        /// </summary>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="xp">coordinates of the pole (radians)</param>
        /// <param name="yp">coordinates of the pole (radians)</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix</param>
        public static void C2t00a(double tta, double ttb, double uta, double utb,
            double xp, double yp, out double[,] rc2t)
        {
            var rc2i = new double[3, 3];
            double era, sp;
            var rpom = new double[3, 3];

            /* Form the celestial-to-intermediate matrix for this TT (IAU 2000A). */
            C2i00a(tta, ttb, ref rc2i);

            /* Predict the Earth rotation angle for this UT1. */
            era = Era00(uta, utb);

            /* Estimate s'. */
            sp = Sp00(tta, ttb);

            /* Form the polar motion matrix. */
            Pom00(xp, yp, sp, ref rpom);

            /* Combine to form the celestial-to-terrestrial matrix. */
            C2tcio(rc2i, era, rpom, out rc2t);
        }
    }
}
