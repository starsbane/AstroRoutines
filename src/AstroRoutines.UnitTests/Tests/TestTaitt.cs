namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Taitt function.
        /// </summary>
        [Fact]
        public void TestTaitt()
        {
            var status = 0;

            var j = Taitt(2453750.5, 0.892482639, out var t1, out var t2);

            Vvd(t1, 2453750.5, 1e-6, "Taitt", "t1", ref status);
            Vvd(t2, 0.892855139, 1e-12, "Taitt", "t2", ref status);
            Viv(j, 0, "Taitt", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
