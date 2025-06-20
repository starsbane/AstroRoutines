using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Dat function.
        /// </summary>
        [Fact]
        public void TestDat()
        {
            var status = 0;
            var j = Dat(2003, 6, 1, 0.0, out var deltat);

            Vvd(deltat, 32.0, 0.0, "Dat", "d1", ref status);
            Viv(j, 0, "Dat", "j1", ref status);

            j = Dat(2008, 1, 17, 0.0, out deltat);

            Vvd(deltat, 33.0, 0.0, "Dat", "d2", ref status);
            Viv(j, 0, "Dat", "j2", ref status);

            j = Dat(2017, 9, 1, 0.0, out deltat);

            Vvd(deltat, 37.0, 0.0, "Dat", "d3", ref status);
            Viv(j, 0, "Dat", "j3", ref status);

            Assert.Equal(0, status);
        }
    }
}
