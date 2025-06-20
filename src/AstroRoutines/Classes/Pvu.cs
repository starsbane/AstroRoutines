namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Update a pv-vector.
        /// </summary>
        /// <param name="dt">Time interval</param>
        /// <param name="pv">PV-vector</param>
        /// <param name="upv">Updated PV-vector</param>
        public static void Pvu(double dt, double[,] pv, ref double[,] upv)
        {
            Ppsp(pv.GetRow(0), dt, pv.GetRow(1), out var upvRow0);
            upv.SetRow(0, upvRow0);

            var upvRow1 = new double[3];
            Cp(pv.GetRow(1), ref upvRow1);
            upv.SetRow(1, upvRow1);
        }
    }
}
