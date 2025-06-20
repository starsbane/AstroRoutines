namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test S06a function.
        /// </summary>
        [Fact]
        public void TestS06a()
        {
            var status = 0;

            var s = S06a(2400000.5, 52541.0);

            Vvd(s, -0.1340680437291812383e-7, 1e-18, "S06a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
