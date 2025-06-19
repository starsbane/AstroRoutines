using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Fane03 function.
        /// </summary>
        [Fact]
        public void TestFane03()
        {
            var status = 0;

            Vvd(Fane03(0.80), 2.079343830860413523, 1e-12, "Fane03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
