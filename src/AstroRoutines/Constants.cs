using System;
using static System.Math;

namespace AstroRoutines
{
    public static class Constants
    {
        /* Pi */
        public const double DPI = 3.141592653589793238462643;

        /* 2Pi */
        public const double D2PI = 6.283185307179586476925287;

        /* Radians to degrees */
        public const double DR2D = 57.29577951308232087679815;

        /* Degrees to radians */
        public const double DD2R = 1.745329251994329576923691e-2;

        /* Radians to arcseconds */
        public const double DR2AS = 206264.8062470963551564734;

        /* Arcseconds to radians */
        public const double DAS2R = 4.848136811095359935899141e-6;

        /* Seconds of time to radians */
        public const double DS2R = 7.272205216643039903848712e-5;

        /* Arcseconds in a full circle */
        public const double TURNAS = 1296000.0;

        /* Milliarcseconds to radians */
        public const double DMAS2R = DAS2R / 1e3;

        /* Length of tropical year B1900 (days) */
        public const double DTY = 365.242198781;

        /* Seconds per day. */
        public const double DAYSEC = 86400.0;

        /* Days per Julian year */
        public const double DJY = 365.25;

        /* Days per Julian century */
        public const double DJC = 36525.0;

        /* Days per Julian millennium */
        public const double DJM = 365250.0;

        /* Reference epoch (J2000.0), Julian Date */
        public const double DJ00 = 2451545.0;

        /* Julian Date of Modified Julian Date zero */
        public const double DJM0 = 2400000.5;

        /* Reference epoch (J2000.0), Modified Julian Date */
        public const double DJM00 = 51544.5;

        /* 1977 Jan 1.0 as MJD */
        public const double DJM77 = 43144.0;

        /* TT minus TAI (s) */
        public const double TTMTAI = 32.184;

        /* Astronomical unit (m, IAU 2012) */
        public const double DAU = 149597870.7e3;

        /* Speed of light (m/s) */
        public const double CMPS = 299792458.0;

        /* Light time for 1 au (s) */
        public const double AULT = DAU / CMPS;

        /* Speed of light (au per day) */
        public const double DC = DAYSEC / AULT;

        /* L_G = 1 - d(TT)/d(TCG) */
        public const double ELG = 6.969290134e-10;

        /* L_B = 1 - d(TDB)/d(TCB), and TDB (s) at TAI 1977/1/1.0 */
        public const double ELB = 1.550519768e-8;
        public const double TDB0 = -6.55e-5;

        /* Schwarzschild radius of the Sun (au) */
        /* = 2 * 1.32712440041e20 / (2.99792458e8)^2 / 1.49597870700e11 */
        public const double SRS = 1.97412574336e-8;

        /* Reference ellipsoids */
        public const int WGS84 = 1;
        public const int GRS80 = 2;
        public const int WGS72 = 3;

        /* Helper functions */
        public static double dint(double A) => A < 0.0 ? Ceiling(A) : Floor(A);
        public static double dnint(double A) => Abs(A) < 0.5 ? 0.0 : (A < 0.0 ? Ceiling(A - 0.5) : Floor(A + 0.5));
        public static double dsign(double A, double B) => B < 0.0 ? -Abs(A) : Abs(A);
        public static T gmax<T>(T A, T B) where T : IComparable<T> => A.CompareTo(B) > 0 ? A : B;
        public static T gmin<T>(T A, T B) where T : IComparable<T> => A.CompareTo(B) < 0 ? A : B;
    }
}
