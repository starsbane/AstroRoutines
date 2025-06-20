namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Icrs2g function.
        /// </summary>
        [Fact]
        public void TestIcrs2g()
        {
            var status = 0;
            var dr = 5.9338074302227188048671;
            var dd = -1.1784870613579944551541;

            Icrs2g(dr, dd, out var dl, out var db);

            Vvd(dl, 5.5850536063818546461558, 1e-14, "Icrs2g", "L", ref status);
            Vvd(db, -0.7853981633974483096157, 1e-14, "Icrs2g", "B", ref status);

            Assert.Equal(0, status);
        }
    }
}
