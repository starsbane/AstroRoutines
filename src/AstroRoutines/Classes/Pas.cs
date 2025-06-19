namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Position-angle from spherical coordinates.
		/// </summary>
		/// <param name="al">longitude of point A (e.g. RA) in radians</param>
		/// <param name="ap">latitude of point A (e.g. Dec) in radians</param>
		/// <param name="bl">longitude of point B</param>
		/// <param name="bp">latitude of point B</param>
		/// <returns>position angle of B with respect to A</returns>
        public static double Pas(double al, double ap, double bl, double bp)
        {
            double dl, x, y, pa;

            dl = bl - al;
            y = Sin(dl) * Cos(bp);
            x = Sin(bp) * Cos(ap) - Cos(bp) * Sin(ap) * Cos(dl);
            pa = ((x != 0.0) || (y != 0.0)) ? Atan2(y, x) : 0.0;

            return pa;

            /* Finished. */
        }
    }
}
