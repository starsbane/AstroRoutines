namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pmp function.
        /// </summary>
        [Fact]
        public void TestPmp()
        {
            var a = new double[3];
            var b = new double[3];
            var amb = new double[3];
            var status = 0;

            a[0] = 2.0;
            a[1] = 2.0;
            a[2] = 3.0;

            b[0] = 1.0;
            b[1] = 3.0;
            b[2] = 4.0;

            Pmp(a, b, ref amb);

            Vvd(amb[0], 1.0, 1e-12, "Pmp", "0", ref status);
            Vvd(amb[1], -1.0, 1e-12, "Pmp", "1", ref status);
            Vvd(amb[2], -1.0, 1e-12, "Pmp", "2", ref status);

            Assert.Equal(0, status);
        }
    }
}
