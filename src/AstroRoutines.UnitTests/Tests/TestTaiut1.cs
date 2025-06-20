namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Taiut1 function.
        /// </summary>
        [Fact]
        public void TestTaiut1()
        {
            var status = 0;

            var j = Taiut1(2453750.5, 0.892482639, -32.6659, out var u1, out var u2);

            Vvd(u1, 2453750.5, 1e-6, "Taiut1", "u1", ref status);
            Vvd(u2, 0.8921045614537037037, 1e-12, "Taiut1", "u2", ref status);
            Viv(j, 0, "Taiut1", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
