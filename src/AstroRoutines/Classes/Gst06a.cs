namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich apparent sidereal time (consistent with IAU 2000 and 2006
        /// resolutions).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <returns>Greenwich apparent sidereal time (radians)</returns>
        public static double Gst06a(double uta, double utb, double tta, double ttb)
        {
            var rnpb = new double[3, 3];
            double gst;

            /* Classical nutation x precession x bias matrix, IAU 2000A. */
            Pnm06a(tta, ttb, ref rnpb);

            /* Greenwich apparent sidereal time. */
            gst = Gst06(uta, utb, tta, ttb, rnpb);

            return gst;

            /* Finished. */
        }
    }
}
