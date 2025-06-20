namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a geocentric observer, prepare star-independent astrometry parameters for transformations between ICRS and GCRS coordinates.
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apcg13(double date1, double date2, ref ASTROM astrom)
        {
            var ehpv = new double[2, 3];
            var ebpv = new double[2, 3];

            Epv00(date1, date2, ref ehpv, ref ebpv);

            var ehp = ehpv.GetRow(0);
            Apcg(date1, date2, ebpv, ehp, ref astrom);
        }
    }
}
