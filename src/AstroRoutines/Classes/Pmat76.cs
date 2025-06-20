using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Precession matrix from J2000.0 to a specified date, IAU 1976 model.
		/// </summary>
		/// <param name="date1">ending date, TT (Note 1)</param>
		/// <param name="date2">ending date, TT (Note 1)</param>
		/// <param name="rmatp">precession matrix, J2000.0 -> date1+date2</param>
        public static void Pmat76(double date1, double date2, ref double[,] rmatp)
        {
            var wmat = new double[3, 3];

            /* Precession Euler angles, J2000.0 to specified date. */
            Prec76(DJ00, 0.0, date1, date2, out var zeta, out var z, out var theta);

            /* Form the rotation matrix. */
            Ir(ref wmat);
            Rz(-zeta, ref wmat);
            Ry(theta, ref wmat);
            Rz(-z, ref wmat);
            Cr(wmat, ref rmatp);

            /* Finished. */
        }
    }
}
