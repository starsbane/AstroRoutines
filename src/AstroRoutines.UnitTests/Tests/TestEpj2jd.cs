using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Epj2jd function.
        /// </summary>
        [Fact]
        public void TestEpj2jd()
        {
            var status = 0;
            double epj = 1996.8, djm0 = 0, djm = 0;

            Epj2jd(epj, ref djm0, ref djm);

            Vvd(djm0, 2400000.5, 1e-9, "Epj2jd", "djm0", ref status);
            Vvd(djm, 50375.7, 1e-9, "Epj2jd", "mjd", ref status);

            Assert.Equal(0, status);
        }
    }
}
