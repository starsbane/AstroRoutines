namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Lteqec function.
        /// </summary>
        [Fact]
        public void TestLteqec()
        {
            var status = 0;
            var epj = -1500.0;
            var dr = 1.234;
            var dd = 0.987;

            Lteqec(epj, dr, dd, out var dl, out var db);

            Vvd(dl, 0.5039483649047114859, 1e-14, "Lteqec", "dl", ref status);
            Vvd(db, 0.5848534459726224882, 1e-14, "Lteqec", "db", ref status);

            Assert.Equal(0, status);
        }
    }
}
