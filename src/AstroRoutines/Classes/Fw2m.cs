namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Form rotation matrix given the Fukushima-Williams angles.
    /// </summary>
    /// <param name="gamb">F-W angle gamma_bar</param>
    /// <param name="phib">F-W angle phi_bar</param>
    /// <param name="psi">F-W angle psi</param>
    /// <param name="eps">F-W angle epsilon</param>
    /// <param name="r">Rotation matrix</param>
    public static void Fw2m(double gamb, double phib, double psi, double eps, ref double[,] r)
    {
        /* Construct the matrix. */
        Ir(ref r);
        Rz(gamb, ref r);
        Rx(phib, ref r);
        Rz(-psi, ref r);
        Rx(-eps, ref r);
    }
}
