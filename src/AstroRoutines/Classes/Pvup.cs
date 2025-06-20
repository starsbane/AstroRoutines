namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Update a pv-vector, discarding the velocity component.
        /// </summary>
        /// <param name="dt">Time interval</param>
        /// <param name="pv">PV-vector</param>
        /// <param name="p">Updated position vector</param>
        public static void Pvup(double dt, double[,] pv, ref double[] p)
        {
            p[0] = pv[0, 0] + dt * pv[1, 0];
            p[1] = pv[0, 1] + dt * pv[1, 1];
            p[2] = pv[0, 2] + dt * pv[1, 2];
        }
    }
}
