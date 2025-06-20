using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Approximate geocentric position and velocity of the Moon.
		/// </summary>
		/// <param name="date1">TT date part A (Notes 1,4)</param>
		/// <param name="date2">TT date part B (Notes 1,4)</param>
		/// <param name="pv">Moon p,v, GCRS (au, au/d, Note 5)</param>
        public static void Moon98(double date1, double date2, ref double[,] pv)
        {
            /*
            **  Coefficients for fundamental arguments:
            **
            **  . Powers of time in Julian centuries
            **  . Units are degrees.
            */

            /* Moon's mean longitude (wrt mean equinox and ecliptic of date) */
            const double elp0 = 218.31665436;        /* Simon et al. (1994). */
            const double elp1 = 481267.88123421;
            const double elp2 = -0.0015786;
            const double elp3 = 1.0 / 538841.0;
            const double elp4 = -1.0 / 65194000.0;
            double elp, delp;

            /* Moon's mean elongation */
            const double d0 = 297.8501921;
            const double d1 = 445267.1114034;
            const double d2 = -0.0018819;
            const double d3 = 1.0 / 545868.0;
            const double d4 = 1.0 / 113065000.0;
            double d, dd;

            /* Sun's mean anomaly */
            const double em0 = 357.5291092;
            const double em1 = 35999.0502909;
            const double em2 = -0.0001536;
            const double em3 = 1.0 / 24490000.0;
            const double em4 = 0.0;
            double em, dem;

            /* Moon's mean anomaly */
            const double emp0 = 134.9633964;
            const double emp1 = 477198.8675055;
            const double emp2 = 0.0087414;
            const double emp3 = 1.0 / 69699.0;
            const double emp4 = -1.0 / 14712000.0;
            double emp, demp;

            /* Mean distance of the Moon from its ascending node */
            const double f0 = 93.2720950;
            const double f1 = 483202.0175233;
            const double f2 = -0.0036539;
            const double f3 = 1.0 / 3526000.0;
            const double f4 = 1.0 / 863310000.0;
            double f, df;

            /*
            ** Other arguments
            */

            /* Meeus A_1, due to Venus (deg) */
            const double a10 = 119.75;
            const double a11 = 131.849;
            double a1, da1;

            /* Meeus A_2, due to Jupiter (deg) */
            const double a20 = 53.09;
            const double a21 = 479264.290;
            double a2, da2;

            /* Meeus A_3, due to sidereal motion of the Moon in longitude (deg) */
            const double a30 = 313.45;
            const double a31 = 481266.484;
            double a3, da3;

            /* Coefficients for Meeus "additive terms" (deg) */
            const double al1 = 0.003958;
            const double al2 = 0.001962;
            const double al3 = 0.000318;
            const double ab1 = -0.002235;
            const double ab2 = 0.000382;
            const double ab3 = 0.000175;
            const double ab4 = 0.000175;
            const double ab5 = 0.000127;
            const double ab6 = -0.000115;

            /* Fixed term in distance (m) */
            const double r0 = 385000560.0;

            /* Coefficients for (dimensionless) E factor */
            const double e1 = -0.002516;
            const double e2 = -0.0000074;
            double e, de, esq, desq;

            /*
            ** Coefficients for Moon longitude and distance series
            */
            var tlr = new[]
            {
                new {nd = 0,  nem = 0,  nemp = 1,  nf = 0,  coefl = 6.288774, coefr = -20905355.0},
                new {nd = 2,  nem = 0,  nemp = -1, nf = 0,  coefl = 1.274027, coefr = -3699111.0},
                new {nd = 2,  nem = 0,  nemp = 0,  nf = 0,  coefl = 0.658314, coefr = -2955968.0},
                new {nd = 0,  nem = 0,  nemp = 2,  nf = 0,  coefl = 0.213618, coefr = -569925.0},
                new {nd = 0,  nem = 1,  nemp = 0,  nf = 0,  coefl = -0.185116, coefr = 48888.0},
                new {nd = 0,  nem = 0,  nemp = 0,  nf = 2,  coefl = -0.114332, coefr = -3149.0},
                new {nd = 2,  nem = 0,  nemp = -2, nf = 0,  coefl = 0.058793, coefr = 246158.0},
                new {nd = 2,  nem = -1, nemp = -1, nf = 0,  coefl = 0.057066, coefr = -152138.0},
                new {nd = 2,  nem = 0,  nemp = 1,  nf = 0,  coefl = 0.053322, coefr = -170733.0},
                new {nd = 2,  nem = -1, nemp = 0,  nf = 0,  coefl = 0.045758, coefr = -204586.0},
                new {nd = 0,  nem = 1,  nemp = -1, nf = 0,  coefl = -0.040923, coefr = -129620.0},
                new {nd = 1,  nem = 0,  nemp = 0,  nf = 0,  coefl = -0.034720, coefr = 108743.0},
                new {nd = 0,  nem = 1,  nemp = 1,  nf = 0,  coefl = -0.030383, coefr = 104755.0},
                new {nd = 2,  nem = 0,  nemp = 0,  nf = -2, coefl = 0.015327, coefr = 10321.0},
                new {nd = 0,  nem = 0,  nemp = 1,  nf = 2,  coefl = -0.012528, coefr = 0.0},
                new {nd = 0,  nem = 0,  nemp = 1,  nf = -2, coefl = 0.010980, coefr = 79661.0},
                new {nd = 4,  nem = 0,  nemp = -1, nf = 0,  coefl = 0.010675, coefr = -34782.0},
                new {nd = 0,  nem = 0,  nemp = 3,  nf = 0,  coefl = 0.010034, coefr = -23210.0},
                new {nd = 4,  nem = 0,  nemp = -2, nf = 0,  coefl = 0.008548, coefr = -21636.0},
                new {nd = 2,  nem = 1,  nemp = -1, nf = 0,  coefl = -0.007888, coefr = 24208.0},
                new {nd = 2,  nem = 1,  nemp = 0,  nf = 0,  coefl = -0.006766, coefr = 30824.0},
                new {nd = 1,  nem = 0,  nemp = -1, nf = 0,  coefl = -0.005163, coefr = -8379.0},
                new {nd = 1,  nem = 1,  nemp = 0,  nf = 0,  coefl = 0.004987, coefr = -16675.0},
                new {nd = 2,  nem = -1, nemp = 1,  nf = 0,  coefl = 0.004036, coefr = -12831.0},
                new {nd = 2,  nem = 0,  nemp = 2,  nf = 0,  coefl = 0.003994, coefr = -10445.0},
                new {nd = 4,  nem = 0,  nemp = 0,  nf = 0,  coefl = 0.003861, coefr = -11650.0},
                new {nd = 2,  nem = 0,  nemp = -3, nf = 0,  coefl = 0.003665, coefr = 14403.0},
                new {nd = 0,  nem = 1,  nemp = -2, nf = 0,  coefl = -0.002689, coefr = -7003.0},
                new {nd = 2,  nem = 0,  nemp = -1, nf = 2,  coefl = -0.002602, coefr = 0.0},
                new {nd = 2,  nem = -1, nemp = -2, nf = 0,  coefl = 0.002390, coefr = 10056.0},
                new {nd = 1,  nem = 0,  nemp = 1,  nf = 0,  coefl = -0.002348, coefr = 6322.0},
                new {nd = 2,  nem = -2, nemp = 0,  nf = 0,  coefl = 0.002236, coefr = -9884.0},
                new {nd = 0,  nem = 1,  nemp = 2,  nf = 0,  coefl = -0.002120, coefr = 5751.0},
                new {nd = 0,  nem = 2,  nemp = 0,  nf = 0,  coefl = -0.002069, coefr = 0.0},
                new {nd = 2,  nem = -2, nemp = -1, nf = 0,  coefl = 0.002048, coefr = -4950.0},
                new {nd = 2,  nem = 0,  nemp = 1,  nf = -2, coefl = -0.001773, coefr = 4130.0},
                new {nd = 2,  nem = 0,  nemp = 0,  nf = 2,  coefl = -0.001595, coefr = 0.0},
                new {nd = 4,  nem = -1, nemp = -1, nf = 0,  coefl = 0.001215, coefr = -3958.0},
                new {nd = 0,  nem = 0,  nemp = 2,  nf = 2,  coefl = -0.001110, coefr = 0.0},
                new {nd = 3,  nem = 0,  nemp = -1, nf = 0,  coefl = -0.000892, coefr = 3258.0},
                new {nd = 2,  nem = 1,  nemp = 1,  nf = 0,  coefl = -0.000810, coefr = 2616.0},
                new {nd = 4,  nem = -1, nemp = -2, nf = 0,  coefl = 0.000759, coefr = -1897.0},
                new {nd = 0,  nem = 2,  nemp = -1, nf = 0,  coefl = -0.000713, coefr = -2117.0},
                new {nd = 2,  nem = 2,  nemp = -1, nf = 0,  coefl = -0.000700, coefr = 2354.0},
                new {nd = 2,  nem = 1,  nemp = -2, nf = 0,  coefl = 0.000691, coefr = 0.0},
                new {nd = 2,  nem = -1, nemp = 0,  nf = -2, coefl = 0.000596, coefr = 0.0},
                new {nd = 4,  nem = 0,  nemp = 1,  nf = 0,  coefl = 0.000549, coefr = -1423.0},
                new {nd = 0,  nem = 0,  nemp = 4,  nf = 0,  coefl = 0.000537, coefr = -1117.0},
                new {nd = 4,  nem = -1, nemp = 0,  nf = 0,  coefl = 0.000520, coefr = -1571.0},
                new {nd = 1,  nem = 0,  nemp = -2, nf = 0,  coefl = -0.000487, coefr = -1739.0},
                new {nd = 2,  nem = 1,  nemp = 0,  nf = -2, coefl = -0.000399, coefr = 0.0},
                new {nd = 0,  nem = 0,  nemp = 2,  nf = -2, coefl = -0.000381, coefr = -4421.0},
                new {nd = 1,  nem = 1,  nemp = 1,  nf = 0,  coefl = 0.000351, coefr = 0.0},
                new {nd = 3,  nem = 0,  nemp = -2, nf = 0,  coefl = -0.000340, coefr = 0.0},
                new {nd = 4,  nem = 0,  nemp = -3, nf = 0,  coefl = 0.000330, coefr = 0.0},
                new {nd = 2,  nem = -1, nemp = 2,  nf = 0,  coefl = 0.000327, coefr = 0.0},
                new {nd = 0,  nem = 2,  nemp = 1,  nf = 0,  coefl = -0.000323, coefr = 1165.0},
                new {nd = 1,  nem = 1,  nemp = -1, nf = 0,  coefl = 0.000299, coefr = 0.0},
                new {nd = 2,  nem = 0,  nemp = 3,  nf = 0,  coefl = 0.000294, coefr = 0.0},
                new {nd = 2,  nem = 0,  nemp = -1, nf = -2, coefl = 0.000000, coefr = 8752.0}
            };

            var NLR = tlr.Length;

            /*
            ** Coefficients for Moon latitude series
            */
            var tb = new[]
            {
                new {nd = 0,  nem = 0,  nemp = 0,  nf = 1,  coefb = 5.128122},
                new {nd = 0,  nem = 0,  nemp = 1,  nf = 1,  coefb = 0.280602},
                new {nd = 0,  nem = 0,  nemp = 1,  nf = -1, coefb = 0.277693},
                new {nd = 2,  nem = 0,  nemp = 0,  nf = -1, coefb = 0.173237},
                new {nd = 2,  nem = 0,  nemp = -1, nf = 1,  coefb = 0.055413},
                new {nd = 2,  nem = 0,  nemp = -1, nf = -1, coefb = 0.046271},
                new {nd = 2,  nem = 0,  nemp = 0,  nf = 1,  coefb = 0.032573},
                new {nd = 0,  nem = 0,  nemp = 2,  nf = 1,  coefb = 0.017198},
                new {nd = 2,  nem = 0,  nemp = 1,  nf = -1, coefb = 0.009266},
                new {nd = 0,  nem = 0,  nemp = 2,  nf = -1, coefb = 0.008822},
                new {nd = 2,  nem = -1, nemp = 0,  nf = -1, coefb = 0.008216},
                new {nd = 2,  nem = 0,  nemp = -2, nf = -1, coefb = 0.004324},
                new {nd = 2,  nem = 0,  nemp = 1,  nf = 1,  coefb = 0.004200},
                new {nd = 2,  nem = 1,  nemp = 0,  nf = -1, coefb = -0.003359},
                new {nd = 2,  nem = -1, nemp = -1, nf = 1,  coefb = 0.002463},
                new {nd = 2,  nem = -1, nemp = 0,  nf = 1,  coefb = 0.002211},
                new {nd = 2,  nem = -1, nemp = -1, nf = -1, coefb = 0.002065},
                new {nd = 0,  nem = 1,  nemp = -1, nf = -1, coefb = -0.001870},
                new {nd = 4,  nem = 0,  nemp = -1, nf = -1, coefb = 0.001828},
                new {nd = 0,  nem = 1,  nemp = 0,  nf = 1,  coefb = -0.001794},
                new {nd = 0,  nem = 0,  nemp = 0,  nf = 3,  coefb = -0.001749},
                new {nd = 0,  nem = 1,  nemp = -1, nf = 1,  coefb = -0.001565},
                new {nd = 1,  nem = 0,  nemp = 0,  nf = 1,  coefb = -0.001491},
                new {nd = 0,  nem = 1,  nemp = 1,  nf = 1,  coefb = -0.001475},
                new {nd = 0,  nem = 1,  nemp = 1,  nf = -1, coefb = -0.001410},
                new {nd = 0,  nem = 1,  nemp = 0,  nf = -1, coefb = -0.001344},
                new {nd = 1,  nem = 0,  nemp = 0,  nf = -1, coefb = -0.001335},
                new {nd = 0,  nem = 0,  nemp = 3,  nf = 1,  coefb = 0.001107},
                new {nd = 4,  nem = 0,  nemp = 0,  nf = -1, coefb = 0.001021},
                new {nd = 4,  nem = 0,  nemp = -1, nf = 1,  coefb = 0.000833},
                new {nd = 0,  nem = 0,  nemp = 1,  nf = -3, coefb = 0.000777},
                new {nd = 4,  nem = 0,  nemp = -2, nf = 1,  coefb = 0.000671},
                new {nd = 2,  nem = 0,  nemp = 0,  nf = -3, coefb = 0.000607},
                new {nd = 2,  nem = 0,  nemp = 2,  nf = -1, coefb = 0.000596},
                new {nd = 2,  nem = -1, nemp = 1,  nf = -1, coefb = 0.000491},
                new {nd = 2,  nem = 0,  nemp = -2, nf = 1,  coefb = -0.000451},
                new {nd = 0,  nem = 0,  nemp = 3,  nf = -1, coefb = 0.000439},
                new {nd = 2,  nem = 0,  nemp = 2,  nf = 1,  coefb = 0.000422},
                new {nd = 2,  nem = 0,  nemp = -3, nf = -1, coefb = 0.000421},
                new {nd = 2,  nem = 1,  nemp = -1, nf = 1,  coefb = -0.000366},
                new {nd = 2,  nem = 1,  nemp = 0,  nf = 1,  coefb = -0.000351},
                new {nd = 4,  nem = 0,  nemp = 0,  nf = 1,  coefb = 0.000331},
                new {nd = 2,  nem = -1, nemp = 1,  nf = 1,  coefb = 0.000315},
                new {nd = 2,  nem = -2, nemp = 0,  nf = -1, coefb = 0.000302},
                new {nd = 0,  nem = 0,  nemp = 1,  nf = 3,  coefb = -0.000283},
                new {nd = 2,  nem = 1,  nemp = 1,  nf = -1, coefb = -0.000229},
                new {nd = 1,  nem = 1,  nemp = 0,  nf = -1, coefb = 0.000223},
                new {nd = 1,  nem = 1,  nemp = 0,  nf = 1,  coefb = 0.000223},
                new {nd = 0,  nem = 1,  nemp = -2, nf = -1, coefb = -0.000220},
                new {nd = 2,  nem = 1,  nemp = -1, nf = -1, coefb = -0.000220},
                new {nd = 1,  nem = 0,  nemp = 1,  nf = 1,  coefb = -0.000185},
                new {nd = 2,  nem = -1, nemp = -2, nf = -1, coefb = 0.000181},
                new {nd = 0,  nem = 1,  nemp = 2,  nf = 1,  coefb = -0.000177},
                new {nd = 4,  nem = 0,  nemp = -2, nf = -1, coefb = 0.000176},
                new {nd = 4,  nem = -1, nemp = -1, nf = -1, coefb = 0.000166},
                new {nd = 1,  nem = 0,  nemp = 1,  nf = -1, coefb = -0.000164},
                new {nd = 4,  nem = 0,  nemp = 1,  nf = -1, coefb = 0.000132},
                new {nd = 1,  nem = 0,  nemp = -1, nf = -1, coefb = -0.000119},
                new {nd = 4,  nem = -1, nemp = 0,  nf = -1, coefb = 0.000115},
                new {nd = 2,  nem = -2, nemp = 0,  nf = 1,  coefb = 0.000107}
            };

            var NB = tb.Length;

            /* Miscellaneous */
            int n, i;
            double t, elpmf, delpmf, vel, vdel, vr, vdr, a1mf, da1mf, a1pf,
                   da1pf, dlpmp, slpmp, vb, vdb, v, dv, emn, empn, dn, fn, en,
                   den, arg, darg, farg, coeff, el, del, r, dr, b, db, gamb = 0,
                   phib = 0, psib = 0, epsa = 0;
            var rm = new double[3, 3];

            /* ------------------------------------------------------------------ */

            /* Centuries since J2000.0 */
            t = ((date1 - DJ00) + date2) / DJC;

            /* --------------------- */
            /* Fundamental arguments */
            /* --------------------- */

            /* Arguments (radians) and derivatives (radians per Julian century)
               for the current date. */

            /* Moon's mean longitude. */
            elp = DD2R * (elp0
                        + (elp1
                        + (elp2
                        + (elp3
                        + elp4 * t) * t) * t) * t % 360.0);
            delp = DD2R * (elp1
                        + (elp2 * 2.0
                        + (elp3 * 3.0
                        + elp4 * 4.0 * t) * t) * t);

            /* Moon's mean elongation. */
            d = DD2R * (d0
                      + (d1
                      + (d2
                      + (d3
                      + d4 * t) * t) * t) * t % 360.0);
            dd = DD2R * (d1
                      + (d2 * 2.0
                      + (d3 * 3.0
                      + d4 * 4.0 * t) * t) * t);

            /* Sun's mean anomaly. */
            em = DD2R * (em0
                       + (em1
                       + (em2
                       + (em3
                       + em4 * t) * t) * t) * t % 360.0);
            dem = DD2R * (em1
                       + (em2 * 2.0
                       + (em3 * 3.0
                       + em4 * 4.0 * t) * t) * t);

            /* Moon's mean anomaly. */
            emp = DD2R * (emp0
                        + (emp1
                        + (emp2
                        + (emp3
                        + emp4 * t) * t) * t) * t % 360.0);
            demp = DD2R * (emp1
                        + (emp2 * 2.0
                        + (emp3 * 3.0
                        + emp4 * 4.0 * t) * t) * t);

            /* Mean distance of the Moon from its ascending node. */
            f = DD2R * (f0
                      + (f1
                      + (f2
                      + (f3
                      + f4 * t) * t) * t) * t % 360.0);
            df = DD2R * (f1
                      + (f2 * 2.0
                      + (f3 * 3.0
                      + f4 * 4.0 * t) * t) * t);

            /* Meeus further arguments. */
            a1 = DD2R * (a10 + a11 * t);
            da1 = DD2R * a11;
            a2 = DD2R * (a20 + a21 * t);
            da2 = DD2R * a21;
            a3 = DD2R * (a30 + a31 * t);
            da3 = DD2R * a31;

            /* E-factor, and square. */
            e = 1.0 + (e1 + e2 * t) * t;
            de = e1 + 2.0 * e2 * t;
            esq = e * e;
            desq = 2.0 * e * de;

            /* Use the Meeus additive terms (deg) to start off the summations. */
            elpmf = elp - f;
            delpmf = delp - df;
            vel = al1 * Sin(a1)
                + al2 * Sin(elpmf)
                + al3 * Sin(a2);
            vdel = al1 * Cos(a1) * da1
                 + al2 * Cos(elpmf) * delpmf
                 + al3 * Cos(a2) * da2;

            vr = 0.0;
            vdr = 0.0;

            a1mf = a1 - f;
            da1mf = da1 - df;
            a1pf = a1 + f;
            da1pf = da1 + df;
            dlpmp = elp - emp;
            slpmp = elp + emp;
            vb = ab1 * Sin(elp)
               + ab2 * Sin(a3)
               + ab3 * Sin(a1mf)
               + ab4 * Sin(a1pf)
               + ab5 * Sin(dlpmp)
               + ab6 * Sin(slpmp);
            vdb = ab1 * Cos(elp) * delp
                + ab2 * Cos(a3) * da3
                + ab3 * Cos(a1mf) * da1mf
                + ab4 * Cos(a1pf) * da1pf
                + ab5 * Cos(dlpmp) * (delp - demp)
                + ab6 * Cos(slpmp) * (delp + demp);

            /* ----------------- */
            /* Series expansions */
            /* ----------------- */

            /* Longitude and distance plus derivatives. */
            for (n = NLR - 1; n >= 0; n--)
            {
                dn = (double)tlr[n].nd;
                emn = (double)(i = tlr[n].nem);
                empn = (double)tlr[n].nemp;
                fn = (double)tlr[n].nf;
                switch (Abs(i))
                {
                    case 1:
                        en = e;
                        den = de;
                        break;
                    case 2:
                        en = esq;
                        den = desq;
                        break;
                    default:
                        en = 1.0;
                        den = 0.0;
                        break;
                }
                arg = dn * d + emn * em + empn * emp + fn * f;
                darg = dn * dd + emn * dem + empn * demp + fn * df;
                farg = Sin(arg);
                v = farg * en;
                dv = Cos(arg) * darg * en + farg * den;
                coeff = tlr[n].coefl;
                vel += coeff * v;
                vdel += coeff * dv;
                farg = Cos(arg);
                v = farg * en;
                dv = -Sin(arg) * darg * en + farg * den;
                coeff = tlr[n].coefr;
                vr += coeff * v;
                vdr += coeff * dv;
            }
            el = elp + DD2R * vel;
            del = (delp + DD2R * vdel) / DJC;
            r = (vr + r0) / DAU;
            dr = vdr / DAU / DJC;

            /* Latitude plus derivative. */
            for (n = NB - 1; n >= 0; n--)
            {
                dn = (double)tb[n].nd;
                emn = (double)(i = tb[n].nem);
                empn = (double)tb[n].nemp;
                fn = (double)tb[n].nf;
                switch (Abs(i))
                {
                    case 1:
                        en = e;
                        den = de;
                        break;
                    case 2:
                        en = esq;
                        den = desq;
                        break;
                    default:
                        en = 1.0;
                        den = 0.0;
                        break;
                }
                arg = dn * d + emn * em + empn * emp + fn * f;
                darg = dn * dd + emn * dem + empn * demp + fn * df;
                farg = Sin(arg);
                v = farg * en;
                dv = Cos(arg) * darg * en + farg * den;
                coeff = tb[n].coefb;
                vb += coeff * v;
                vdb += coeff * dv;
            }
            b = vb * DD2R;
            db = vdb * DD2R / DJC;

            /* ------------------------------ */
            /* Transformation into final form */
            /* ------------------------------ */

            /* Longitude, latitude to x, y, z (au). */
            S2pv(el, b, r, del, db, dr, ref pv);

            /* IAU 2006 Fukushima-Williams bias+precession angles. */
            Pfw06(date1, date2, out gamb, out phib, out psib, out epsa);

            /* Mean ecliptic coordinates to GCRS rotation matrix. */
            Ir(ref rm);
            Rz(psib, ref rm);
            Rx(-phib, ref rm);
            Rz(-gamb, ref rm);

            /* Rotate the Moon position and velocity into GCRS (Note 6). */
            Rxpv(rm, pv, ref pv);

            /* Finished. */
        }
    }
}
