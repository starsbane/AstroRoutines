namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tcbtdb function.
        /// </summary>
        [Fact]
        public void TestTcbtdb()
        {
            var status = 0;

            var j = Tcbtdb(2453750.5, 0.893019599, out var b1, out var b2);

            Vvd(b1, 2453750.5, 1e-6, "Tcbtdb", "b1", ref status);
            Vvd(b2, 0.8928551362746343397, 1e-12, "Tcbtdb", "b2", ref status);
            Viv(j, 0, "Tcbtdb", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
