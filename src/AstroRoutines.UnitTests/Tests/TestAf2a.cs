using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Af2a function.
        /// </summary>
        /// <remarks>
        /// Converts degrees, arcminutes, arcseconds to radians.
        /// </remarks>
        [Fact]
        public void TestAf2a()
        {
            int status = 0;
            double a;
            int j;

            j = Af2a('-', 45, 13, 27.2, out a);

            Vvd(a, -0.7893115794313644842, 1e-12, "Af2a", "a", ref status);
            Viv(j, 0, "Af2a", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
