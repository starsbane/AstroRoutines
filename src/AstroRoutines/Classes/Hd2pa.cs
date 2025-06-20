using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Parallactic angle for a given hour angle and declination.
        /// </summary>
        /// <param name="ha">hour angle</param>
        /// <param name="dec">declination</param>
        /// <param name="phi">site latitude</param>
        /// <returns>parallactic angle</returns>
        public static double Hd2pa(double ha, double dec, double phi)
        {
            var cp = Cos(phi);
            var sqsz = cp * Sin(ha);
            var cqsz = Sin(phi) * Cos(dec) - cp * Sin(dec) * Cos(ha);
            return ((sqsz != 0.0 || cqsz != 0.0) ? Atan2(sqsz, cqsz) : 0.0);

            /* Finished. */
        }
    }
}
