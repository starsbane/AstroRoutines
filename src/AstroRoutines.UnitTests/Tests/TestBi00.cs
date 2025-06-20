using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Bi00 function.
        /// </summary>
        /// <remarks>
        /// Frame bias components of IAU 2000 precession-nutation models.
        /// </remarks>
        [Fact]
        public void TestBi00()
        {
            var status = 0;
            double dpsibi, depsbi, dra;

            Bi00(out dpsibi, out depsbi, out dra);

            Vvd(dpsibi, -0.2025309152835086613e-6, 1e-12, "Bi00", "dpsibi", ref status);
            Vvd(depsbi, -0.3306041454222147847e-7, 1e-12, "Bi00", "depsbi", ref status);
            Vvd(dra, -0.7078279744199225506e-7, 1e-12, "Bi00", "dra", ref status);

            Assert.Equal(0, status);
        }
    }
}
