namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Assemble the celestial to terrestrial matrix from equinox-based components (the celestial-to-true matrix, the Greenwich Apparent Sidereal Time and the polar motion matrix).
        /// </summary>
        /// <param name="rbpn">celestial-to-true matrix</param>
        /// <param name="gst">Greenwich (apparent) Sidereal Time (radians)</param>
        /// <param name="rpom">polar-motion matrix</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix</param>
        public static void C2teqx(double[,] rbpn, double gst, double[,] rpom,
            out double[,] rc2t)
        {
            double[,] r = new double[3, 3];

            /* Construct the matrix. */
            Cr(rbpn, ref r);
            Rz(gst, ref r);
            rc2t = new double[3, 3];
            Rxr(rpom, r, ref rc2t);
        }
    }
}
