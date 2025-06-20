using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Eceq06 function.
        /// </summary>
        [Fact]
        public void TestEceq06()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            double dl = 5.1, db = -0.9, dr = 0, dd = 0;

            Eceq06(date1, date2, dl, db, ref dr, ref dd);

            Vvd(dr, 5.533459733613627767, 1e-14, "Eceq06", "dr", ref status);
            Vvd(dd, -1.246542932554480576, 1e-14, "Eceq06", "dd", ref status);

            Assert.Equal(0, status);
        }
    }
}
