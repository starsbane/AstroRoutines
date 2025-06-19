// Epj.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Julian Date to Julian Epoch.
        /// </summary>
        /// <param name="dj1">Julian Date (Note 4)</param>
        /// <param name="dj2">Julian Date (Note 4)</param>
        /// <returns>Julian Epoch</returns>
        public static double Epj(double dj1, double dj2)
        {
            double epj;

            epj = 2000.0 + ((dj1 - DJ00) + dj2) / DJY;

            return epj;

            /* Finished. */
        }
    }
}
