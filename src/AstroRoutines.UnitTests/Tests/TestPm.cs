namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pm function.
        /// </summary>
        [Fact]
        public void TestPm()
        {
            var p = new double[3];
            var r = 0.0;
            var status = 0;

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            r = Pm(p);

            Vvd(r, 2.789265136196270604, 1e-12, "Pm", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
