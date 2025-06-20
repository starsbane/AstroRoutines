using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Besselian Epoch to Julian Date.
        /// </summary>
        /// <param name="epb">Besselian Epoch (e.g. 1957.3)</param>
        /// <param name="djm0">MJD zero-point: always 2400000.5</param>
        /// <param name="djm">Modified Julian Date</param>
        public static void Epb2jd(double epb, out double djm0, out double djm)
        {
            djm0 = DJM0;
            djm = 15019.81352 + (epb - 1900.0) * DTY;

            /* Finished. */
        }
    }
}
