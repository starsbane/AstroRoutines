namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test S06 function.
        /// </summary>
        [Fact]
        public void TestS06()
        {
            var status = 0;

            var x = 0.5791308486706011000e-3;
            var y = 0.4020579816732961219e-4;

            var s = S06(2400000.5, 53736.0, x, y);

            Vvd(s, -0.1220032213076463117e-7, 1e-18, "S06", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
