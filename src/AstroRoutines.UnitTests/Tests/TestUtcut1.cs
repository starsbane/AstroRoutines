namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Utcut1 function.
        /// </summary>
        [Fact]
        public void TestUtcut1()
        {
            var status = 0;

            double u1 = 0, u2 = 0;

            var j = Utcut1(2453750.5, 0.892100694, 0.3341, ref u1, ref u2);

            Vvd(u1, 2453750.5, 1e-6, "Utcut1", "u1", ref status);
            Vvd(u2, 0.8921045608981481481, 1e-12, "Utcut1", "u2", ref status);
            Viv(j, 0, "Utcut1", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
