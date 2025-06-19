// Epj2jd.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Julian Epoch to Julian Date.
        /// </summary>
        /// <param name="epj">Julian Epoch (e.g. 1996.8)</param>
        /// <param name="djm0">MJD zero-point: always 2400000.5</param>
        /// <param name="djm">Modified Julian Date</param>
        public static void Epj2jd(double epj, ref double djm0, ref double djm)
        {
            djm0 = DJM0;
            djm = DJM00 + (epj - 2000.0) * 365.25;

            /* Finished. */
        }
    }
}
