using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test G2icrs function.
        /// </summary>
        [Fact]
        public void TestG2icrs()
        {
            var status = 0;
            var dl = 5.5850536063818546461558105;
            var db = -0.7853981633974483096156608;
            double dr, dd;

            G2icrs(dl, db, out dr, out dd);

            Vvd(dr, 5.9338074302227188048671, 1e-14, "G2icrs", "R", ref status);
            Vvd(dd, -1.1784870613579944551541, 1e-14, "G2icrs", "D", ref status);

            Assert.Equal(0, status);
        }
    }
}
