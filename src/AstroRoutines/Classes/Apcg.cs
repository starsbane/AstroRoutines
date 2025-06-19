using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a geocentric observer, prepare star-independent astrometry parameters for transformations between ICRS and GCRS coordinates.
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="ebpv">Earth barycentric pos/vel (au, au/day)</param>
        /// <param name="ehp">Earth heliocentric position (au)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apcg(double date1, double date2, double[,] ebpv, double[] ehp, ref ASTROM astrom)
        {
            double[,] pv = new double[2, 3];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                    pv[i, j] = 0.0;

            Apcs(date1, date2, pv, ebpv, ehp, ref astrom);
        }
    }
}
