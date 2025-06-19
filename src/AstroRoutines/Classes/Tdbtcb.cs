namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Barycentric Dynamical Time, TDB, to Barycentric Coordinate Time, TCB.
        /// </summary>
        /// <param name="tdb1">TDB as a 2-part Julian Date</param>
        /// <param name="tdb2">TDB as a 2-part Julian Date</param>
        /// <param name="tcb1">TCB as a 2-part Julian Date</param>
        /// <param name="tcb2">TCB as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Tdbtcb(double tdb1, double tdb2, out double tcb1, out double tcb2)
        {
            tcb1 = 0; tcb2 = 0;
            double t77td = DJM0 + DJM77;
            double t77tf = TTMTAI / DAYSEC;
            double tdb0 = TDB0 / DAYSEC;
            double elbb = ELB / (1.0 - ELB);
            double d, f;

            if (Abs(tdb1) > Abs(tdb2))
            {
                d = t77td - tdb1;
                f = tdb2 - tdb0;
                tcb1 = tdb1;
                tcb2 = f - (d - (f - t77tf)) * elbb;
            }
            else
            {
                d = t77td - tdb2;
                f = tdb1 - tdb0;
                tcb1 = f - (d - (f - t77tf)) * elbb;
                tcb2 = tdb2;
            }
            return 0;
        }
    }
}
