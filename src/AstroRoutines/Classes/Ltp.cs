namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Long-term precession matrix.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="rp">precession matrix, J2000.0 to date</param>
        public static void Ltp(double epj, ref double[,] rp)
        {
            int i;
            double[] peqr = new double[3];
            double[] pecl = new double[3];
            double[] v = new double[3];
            double w;
            double[] eqx = new double[3];

            /* Equator pole (bottom row of matrix). */
            Ltpequ(epj, ref peqr);

            /* Ecliptic pole. */
            Ltpecl(epj, ref pecl);

            /* Equinox (top row of matrix). */
            Pxp(peqr, pecl, ref v);
            Pn(v, out w, out eqx);

            /* Middle row of matrix. */
            Pxp(peqr, eqx, ref v);

            /* Assemble the matrix. */
            for (i = 0; i < 3; i++)
            {
                rp[0, i] = eqx[i];
                rp[1, i] = v[i];
                rp[2, i] = peqr[i];
            }

            /* Finished. */
        }
    }
}
