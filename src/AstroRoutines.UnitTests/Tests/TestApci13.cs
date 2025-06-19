namespace AstroRoutines.UnitTests
{
    public partial class SofaTests
    {
        /// <summary>
        /// Test Apci13 function.
        /// </summary>
        [Fact]
        public void TestApci13()
        {
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            double eo;
            var astrom = new ASTROM();
            var status = 0;

            Apci13(date1, date2, ref astrom, out eo);

            Vvd(astrom.pmt, 12.65133794027378508, 1e-11, "Apci13", "pmt", ref status);
            
            Vvd(astrom.eb[0], 0.9013108747340644755, 1e-12, "Apci13", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.4174026640406119957, 1e-12, "Apci13", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.1809822877867817771, 1e-12, "Apci13", "eb(3)", ref status);
            
            Vvd(astrom.eh[0], 0.8940025429255499549, 1e-12, "Apci13", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.4110930268331896318, 1e-12, "Apci13", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.1782189006019749850, 1e-12, "Apci13", "eh(3)", ref status);
           
            Vvd(astrom.em, 1.010465295964664178, 1e-12, "Apci13", "em", ref status);
            
            Vvd(astrom.v[0], 0.4289638912941341125e-4, 1e-16, "Apci13", "v(1)", ref status);
            Vvd(astrom.v[1], 0.8115034032405042132e-4, 1e-16, "Apci13", "v(2)", ref status);
            Vvd(astrom.v[2], 0.3517555135536470279e-4, 1e-16, "Apci13", "v(3)", ref status);
            
            Vvd(astrom.bm1, 0.9999999951686013142, 1e-12, "Apci13", "bm1", ref status);
            
            Vvd(astrom.bpn[0, 0], 0.9999992060376761710, 1e-12, "Apci13", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[1, 0], 0.4124244860106037157e-7, 1e-12, "Apci13", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[2, 0], 0.1260128571051709670e-2, 1e-12, "Apci13", "bpn(3,1)", ref status);
            
            Vvd(astrom.bpn[0, 1], -0.1282291987222130690e-7, 1e-12, "Apci13", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[1, 1], 0.9999999997456835325, 1e-12, "Apci13", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[2, 1], -0.2255288829420524935e-4, 1e-12, "Apci13", "bpn(3,2)", ref status);
            
            Vvd(astrom.bpn[0, 2], -0.1260128571661374559e-2, 1e-12, "Apci13", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 2], 0.2255285422953395494e-4, 1e-12, "Apci13", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 2], 0.9999992057833604343, 1e-12, "Apci13", "bpn(3,3)", ref status);
            
            Vvd(eo, -0.2900618712657375647e-2, 1e-12, "Apci13", "eo", ref status);

            Assert.Equal(0, status);
        }
    }
}
