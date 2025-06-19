namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the matrix of polar motion for a given date, IAU 2000
        /// </summary>
        /// <param name="xp">Coordinates of the pole (radians)</param>
        /// <param name="yp">Coordinates of the pole (radians)</param>
        /// <param name="sp">The TIO locator s' (radians)</param>
        /// <param name="rpom">Polar-motion matrix</param>
        public static void Pom00(double xp, double yp, double sp, ref double[,] rpom)
        {
            // Construct the matrix
            Ir(ref rpom);
            Rz(sp, ref rpom);
            Ry(-xp, ref rpom);
            Rx(-yp, ref rpom);
        }
    }
}
