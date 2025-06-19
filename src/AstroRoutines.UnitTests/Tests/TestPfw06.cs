namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pfw06 function.
        /// </summary>
        [Fact]
        public void TestPfw06()
        {
            double gamb;
            double phib;
            double psib;
            double epsa;
            var status = 0;

            Pfw06(2400000.5, 50123.9999, out gamb, out phib, out psib, out epsa);

            Vvd(gamb, -0.2243387670997995690e-5, 1e-16, "Pfw06", "gamb", ref status);
            Vvd(phib, 0.4091014602391312808, 1e-12, "Pfw06", "phib", ref status);
            Vvd(psib, -0.9501954178013031895e-3, 1e-14, "Pfw06", "psib", ref status);
            Vvd(epsa, 0.4091014316587367491, 1e-12, "Pfw06", "epsa", ref status);

            Assert.Equal(0, status);
        }
    }
}
