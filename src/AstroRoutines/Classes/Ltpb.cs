namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Long-term precession matrix, including ICRS frame bias.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="rpb">precession+bias matrix, J2000.0 to date</param>
        public static void Ltpb(double epj, ref double[,] rpb)
        {
            /* Frame bias (IERS Conventions 2010, Eqs. 5.21 and 5.33) */
            const double dx = -0.016617 * DAS2R;
            const double de = -0.0068192 * DAS2R;
            const double dr = -0.0146 * DAS2R;

            int i;
            var rp = new double[3, 3];

            /* Precession matrix. */
            Ltp(epj, ref rp);

            /* Apply the bias. */
            for (i = 0; i < 3; i++)
            {
                rpb[i, 0] = rp[i, 0] - rp[i, 1] * dr + rp[i, 2] * dx;
                rpb[i, 1] = rp[i, 0] * dr + rp[i, 1] + rp[i, 2] * de;
                rpb[i, 2] = -rp[i, 0] * dx - rp[i, 1] * de + rp[i, 2];
            }

            /* Finished. */
        }
    }
}
