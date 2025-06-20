namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pvdpv function.
        /// </summary>
        [Fact]
        public void TestPvdpv()
        {
            var status = 0;

            var a = new double[2, 3];
            var b = new double[2, 3];
            var adb = new double[2];

            a[0, 0] = 2.0;
            a[0, 1] = 2.0;
            a[0, 2] = 3.0;

            a[1, 0] = 6.0;
            a[1, 1] = 0.0;
            a[1, 2] = 4.0;

            b[0, 0] = 1.0;
            b[0, 1] = 3.0;
            b[0, 2] = 4.0;

            b[1, 0] = 0.0;
            b[1, 1] = 2.0;
            b[1, 2] = 8.0;

            Pvdpv(a, b, ref adb);

            Vvd(adb[0], 20.0, 1e-12, "Pvdpv", "1", ref status);
            Vvd(adb[1], 50.0, 1e-12, "Pvdpv", "2", ref status);

            Assert.Equal(0, status);
        }
    }
}
