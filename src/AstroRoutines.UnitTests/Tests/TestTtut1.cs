namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Ttut1 function.
        /// </summary>
        [Fact]
        public void TestTtut1()
        {
            var status = 0;

            double u1 = 0, u2 = 0;
            int j;

            j = Ttut1(2453750.5, 0.892855139, 64.8499, ref u1, ref u2);

            Vvd(u1, 2453750.5, 1e-6, "Ttut1", "u1", ref status);
            Vvd(u2, 0.8921045614537037037, 1e-12, "Ttut1", "u2", ref status);

            Viv(j, 0, "Ttut1", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
