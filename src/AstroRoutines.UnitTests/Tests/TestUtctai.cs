namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Utctai function.
        /// </summary>
        [Fact]
        public void TestUtctai()
        {
            var status = 0;

            double u1 = 0, u2 = 0;
            int j;

            j = Utctai(2453750.5, 0.892100694, out u1, out u2);

            Vvd(u1, 2453750.5, 1e-6, "Utctai", "u1", ref status);
            Vvd(u2, 0.8924826384444444444, 1e-12, "Utctai", "u2", ref status);
            Viv(j, 0, "Utctai", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
