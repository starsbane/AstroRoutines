namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transform a star's ICRS catalog entry (epoch J2000.0) into ICRS astrometric place.
        /// </summary>
        /// <param name="rc">ICRS right ascension at J2000.0 (radians, Note 1)</param>
        /// <param name="dc">ICRS declination at J2000.0 (radians, Note 1)</param>
        /// <param name="pr">RA proper motion (radians/year; Note 2)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="date1">TDB as a 2-part...</param>
        /// <param name="date2">...Julian Date (Note 3)</param>
        /// <param name="ra">ICRS astrometric RA (radians)</param>
        /// <param name="da">ICRS astrometric Dec (radians)</param>
        public static void Atcc13(double rc, double dc, double pr, double pd, double px, double rv,
                                 double date1, double date2, ref double ra, ref double da)
        {
            var astrom = new ASTROM();
            double eo = 0;

            /* Star-independent astrometry parameters */
            Apci13(date1, date2, ref astrom, out eo);

            /* Transform the coordinates. */
            Atccq(rc, dc, pr, pd, px, rv, ref astrom, ref ra, ref da);

            /* Finished. */
        }
    }
}
