namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pdp function.
        /// </summary>
        [Fact]
        public void TestPdp()
        {
            var status = 0;
			var a = new double[3];
			var b = new double[3];
			double adb;
			
			a[0] = 2.0;
			a[1] = 2.0;
			a[2] = 3.0;

			b[0] = 1.0;
			b[1] = 3.0;
			b[2] = 4.0;

            adb = Pdp(a, b);

            Vvd(adb, 20, 1e-12, "Pdp", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
