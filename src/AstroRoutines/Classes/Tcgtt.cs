namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Geocentric Coordinate Time, TCG, to Terrestrial Time, TT.
        /// </summary>
        /// <param name="tcg1">TCG as a 2-part Julian Date</param>
        /// <param name="tcg2">TCG as a 2-part Julian Date</param>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Tcgtt(double tcg1, double tcg2, out double tt1, out double tt2)
        {
            tt1 = 0; tt2 = 0;
            double t77t = DJM77 + TTMTAI / DAYSEC;

            if (Abs(tcg1) > Abs(tcg2))
            {
                tt1 = tcg1;
                tt2 = tcg2 - ((tcg1 - DJM0) + (tcg2 - t77t)) * ELG;
            }
            else
            {
                tt1 = tcg1 - ((tcg2 - DJM0) + (tcg1 - t77t)) * ELG;
                tt2 = tcg2;
            }
            return 0;
        }
    }
}
