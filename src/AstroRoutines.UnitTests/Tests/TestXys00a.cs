namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Xys00a function.
        /// </summary>
        [Fact]
        public void TestXys00a()
        {
            var status = 0;

            double x = 0, y = 0, s = 0;

            Xys00a(2400000.5, 53736.0, ref x, ref y, ref s);

            Vvd(x, 0.5791308472168152904e-3, 1e-14, "Xys00a", "x", ref status);
            Vvd(y, 0.4020595661591500259e-4, 1e-15, "Xys00a", "y", ref status);
            Vvd(s, -0.1220040848471549623e-7, 1e-18, "Xys00a", "s", ref status);

            Assert.Equal(0, status);
        }
    }
}
