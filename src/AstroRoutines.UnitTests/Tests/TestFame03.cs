namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fame03 function.
        /// </summary>
        [Fact]
        public void TestFame03()
        {
            var status = 0;

            Vvd(Fame03(0.80), 5.417338184297289661, 1e-12, "Fame03", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
