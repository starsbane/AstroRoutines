// pvppv.cs
namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Add one pv-vector to another.
    /// </summary>
    /// <param name="a">first pv-vector</param>
    /// <param name="b">second pv-vector</param>
    /// <param name="apb">a + b</param>
    public static void Pvppv(double[,] a, double[,] b, ref double[,] apb)
    {
        double[] apbRow0 = new double[3];
        double[] apbRow1 = new double[3];

        Ppp(a.GetRow(0), b.GetRow(0), ref apbRow0);
        Ppp(a.GetRow(1), b.GetRow(1), ref apbRow1);

        apb.SetRow(0, apbRow0);
        apb.SetRow(1, apbRow1);
    }
}
