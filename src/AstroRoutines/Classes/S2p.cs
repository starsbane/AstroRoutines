namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert spherical polar coordinates to p-vector.
        /// </summary>
        /// <param name="theta">longitude angle (radians)</param>
        /// <param name="phi">latitude angle (radians)</param>
        /// <param name="r">radial distance</param>
        /// <param name="p">Cartesian coordinates</param>
        public static void S2p(double theta, double phi, double r, ref double[] p)
        {
            var u = new double[3];

            S2c(theta, phi, ref u);
            Sxp(r, u, ref p);
        }
    }
}
