using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Fad03 function.
        /// </summary>
        [Fact]
        public void TestFad03()
        {
            var status = 0;

            Vvd(Fad03(0.80), 1.946709205396925672, 1e-12, "Fad03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
