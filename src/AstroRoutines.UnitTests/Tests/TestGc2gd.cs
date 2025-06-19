using Xunit;

namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Gc2gd function.
        /// </summary>
        [Fact]
        public void TestGc2gd()
        {
            var status = 0;
            double[] xyz = { 2e6, 3e6, 5.244e6 };
            double e, p, h;
            int j;

            j = Gc2gd(0, xyz, out e, out p, out h);
            Viv(j, -1, "Gc2gd", "j0", ref status);

            j = Gc2gd(WGS84, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gd", "j1", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gd", "e1", ref status);
            Vvd(p, 0.97160184819075459, 1e-14, "Gc2gd", "p1", ref status);
            Vvd(h, 331.4172461426059892, 1e-8, "Gc2gd", "h1", ref status);

            j = Gc2gd(GRS80, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gd", "j2", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gd", "e2", ref status);
            Vvd(p, 0.97160184820607853, 1e-14, "Gc2gd", "p2", ref status);
            Vvd(h, 331.41731754844348, 1e-8, "Gc2gd", "h2", ref status);

            j = Gc2gd(WGS72, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gd", "j3", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gd", "e3", ref status);
            Vvd(p, 0.9716018181101511937, 1e-14, "Gc2gd", "p3", ref status);
            Vvd(h, 333.2770726130318123, 1e-8, "Gc2gd", "h3", ref status);

            j = Gc2gd(4, xyz, out e, out p, out h);
            Viv(j, -1, "Gc2gd", "j4", ref status);

            Assert.Equal(0, status);
        }
    }
}
