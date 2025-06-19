namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Horizon to equatorial coordinates: transform azimuth and altitude to hour angle and declination.
        /// </summary>
        /// <param name="az">azimuth</param>
        /// <param name="el">altitude (informally, elevation)</param>
        /// <param name="phi">site latitude</param>
        /// <param name="ha">hour angle (local)</param>
        /// <param name="dec">declination</param>
        public static void Ae2hd(double az, double el, double phi, out double ha, out double dec)
        {
            double sa = Sin(az);
            double ca = Cos(az);
            double se = Sin(el);
            double ce = Cos(el);
            double sp = Sin(phi);
            double cp = Cos(phi);

            double x = -ca * ce * sp + se * cp;
            double y = -sa * ce;
            double z = ca * ce * cp + se * sp;

            double r = Sqrt(x * x + y * y);
            ha = (r != 0.0) ? Atan2(y, x) : 0.0;
            dec = Atan2(z, r);
        }
    }
}
