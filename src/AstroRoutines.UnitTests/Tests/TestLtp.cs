namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ltp function.
        /// </summary>
        [Fact]
        public void TestLtp()
        {
            var epj = 1666.666;
            var rp = new double[3, 3];
            var status = 0;

            Ltp(epj, ref rp);

            Vvd(rp[0, 0], 0.9967044141159213819, 1e-14, "Ltp", "rp11", ref status);
            Vvd(rp[0, 1], 0.7437801893193210840e-1, 1e-14, "Ltp", "rp12", ref status);
            Vvd(rp[0, 2], 0.3237624409345603401e-1, 1e-14, "Ltp", "rp13", ref status);
            Vvd(rp[1, 0], -0.7437802731819618167e-1, 1e-14, "Ltp", "rp21", ref status);
            Vvd(rp[1, 1], 0.9972293894454533070, 1e-14, "Ltp", "rp22", ref status);
            Vvd(rp[1, 2], -0.1205768842723593346e-2, 1e-14, "Ltp", "rp23", ref status);
            Vvd(rp[2, 0], -0.3237622482766575399e-1, 1e-14, "Ltp", "rp31", ref status);
            Vvd(rp[2, 1], -0.1206286039697609008e-2, 1e-14, "Ltp", "rp32", ref status);
            Vvd(rp[2, 2], 0.9994750246704010914, 1e-14, "Ltp", "rp33", ref status);

            Assert.Equal(0, status);
        }
    }
}
