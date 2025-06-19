namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Rotate an r-matrix about the y-axis.
    /// </summary>
    /// <param name="theta">Angle (radians)</param>
    /// <param name="r">R-matrix, rotated</param>
    public static void Ry(double theta, ref double[,] r)
    {
        double s, c, a00, a01, a02, a20, a21, a22;

        s = Sin(theta);
        c = Cos(theta);

        a00 = c * r[0, 0] - s * r[2, 0];
        a01 = c * r[0, 1] - s * r[2, 1];
        a02 = c * r[0, 2] - s * r[2, 2];
        a20 = s * r[0, 0] + c * r[2, 0];
        a21 = s * r[0, 1] + c * r[2, 1];
        a22 = s * r[0, 2] + c * r[2, 2];

        r[0, 0] = a00;
        r[0, 1] = a01;
        r[0, 2] = a02;
        r[2, 0] = a20;
        r[2, 1] = a21;
        r[2, 2] = a22;
    }
}
