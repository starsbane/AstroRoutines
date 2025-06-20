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
            /* Extract CIP coordinates. */
            Bpn2xy(rnpb, out var x, out var y);

            /* The CIO locator, s. */
            var s = S06(tta, ttb, x, y);

            /* Greenwich apparent sidereal time. */
            var era = Era00(uta, utb);
            var eors = Eors(rnpb, s);
            var gst = Anp(era - eors);

            return gst;

            /* Finished. */
        }
    }
}
