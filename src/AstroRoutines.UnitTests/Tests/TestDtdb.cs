using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Dtdb function.
        /// </summary>
        [Fact]
        public void TestDtdb()
        {
            var status = 0;
            var dtdb = Dtdb(2448939.5, 0.123, 0.76543, 5.0123, 5525.242, 3190.0);

            Vvd(dtdb, -0.1280368005936998991e-2, 1e-15, "Dtdb", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
