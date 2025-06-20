using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Jdcalf function.
        /// </summary>
        [Fact]
        public void TestJdcalf()
        {
            var status = 0;
            var iydmf = new int[4];
            int j;
			double dj1 = 2400000.5, dj2 = 50123.9999;

            j = Jdcalf(4, dj1, dj2, ref iydmf);

            Viv(iydmf[0], 1996, "Jdcalf", "y", ref status);
            Viv(iydmf[1], 2, "Jdcalf", "m", ref status);
            Viv(iydmf[2], 10, "Jdcalf", "d", ref status);
            Viv(iydmf[3], 9999, "Jdcalf", "f", ref status);
            Viv(j, 0, "Jdcalf", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
