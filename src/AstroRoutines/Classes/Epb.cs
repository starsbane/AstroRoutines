// Epb.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Julian Date to Besselian Epoch.
        /// </summary>
        /// <param name="dj1">Julian Date (Notes 3,4)</param>
        /// <param name="dj2">Julian Date (Notes 3,4)</param>
        /// <returns>Besselian Epoch.</returns>
        public static double Epb(double dj1, double dj2)
        {
            /* J2000.0-B1900.0 (2415019.81352) in days */
            const double D1900 = 36524.68648;

            return 1900.0 + ((dj1 - DJ00) + (dj2 + D1900)) / DTY;

            /* Finished. */
        }
    }
}
