// C2txy.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial to terrestrial matrix given the date, the UT1,
        /// the CIP coordinates and the polar motion.  IAU 2000.
        /// </summary>
        /// <param name="tta">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="ttb">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="uta">UT1 as a 2-part Julian Date (Note 1)</param>
        /// <param name="utb">UT1 as a 2-part Julian Date (Note 1)</param>
        /// <param name="x">Celestial Intermediate Pole (Note 2)</param>
        /// <param name="y">Celestial Intermediate Pole (Note 2)</param>
        /// <param name="xp">coordinates of the pole (radians, Note 3)</param>
        /// <param name="yp">coordinates of the pole (radians, Note 3)</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix (Note 4)</param>
        public static void C2txy(double tta, double ttb, double uta, double utb,
                      double x, double y, double xp, double yp,
                      double[,] rc2t)
        {
            var rc2i = new double[3, 3];
            double era, sp;
            var rpom = new double[3, 3];

            /* Form the celestial-to-intermediate matrix for this TT. */
            C2ixy(tta, ttb, x, y, ref rc2i);

            /* Predict the Earth rotation angle for this UT1. */
            era = Era00(uta, utb);

            /* Estimate s'. */
            sp = Sp00(tta, ttb);

            /* Form the polar motion matrix. */
            Pom00(xp, yp, sp, ref rpom);

            /* Combine to form the celestial-to-terrestrial matrix. */
            C2tcio(rc2i, era, rpom, out rc2t);

            /* Finished. */
        }
    }
}
