using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Anp function.
        /// </summary>
        /// <remarks>
        /// Normalize angle into the range 0 to 2pi.
        /// </remarks>
        [Fact]
        public void TestAnp()
        {
            int status = 0;

            Vvd(Anp(-0.1), 6.183185307179586477, 1e-12, "Anp", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
