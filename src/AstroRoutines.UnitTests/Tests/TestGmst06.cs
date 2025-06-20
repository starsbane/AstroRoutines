using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Gmst06 function.
        /// </summary>
        [Fact]
        public void TestGmst06()
        {
            var status = 0;
            var theta = Gmst06(2400000.5, 53736.0, 2400000.5, 53736.0);

            Vvd(theta, 1.754174971870091203, 1e-12, "Gmst06", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
