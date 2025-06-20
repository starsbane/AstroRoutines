namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ppp function.
        /// </summary>
        [Fact]
        public void TestPpp()
        {
            var status = 0;

            var a = new double[3];
            var b = new double[3];
            var apb = new double[3];
			a[0] = 2.0;
			a[1] = 2.0;
			a[2] = 3.0;
			
			b[0] = 1.0;
			b[1] = 3.0;
			b[2] = 4.0;

            Ppp(a, b, ref apb);

            Vvd(apb[0], 3.0, 1e-12, "Ppp", "0", ref status);
            Vvd(apb[1], 5.0, 1e-12, "Ppp", "1", ref status);
            Vvd(apb[2], 7.0, 1e-12, "Ppp", "2", ref status);

            Assert.Equal(0, status);
        }
    }
}
