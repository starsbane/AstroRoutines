namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich apparent sidereal time, IAU 2006, given the NPB matrix.
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <param name="rnpb">nutation x precession x bias matrix</param>
        /// <returns>Greenwich apparent sidereal time (radians)</returns>
        public static double Gst06(double uta, double utb, double tta, double ttb, double[,] rnpb)
        {
            double x, y, s, era, eors, gst;

            /* Extract CIP coordinates. */
            Bpn2xy(rnpb, out x, out y);

            /* The CIO locator, s. */
            s = S06(tta, ttb, x, y);

            /* Greenwich apparent sidereal time. */
            era = Era00(uta, utb);
            eors = Eors(rnpb, s);
            gst = Anp(era - eors);

            return gst;

            /* Finished. */
        }
    }
}
