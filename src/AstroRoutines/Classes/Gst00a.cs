namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich apparent sidereal time (consistent with IAU 2000
        /// resolutions).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <returns>Greenwich apparent sidereal time (radians)</returns>
        public static double Gst00a(double uta, double utb, double tta, double ttb)
        {
            double gmst00, ee00a, gst;

            gmst00 = Gmst00(uta, utb, tta, ttb);
            ee00a = Ee00a(tta, ttb);
            gst = Anp(gmst00 + ee00a);

            return gst;

            /* Finished. */
        }
    }
}
