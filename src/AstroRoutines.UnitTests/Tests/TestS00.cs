namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test S00 function.
        /// </summary>
        [Fact]
        public void TestS00()
        {
            var status = 0;

            var x = 0.5791308486706011000e-3;
            var y = 0.4020579816732961219e-4;

            var s = S00(2400000.5, 53736.0, x, y);

            Vvd(s, -0.1220036263270905693e-7, 1e-18, "S00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
