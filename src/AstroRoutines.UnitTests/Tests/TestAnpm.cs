namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Anpm function.
        /// </summary>
        /// <remarks>
        /// Normalize angle into the range -pi to +pi.
        /// </remarks>
        [Fact]
        public void TestAnpm()
        {
            var status = 0;

            Vvd(Anpm(-4.0), 2.283185307179586477, 1e-12, "Anpm", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
