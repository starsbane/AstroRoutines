using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Obl80 function.
        /// </summary>
        [Fact]
        public void TestObl80()
        {
            var status = 0;

            Vvd(Obl80(2400000.5, 54388.0), 0.4090751347643816218, 1e-14, "Obl80", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
