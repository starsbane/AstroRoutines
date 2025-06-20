using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Era00 function.
        /// </summary>
        [Fact]
        public void TestEra00()
        {
            var status = 0;
            var era00 = Era00(2400000.5, 54388.0);

            Vvd(era00, 0.4022837240028158102, 1e-12, "Era00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
