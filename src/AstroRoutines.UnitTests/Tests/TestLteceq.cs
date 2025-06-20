namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Lteceq function.
        /// </summary>
        [Fact]
        public void TestLteceq()
        {
			var status = 0;
            var epj = 2500.0;
            var dl = 1.5;
            var db = 0.6;
            var dr = 0.0;
            var dd = 0.0;

            Lteceq(epj, dl, db, ref dr, ref dd);

            Vvd(dr, 1.275156021861921167, 1e-14, "Lteceq", "dr", ref status);
            Vvd(dd, 0.9966573543519204791, 1e-14, "Lteceq", "dd", ref status);

            Assert.Equal(0, status);
        }
    }
}
