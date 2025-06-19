namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Outer (vector/cross) product of two pv-vectors.
    /// </summary>
    /// <param name="a">First PV-vector</param>
    /// <param name="b">Second PV-vector</param>
    /// <param name="axb">Result of a x b</param>
    public static void Pvxpv(double[,] a, double[,] b, double[,] axb)
    {
        double[,] wa = new double[2,3];
        double[,] wb = new double[2,3];
        double[] axbd = new double[3];
        double[] adxb = new double[3];

        // Make copies of the inputs
        Cpv(a, wa);
        Cpv(b, wb);

        // a x b = position part of result
		double[] axbRow0 = new double[3];
        Pxp(wa.GetRow(0), wb.GetRow(0), ref axbRow0);
		axb.SetRow(0, axbRow0);

        // a x bdot + adot x b = velocity part of result
        Pxp(wa.GetRow(0), wb.GetRow(1), ref axbd);
        Pxp(wa.GetRow(1), wb.GetRow(0), ref adxb);
		
		double[] axbRow1 = new double[3];
        Ppp(axbd, adxb, ref axbRow1);
		axb.SetRow(1, axbRow1);
    }
}
