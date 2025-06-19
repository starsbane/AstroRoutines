namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich apparent sidereal time (consistent with IAU 2000
        /// resolutions but using the truncated nutation model IAU 2000B).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <returns>Greenwich apparent sidereal time (radians)</returns>
        public static double Gst00b(double uta, double utb)
        {
            double gmst00, ee00b, gst;

            gmst00 = Gmst00(uta, utb, uta, utb);
            ee00b = Ee00b(uta, utb);
            gst = Anp(gmst00 + ee00b);

            return gst;

            /* Finished. */
        }
    }
}
