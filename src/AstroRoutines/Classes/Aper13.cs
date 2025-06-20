using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the star-independent astrometry parameters, update only the Earth rotation angle.
        /// </summary>
        /// <param name="ut11">UT1 as a 2-part...</param>
        /// <param name="ut12">...Julian Date (Note 1)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Aper13(double ut11, double ut12, ref ASTROM astrom)
        {
            Aper(Era00(ut11, ut12), ref astrom);

            /* Finished. */
        }
    }
}
