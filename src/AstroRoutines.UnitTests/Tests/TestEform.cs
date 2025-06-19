using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Eform function.
        /// </summary>
        [Fact]
        public void TestEform()
        {
            var status = 0;
            double a, f;

            var j = Eform(0, out a, out f);
            Viv(j, -1, "Eform", "j0", ref status);

            j = Eform(WGS84, out a, out f);
            Viv(j, 0, "Eform", "j1", ref status);
            Vvd(a, 6378137.0, 1e-10, "Eform", "a1", ref status);
            Vvd(f, 0.3352810664747480720e-2, 1e-18, "Eform", "f1", ref status);

            j = Eform(GRS80, out a, out f);
            Viv(j, 0, "Eform", "j2", ref status);
            Vvd(a, 6378137.0, 1e-10, "Eform", "a2", ref status);
            Vvd(f, 0.3352810681182318935e-2, 1e-18, "Eform", "f2", ref status);

            j = Eform(WGS72, out a, out f);
            Viv(j, 0, "Eform", "j3", ref status);
            Vvd(a, 6378135.0, 1e-10, "Eform", "a3", ref status);
            Vvd(f, 0.3352779454167504862e-2, 1e-18, "Eform", "f3", ref status);

            j = Eform(4, out a, out f);
            Viv(j, -1, "Eform", "j4", ref status);
        }
    }
}
