using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Obl06 function.
        /// </summary>
        [Fact]
        public void TestObl06()
        {
            var status = 0;

            Vvd(Obl06(2400000.5, 54388.0), 0.4090749229387258204, 1e-14, "Obl06", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
