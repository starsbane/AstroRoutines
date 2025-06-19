namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equatorial to horizon coordinates:  transform hour angle and
        /// declination to azimuth and altitude.
        /// </summary>
        /// <param name="ha">hour angle (local)</param>
        /// <param name="dec">declination</param>
        /// <param name="phi">site latitude</param>
        /// <param name="az">azimuth</param>
        /// <param name="el">altitude (informally, elevation)</param>
        public static void Hd2ae(double ha, double dec, double phi, ref double az, ref double el)
        {
            double sh, ch, sd, cd, sp, cp, x, y, z, r, a;

            /* Useful trig functions. */
            sh = Sin(ha);
            ch = Cos(ha);
            sd = Sin(dec);
            cd = Cos(dec);
            sp = Sin(phi);
            cp = Cos(phi);

            /* Az,Alt unit vector. */
            x = -ch * cd * sp + sd * cp;
            y = -sh * cd;
            z = ch * cd * cp + sd * sp;

            /* To spherical. */
            r = Sqrt(x * x + y * y);
            a = (r != 0.0) ? Atan2(y, x) : 0.0;
            az = (a < 0.0) ? a + D2PI : a;
            el = Atan2(z, r);

            /* Finished. */
        }
    }
}
