namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test S00b function.
        /// </summary>
        [Fact]
        public void TestS00b()
        {
            var status = 0;

            var s = S00b(2400000.5, 52541.0);

            Vvd(s, -0.1340695782951026584e-7, 1e-18, "S00b", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
