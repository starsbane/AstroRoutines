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
        /// <param name="ebpv">Earth barycentric position/velocity (au, au/day)</param>
        /// <param name="ehp">Earth heliocentric position (au)</param>
        /// <param name="x">CIP X (components of unit vector)</param>
        /// <param name="y">CIP Y (components of unit vector)</param>
        /// <param name="s">the CIO locator s (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apci(double date1, double date2, double[,] ebpv, double[] ehp,
                               double x, double y, double s, ref ASTROM astrom)
        {
            Apcg(date1, date2, ebpv, ehp, ref astrom);
            C2ixys(x, y, s, ref astrom.bpn);
        }
    }
}
