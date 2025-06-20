using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Long-term precession of the equator.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="veq">equator pole unit vector</param>
        public static void Ltpequ(double epj, ref double[] veq)
        {
            /* Polynomial coefficients */
            const int NPOL = 4;
            double[,] xypol = {
                {  5453.282155,
                      0.4252841,
                     -0.00037173,
                     -0.000000152},
                {-73750.930350,
                     -0.7675452,
                     -0.00018725,
                      0.000000231}
            };

            /* Periodic coefficients */
            double[,] xyper = {
                { 256.75, -819.940624,75004.344875,81491.287984, 1558.515853},
                { 708.15,-8444.676815,  624.033993,  787.163481, 7774.939698},
                { 274.20, 2600.009459, 1251.136893, 1251.296102,-2219.534038},
                { 241.45, 2755.175630,-1102.212834,-1257.950837,-2523.969396},
                {2309.00, -167.659835,-2660.664980,-2966.799730,  247.850422},
                { 492.20,  871.855056,  699.291817,  639.744522, -846.485643},
                { 396.10,   44.769698,  153.167220,  131.600209,-1393.124055},
                { 288.90, -512.313065, -950.865637, -445.040117,  368.526116},
                { 231.10, -819.415595,  499.754645,  584.522874,  749.045012},
                {1610.00, -538.071099, -145.188210,  -89.756563,  444.704518},
                { 620.00, -189.793622,  558.116553,  524.429630,  235.934465},
                { 157.87, -402.922932,  -23.923029,  -13.549067,  374.049623},
                { 220.30,  179.516345, -165.405086, -210.157124, -171.330180},
                {1200.00,   -9.814756,    9.344131,  -44.919798,  -22.899655}
            };
            var NPER = xyper.GetLength(0);

            /* Miscellaneous */
            int i;
            double a, s, c;

            /* Centuries since J2000. */
            var t = (epj - 2000.0) / 100.0;

            /* Initialize X and Y accumulators. */
            var x = 0.0;
            var y = 0.0;

            /* Periodic terms. */
            var w = D2PI * t;
            for (i = 0; i < NPER; i++)
            {
                a = w / xyper[i, 0];
                s = Sin(a);
                c = Cos(a);
                x += c * xyper[i, 1] + s * xyper[i, 3];
                y += c * xyper[i, 2] + s * xyper[i, 4];
            }

            /* Polynomial terms. */
            w = 1.0;
            for (i = 0; i < NPOL; i++)
            {
                x += xypol[0, i] * w;
                y += xypol[1, i] * w;
                w *= t;
            }

            /* X and Y (direction cosines). */
            x *= DAS2R;
            y *= DAS2R;

            /* Form the equator pole vector. */
            veq[0] = x;
            veq[1] = y;
            w = 1.0 - x * x - y * y;
            veq[2] = w < 0.0 ? 0.0 : Sqrt(w);

            /* Finished. */
        }
    }
}
