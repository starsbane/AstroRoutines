namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test A2tf function.
        /// </summary>
        /// <remarks>
        /// Converts an angle to hours, minutes, seconds.
        /// </remarks>
        [Fact]
        public void TestA2tf()
        {
            var status = 0;
            var ihmsf = new int[4];
            var s = '\0';

            A2tf(4, -3.01234, out s, ref ihmsf);

            Viv((int)s, '-', "A2tf", "s", ref status);

            Viv(ihmsf[0], 11, "A2tf", "0", ref status);
            Viv(ihmsf[1], 30, "A2tf", "1", ref status);
            Viv(ihmsf[2], 22, "A2tf", "2", ref status);
            Viv(ihmsf[3], 6484, "A2tf", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
