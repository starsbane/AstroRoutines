using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Aper13 function.
        /// </summary>
        /// <remarks>
        /// Apply polar motion to CIRS to observed transformation using internal routine.
        /// </remarks>
        [Fact]
        public void TestAper13()
        {
            var status = 0;
            var ut11 = 2456165.5;
            var ut12 = 0.401182685;
            var astrom = new ASTROM();

            astrom.along = 1.234;

            Aper13(ut11, ut12, ref astrom);

            Vvd(astrom.eral, 3.316236661789694933, 1e-12, "Aper13", "eral", ref status);

            Assert.Equal(0, status);
        }
    }
}
