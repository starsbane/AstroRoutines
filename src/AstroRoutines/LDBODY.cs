// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
namespace AstroRoutines
{
    /// <summary>
    /// Body parameters for light deflection
    /// </summary>
    public class LDBODY
    {
        /// <summary>
        /// mass of the body (solar masses)
        /// </summary>
        public double bm;

        /// <summary>
        /// deflection limiter (radians^2/2)
        /// </summary>
        public double dl;

        /// <summary>
        /// barycentric PV of the body (au, au/day)
        /// </summary>
        public double[,] pv;

        public LDBODY()
        {
            bm = 0.0;
            dl = 0.0;
            pv = new double[2, 3];
        }
    }
}
