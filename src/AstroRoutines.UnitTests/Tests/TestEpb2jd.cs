using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Epb2jd function.
        /// </summary>
        [Fact]
        public void TestEpb2jd()
        {
            var status = 0;
            double epb = 1957.3, djm0, djm;

            Epb2jd(epb, out djm0, out djm);

            Vvd(djm0, 2400000.5, 1e-9, "Epb2jd", "djm0", ref status);
            Vvd(djm, 35948.1915101513, 1e-9, "Epb2jd", "mjd", ref status);

            Assert.Equal(0, status);
        }
    }
}
