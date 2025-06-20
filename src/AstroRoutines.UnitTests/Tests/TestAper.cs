using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Aper function.
        /// </summary>
        /// <remarks>
        /// Apply polar motion to CIRS to observed transformation.
        /// </remarks>
        [Fact]
        public void TestAper()
        {
            var status = 0;
            var theta = 5.678;
            var astrom = new ASTROM();

            astrom.along = 1.234;

            Aper(theta, ref astrom);

            Vvd(astrom.eral, 6.912000000000000000, 1e-12, "Aper", "eral", ref status);

            Assert.Equal(0, status);
        }
    }
}
