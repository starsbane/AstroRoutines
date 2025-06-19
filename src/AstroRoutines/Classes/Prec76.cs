namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// IAU 1976 precession model.
        /// </summary>
        /// <param name="date01">TDB starting date (Note 1)</param>
        /// <param name="date02">TDB starting date (Note 1)</param>
        /// <param name="date11">TDB ending date (Note 1)</param>
        /// <param name="date12">TDB ending date (Note 1)</param>
        /// <param name="zeta">1st rotation: radians cw around z</param>
        /// <param name="z">3rd rotation: radians cw around z</param>
        /// <param name="theta">2nd rotation: radians ccw around y</param>
        public static void Prec76(double date01, double date02, 
                                  double date11, double date12,
                                  out double zeta, out double z, out double theta)
        {
            double t0, t, tas2r, w;

            // Interval between fundamental epoch J2000.0 and start date (JC)
            t0 = ((date01 - DJ00) + date02) / DJC;

            // Interval over which precession required (JC)
            t = ((date11 - date01) + (date12 - date02)) / DJC;

            // Euler angles
            tas2r = t * DAS2R;
            w = 2306.2181 + (1.39656 - 0.000139 * t0) * t0;

            zeta = (w + ((0.30188 - 0.000344 * t0) + 0.017998 * t) * t) * tas2r;

            z = (w + ((1.09468 + 0.000066 * t0) + 0.018203 * t) * t) * tas2r;

            theta = ((2004.3109 + (-0.85330 - 0.000217 * t0) * t0)
                   + ((-0.42665 - 0.000217 * t0) - 0.041833 * t) * t) * tas2r;
        }
    }
}
