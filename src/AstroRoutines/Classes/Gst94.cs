namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich apparent sidereal time (consistent with IAU 1982/94
        /// resolutions).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <returns>Greenwich apparent sidereal time (radians)</returns>
        public static double Gst94(double uta, double utb)
        {
            var gmst82 = Gmst82(uta, utb);
            var eqeq94 = Eqeq94(uta, utb);
            var gst = Anp(gmst82 + eqeq94);

            return gst;

            /* Finished. */
        }
    }
}
