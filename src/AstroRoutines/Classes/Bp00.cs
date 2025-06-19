namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Frame bias and precession, IAU 2000.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rb">frame bias matrix</param>
        /// <param name="rp">precession matrix</param>
        /// <param name="rbp">bias-precession matrix</param>
        public static void Bp00(double date1, double date2,
            out double[,] rb, out double[,] rp, out double[,] rbp)
        {
            /* J2000.0 obliquity (Lieske et al. 1977) */
            const double EPS0 = 84381.448 * DAS2R;

            double t, dpsibi, depsbi, dra0, psia77, oma77, chia,
                   dpsipr, depspr, psia, oma;
            double[,] rbw = new double[3, 3];

            /* Interval between fundamental epoch J2000.0 and current date (JC). */
            t = ((date1 - DJ00) + date2) / DJC;

            /* Frame bias. */
            Bi00(out dpsibi, out depsbi, out dra0);

            /* Precession angles (Lieske et al. 1977) */
            psia77 = (5038.7784 + (-1.07259 + (-0.001147) * t) * t) * t * DAS2R;
            oma77 = EPS0 + ((0.05127 + (-0.007726) * t) * t) * t * DAS2R;
            chia = (10.5526 + (-2.38064 + (-0.001125) * t) * t) * t * DAS2R;

            /* Apply IAU 2000 precession corrections. */
            Pr00(date1, date2, out dpsipr, out depspr);
            psia = psia77 + dpsipr;
            oma = oma77 + depspr;

            /* Frame bias matrix: GCRS to J2000.0. */
            Ir(ref rbw);
            Rz(dra0, ref rbw);
            Ry(dpsibi * Sin(EPS0), ref rbw);
            Rx(-depsbi, ref rbw);
            rb = rbw;

            /* Precession matrix: J2000.0 to mean of date. */
            rp = new double[3, 3];
            Ir(ref rp);
            Rx(EPS0, ref rp);
            Rz(-psia, ref rp);
            Rx(-oma, ref rp);
            Rz(chia, ref rp);

            /* Bias-precession matrix: GCRS to mean of date. */
            Rxr(rp, rbw, out rbp);
        }
    }
}
