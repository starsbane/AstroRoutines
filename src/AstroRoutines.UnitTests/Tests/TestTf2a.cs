namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Tf2a function.
        /// </summary>
        [Fact]
        public void TestTf2a()
        {
            var status = 0;

            double a;
            int j;

            j = Tf2a('+', 4, 58, 20.2, out a);

            Vvd(a, 1.301739278189537429, 1e-12, "Tf2a", "a", ref status);
            Viv(j, 0, "Tf2a", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
