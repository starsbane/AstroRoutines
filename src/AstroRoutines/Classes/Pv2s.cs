using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert position/velocity from Cartesian to spherical coordinates
        /// </summary>
        /// <param name="pv">pv-vector</param>
        /// <param name="theta">Longitude angle (radians)</param>
        /// <param name="phi">Latitude angle (radians)</param>
        /// <param name="r">Radial distance</param>
        /// <param name="td">Rate of change of theta</param>
        /// <param name="pd">Rate of change of phi</param>
        /// <param name="rd">Rate of change of r</param>
        public static void Pv2s(double[,] pv, 
                                out double theta, out double phi, out double r,
                                out double td, out double pd, out double rd)
        {
            double x, y, z, xd, yd, zd, rxy2, rxy, r2, rtrue, rw, xyp;

            // Components of position/velocity vector
            x = pv[0, 0];
            y = pv[0, 1];
            z = pv[0, 2];
            xd = pv[1, 0];
            yd = pv[1, 1];
            zd = pv[1, 2];

            // Component of r in XY plane squared
            rxy2 = x * x + y * y;

            // Modulus squared
            r2 = rxy2 + z * z;

            // Modulus
            rtrue = Sqrt(r2);

            // If null vector, move the origin along the direction of movement
            rw = rtrue;
            if (rtrue == 0.0)
            {
                x = xd;
                y = yd;
                z = zd;
                rxy2 = x * x + y * y;
                r2 = rxy2 + z * z;
                rw = Sqrt(r2);
            }

            // Position and velocity in spherical coordinates
            rxy = Sqrt(rxy2);
            xyp = x * xd + y * yd;

            if (rxy2 != 0.0)
            {
                theta = Atan2(y, x);
                phi = Atan2(z, rxy);
                td = (x * yd - y * xd) / rxy2;
                pd = (zd * rxy2 - z * xyp) / (r2 * rxy);
            }
            else
            {
                theta = 0.0;
                phi = (z != 0.0) ? Atan2(z, rxy) : 0.0;
                td = 0.0;
                pd = 0.0;
            }

            r = rtrue;
            rd = (rw != 0.0) ? (xyp + z * zd) / rw : 0.0;
        }
    }
}
