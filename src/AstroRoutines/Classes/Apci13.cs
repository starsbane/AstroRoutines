using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a terrestrial observer, prepare star-independent astrometry parameters for transformations between ICRS and geocentric CIRS coordinates.
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="eo">equation of the origins (ERA-GST, radians)</param>
        public static void Apci13(double date1, double date2, ref ASTROM astrom, out double eo)
        {
            double[,] ehpv = new double[2, 3];
            double[,] ebpv = new double[2, 3];
            double[,] r = new double[3, 3];
            double x = 0, y = 0, s;

            Epv00(date1, date2, ref ehpv, ref ebpv);
            Pnm06a(date1, date2, ref r);
            Bpn2xy(r, out x, out y);
            s = S06(date1, date2, x, y);

            double[] ehp = new double[3] { ehpv[0, 0], ehpv[0, 1], ehpv[0, 2] };
            Apci(date1, date2, ebpv, ehp, x, y, s, ref astrom);

            eo = Eors(r, s);
        }
    }
}
