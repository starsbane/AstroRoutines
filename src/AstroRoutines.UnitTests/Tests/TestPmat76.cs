namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Pmat76 function.
        /// </summary>
        [Fact]
        public void TestPmat76()
        {
            var rmatp = new double[3, 3];
            var status = 0;

            Pmat76(2400000.5, 50123.9999, ref rmatp);

            Vvd(rmatp[0, 0], 0.9999995504328350733, 1e-12,"Pmat76", "11", ref status);
            Vvd(rmatp[0, 1], 0.8696632209480960785e-3, 1e-14, "Pmat76", "12", ref status);
            Vvd(rmatp[0, 2], 0.3779153474959888345e-3, 1e-14, "Pmat76", "13", ref status);

            Vvd(rmatp[1, 0], -0.8696632209485112192e-3, 1e-14, "Pmat76", "21", ref status);
            Vvd(rmatp[1, 1], 0.9999996218428560614, 1e-12, "Pmat76", "22", ref status);
            Vvd(rmatp[1, 2], -0.1643284776111886407e-6, 1e-14, "Pmat76", "23", ref status);

            Vvd(rmatp[2, 0], -0.3779153474950335077e-3, 1e-14, "Pmat76", "31", ref status);
            Vvd(rmatp[2, 1], -0.1643306746147366896e-6, 1e-14, "Pmat76", "32", ref status);
            Vvd(rmatp[2, 2], 0.9999999285899790119, 1e-12, "Pmat76", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
