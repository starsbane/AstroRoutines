// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable GrammarMistakeInComment
namespace AstroRoutines
{
    public static class Constants
    {
        /// <summary>
        /// Pi
        /// </summary>
        public const double DPI = 3.141592653589793238462643;

        /// <summary>
        /// 2Pi
        /// </summary>
        public const double D2PI = 6.283185307179586476925287;

        /// <summary>
        /// Radians to degrees
        /// </summary>
        public const double DR2D = 57.29577951308232087679815;

        /// <summary>
        /// Degrees to radians
        /// </summary>
        public const double DD2R = 1.745329251994329576923691e-2;

        /// <summary>
        /// Radians to arcseconds
        /// </summary>
        public const double DR2AS = 206264.8062470963551564734;

        /// <summary>
        /// Arcseconds to radians
        /// </summary>
        public const double DAS2R = 4.848136811095359935899141e-6;

        /// <summary>
        /// Seconds of time to radians
        /// </summary>
        public const double DS2R = 7.272205216643039903848712e-5;

        /// <summary>
        /// Arcseconds in a full circle
        /// </summary>
        public const double TURNAS = 1296000.0;

        /// <summary>
        /// Milliarcseconds to radians
        /// </summary>
        public const double DMAS2R = DAS2R / 1e3;

        /// <summary>
        /// Length of tropical year B1900 (days)
        /// </summary>
        public const double DTY = 365.242198781;

        /// <summary>
        /// Seconds per day.
        /// </summary>
        public const double DAYSEC = 86400.0;

        /// <summary>
        /// Days per Julian year
        /// </summary>
        public const double DJY = 365.25;

        /// <summary>
        /// Days per Julian century
        /// </summary>
        public const double DJC = 36525.0;

        /// <summary>
        /// Days per Julian millennium
        /// </summary>
        public const double DJM = 365250.0;

        /// <summary>
        /// Reference epoch (J2000.0), Julian Date
        /// </summary>
        public const double DJ00 = 2451545.0;

        /// <summary>
        /// Julian Date of Modified Julian Date zero
        /// </summary>
        public const double DJM0 = 2400000.5;

        /// <summary>
        /// Reference epoch (J2000.0), Modified Julian Date
        /// </summary>
        public const double DJM00 = 51544.5;

        /// <summary>
        /// 1977 Jan 1.0 as MJD
        /// </summary>
        public const double DJM77 = 43144.0;

        /// <summary>
        /// TT minus TAI (s)
        /// </summary>
        public const double TTMTAI = 32.184;

        /// <summary>
        /// Astronomical unit (m, IAU 2012)
        /// </summary>
        public const double DAU = 149597870.7e3;

        /// <summary>
        /// Speed of light (m/s)
        /// </summary>
        public const double CMPS = 299792458.0;

        /// <summary>
        /// Light time for 1 au (s)
        /// </summary>
        public const double AULT = DAU / CMPS;

        /// <summary>
        /// Speed of light (au per day)
        /// </summary>
        public const double DC = DAYSEC / AULT;

        /// <summary>
        /// L_G = 1 - d(TT)/d(TCG)
        /// </summary>
        public const double ELG = 6.969290134e-10;

        /// <summary>
        /// L_B = 1 - d(TDB)/d(TCB)
        /// </summary>
        public const double ELB = 1.550519768e-8;

        /// <summary>
        /// TDB (s) at TAI 1977/1/1.0
        /// </summary>
        public const double TDB0 = -6.55e-5;

        /// <summary>
        /// Schwarzschild radius of the Sun (au) = 2 * 1.32712440041e20 / (2.99792458e8)^2 / 1.49597870700e11
        /// </summary>
        public const double SRS = 1.97412574336e-8;

        /// <summary>
        /// Reference ellipsoids: World Geodetic System 1984
        /// </summary>
        public const int WGS84 = 1;

        /// <summary>
        /// Reference ellipsoids: Geodetic Reference System 1980
        /// </summary>
        public const int GRS80 = 2;

        /// <summary>
        /// Reference ellipsoids: World Geodetic System 1972
        /// </summary>
        public const int WGS72 = 3;
    }
}
