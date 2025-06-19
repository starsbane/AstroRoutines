namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Rotate an r-matrix about the z-axis.
    /// </summary>
    /// <param name="phi">Angle (radians)</param>
    /// <param name="r">R-matrix, rotated</param>
    public static void Rz(double phi, ref double[,] r)
    {
        double s, c, a00, a01, a02, a10, a11, a12;

        s = Sin(phi);
        c = Cos(phi);

        a00 = c * r[0, 0] + s * r[1, 0];
        a01 = c * r[0, 1] + s * r[1, 1];
        a02 = c * r[0, 2] + s * r[1, 2];
        a10 = -s * r[0, 0] + c * r[1, 0];
        a11 = -s * r[0, 1] + c * r[1, 1];
        a12 = -s * r[0, 2] + c * r[1, 2];

        r[0, 0] = a00;
        r[0, 1] = a01;
        r[0, 2] = a02;
        r[1, 0] = a10;
        r[1, 1] = a11;
        r[1, 2] = a12;
    }
}
