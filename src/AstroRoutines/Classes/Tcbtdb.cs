namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Barycentric Coordinate Time, TCB, to Barycentric Dynamical Time, TDB.
        /// </summary>
        /// <param name="tcb1">TCB as a 2-part Julian Date</param>
        /// <param name="tcb2">TCB as a 2-part Julian Date</param>
        /// <param name="tdb1">TDB as a 2-part Julian Date</param>
        /// <param name="tdb2">TDB as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Tcbtdb(double tcb1, double tcb2, out double tdb1, out double tdb2)
        {
            tdb1 = 0; tdb2 = 0;
            var t77td = DJM0 + DJM77;
            var t77tf = TTMTAI / DAYSEC;
            var tdb0 = TDB0 / DAYSEC;
            double d;

            if (Abs(tcb1) > Abs(tcb2))
            {
                d = tcb1 - t77td;
                tdb1 = tcb1;
                tdb2 = tcb2 + tdb0 - (d + (tcb2 - t77tf)) * ELB;
            }
            else
            {
                d = tcb2 - t77td;
                tdb1 = tcb1 + tdb0 - (d + (tcb1 - t77tf)) * ELB;
                tdb2 = tcb2;
            }
            return 0;
        }
    }
}
