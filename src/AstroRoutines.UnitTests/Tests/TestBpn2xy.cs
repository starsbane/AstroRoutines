namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Bpn2xy function.
        /// </summary>
        /// <remarks>
        /// Extract CIP X,Y coordinates from bias-precession-nutation matrix.
        /// </remarks>
        [Fact]
        public void TestBpn2xy()
        {
            var status = 0;
            var rbpn = new double[3, 3];
            double x, y;

            rbpn[0, 0] =  9.999962358680738e-1;
            rbpn[0, 1] = -2.516417057665452e-3;
            rbpn[0, 2] = -1.093569785342370e-3;

            rbpn[1, 0] =  2.516462370370876e-3;
            rbpn[1, 1] =  9.999968329010883e-1;
            rbpn[1, 2] =  4.006159587358310e-5;

            rbpn[2, 0] =  1.093465510215479e-3;
            rbpn[2, 1] = -4.281337229063151e-5;
            rbpn[2, 2] =  9.999994012499173e-1;

            Bpn2xy(rbpn, out x, out y);

            Vvd(x,  1.093465510215479e-3, 1e-12, "Bpn2xy", "x", ref status);
            Vvd(y, -4.281337229063151e-5, 1e-12, "Bpn2xy", "y", ref status);

            Assert.Equal(0, status);
        }
    }
}
