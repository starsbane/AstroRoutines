namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pr00 function.
        /// </summary>
        [Fact]
        public void TestPr00()
        {
            var dpsipr = 0.0;
            var depspr = 0.0;
            var status = 0;

            Pr00(2400000.5, 53736, out dpsipr, out depspr);

            Vvd(dpsipr, -0.8716465172668347629e-7, 1e-22, "Pr00", "dpsipr", ref status);
            Vvd(depspr, -0.7342018386722813087e-8, 1e-22, "Pr00", "depspr", ref status);

            Assert.Equal(0, status);
        }
    }
}
