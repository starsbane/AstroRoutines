using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Eect00 function.
        /// </summary>
        [Fact]
        public void TestEect00()
        {
            var status = 0;
            var eect = Eect00(2400000.5, 53736.0);

            Vvd(eect, 0.2046085004885125264e-8, 1e-20, "Eect00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
