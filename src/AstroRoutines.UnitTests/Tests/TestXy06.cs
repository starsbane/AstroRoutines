namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Xy06 function.
        /// </summary>
        [Fact]
        public void TestXy06()
        {
            var status = 0;

            double x, y;

            Xy06(2400000.5, 53736.0, out x, out y);

            Vvd(x, 0.5791308486706010975e-3, 1e-15, "Xy06", "x", ref status);
            Vvd(y, 0.4020579816732958141e-4, 1e-16, "Xy06", "y", ref status);

            Assert.Equal(0, status);
        }
    }
}
