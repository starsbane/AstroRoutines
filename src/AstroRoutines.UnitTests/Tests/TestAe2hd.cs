namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ae2hd function.
        /// </summary>
        /// <remarks>
        /// Converts azimuth and elevation to hour angle and declination.
        /// </remarks>
        [Fact]
        public void TestAe2hd()
        {
            var status = 0;

            var a = 5.5;
            var e = 1.1;
            var p = 0.7;

            Ae2hd(a, e, p, out var h, out var d);

            Vvd(h, 0.5933291115507309663, 1e-14, "Ae2hd", "h", ref status);
            Vvd(d, 0.9613934761647817620, 1e-14, "Ae2hd", "d", ref status);

            Assert.Equal(0, status);
        }
    }
}
