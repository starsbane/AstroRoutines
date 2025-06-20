namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pxp function.
        /// </summary>
        [Fact]
        public void TestPxp()
        {
            var status = 0;

            var a = new double[3];
            var b = new double[3];
            var axb = new double[3];

            a[0] = 2.0;
            a[1] = 2.0;
            a[2] = 3.0;

            b[0] = 1.0;
            b[1] = 3.0;
            b[2] = 4.0;

            Pxp(a, b, ref axb);

            Vvd(axb[0], -1.0, 1e-12, "Pxp", "1", ref status);
            Vvd(axb[1], -5.0, 1e-12, "Pxp", "2", ref status);
            Vvd(axb[2], 4.0, 1e-12, "Pxp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
