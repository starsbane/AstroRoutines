namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Tcbtdb function.
        /// </summary>
        [Fact]
        public void TestTcbtdb()
        {
            var status = 0;

            double b1, b2;
            int j;

            j = Tcbtdb(2453750.5, 0.893019599, out b1, out b2);

            Vvd(b1, 2453750.5, 1e-6, "Tcbtdb", "b1", ref status);
            Vvd(b2, 0.8928551362746343397, 1e-12, "Tcbtdb", "b2", ref status);
            Viv(j, 0, "Tcbtdb", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
