namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Decompose radians into degrees, arcminutes, arcseconds, fraction.
        /// </summary>
        /// <param name="ndp">resolution</param>
        /// <param name="angle">angle in radians</param>
        /// <param name="sign">'+' or '-'</param>
        /// <param name="idmsf">degrees, arcminutes, arcseconds, fraction</param>
        public static void A2af(int ndp, double angle, out char sign, ref int[] idmsf)
        {
            double f = 15.0 / D2PI;
            D2tf(ndp, angle * f, out sign, ref idmsf);
        }
    }
}
