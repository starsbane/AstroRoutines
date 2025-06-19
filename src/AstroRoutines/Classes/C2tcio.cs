namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Assemble the celestial to terrestrial matrix from CIO-based components (the celestial-to-intermediate matrix, the Earth Rotation Angle and the polar motion matrix).
        /// </summary>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        /// <param name="era">Earth rotation angle (radians)</param>
        /// <param name="rpom">polar-motion matrix</param>
        /// <param name="rc2t">celestial-to-terrestrial matrix</param>
        public static void C2tcio(double[,] rc2i, double era, double[,] rpom,
            out double[,] rc2t)
        {
            double[,] r = new double[3, 3];

            /* Construct the matrix. */
            Cr(rc2i, ref r);
            Rz(era, ref r);
            rc2t = new double[3, 3];
            Rxr(rpom, r, ref rc2t);
        }
    }
}
