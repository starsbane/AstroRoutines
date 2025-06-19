using System;
using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test A2af function.
        /// </summary>
        /// <remarks>
        /// Converts an angle to degrees, arcminutes, arcseconds.
        /// </remarks>
        [Fact]
        public void TestA2af()
        {
            int status = 0;
            int[] idmsf = new int[4];
            char s = '\0';

            A2af(4, 2.345, out s, ref idmsf);

            Viv((int)s, '+', "A2af", "s", ref status);

            Viv(idmsf[0], 134, "A2af", "0", ref status);
            Viv(idmsf[1], 21, "A2af", "1", ref status);
            Viv(idmsf[2], 30, "A2af", "2", ref status);
            Viv(idmsf[3], 9706, "A2af", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
