namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Sepp function.
        /// </summary>
        [Fact]
        public void TestSepp()
        {
            var status = 0;

            var a = new double[3];
            var b = new double[3];

            a[0] = 1.0;
            a[1] = 0.1;
            a[2] = 0.2;

            b[0] = -3.0;
            b[1] = 1e-3;
            b[2] = 0.2;

            var s = Sepp(a, b);

            Vvd(s, 2.860391919024660768, 1e-12, "Sepp", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
