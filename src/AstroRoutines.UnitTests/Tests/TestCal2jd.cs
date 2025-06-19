using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Cal2jd function.
        /// </summary>
        [Fact]
        public void TestCal2jd()
        {
            var status = 0;
            var j = Cal2jd(2003, 6, 1, out var djm0, out var djm);

            Vvd(djm0, 2400000.5, 0.0, "Cal2jd", "djm0", ref status);
            Vvd(djm, 52791.0, 0.0, "Cal2jd", "djm", ref status);
            Viv(j, 0, "Cal2jd", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
