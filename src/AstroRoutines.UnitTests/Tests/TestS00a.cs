namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test S00a function.
        /// </summary>
        [Fact]
        public void TestS00a()
        {
            var status = 0;

            var s = S00a(2400000.5, 52541.0);

            Vvd(s, -0.1340684448919163584e-7, 1e-18, "S00a", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
