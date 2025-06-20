using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the star-independent astrometry parameters, update only the Earth rotation angle, supplied by the caller explicitly.
        /// </summary>
        /// <param name="theta">Earth rotation angle (radians, Note 2)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Aper(double theta, ref ASTROM astrom)
        {
            astrom.eral = theta + astrom.along;

            /* Finished. */
        }
    }
}
