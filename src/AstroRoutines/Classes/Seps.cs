namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Angular separation between two sets of spherical coordinates.
        /// </summary>
        /// <param name="al">first longitude (radians)</param>
        /// <param name="ap">first latitude (radians)</param>
        /// <param name="bl">second longitude (radians)</param>
        /// <param name="bp">second latitude (radians)</param>
        /// <returns>Angular separation (radians)</returns>
        public static double Seps(double al, double ap, double bl, double bp)
        {
            double[] ac = new double[3];
            double[] bc = new double[3];
            double s;

            /* Spherical to Cartesian. */
            S2c(al, ap, ref ac);
            S2c(bl, bp, ref bc);

            /* Angle between the vectors. */
            s = Sepp(ac, bc);

            return s;
        }
    }
}
