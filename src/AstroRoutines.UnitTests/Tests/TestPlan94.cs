namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Plan94 function.
        /// </summary>
        [Fact]
        public void TestPlan94()
        {
            var pv = new double[2, 3];
            var status = 0;

            var j = Plan94(2400000.5, 1e6, 0, ref pv);

            Vvd(pv[0, 0], 0.0, 0.0, "Plan94", "x 1", ref status);
            Vvd(pv[0, 1], 0.0, 0.0, "Plan94", "y 1", ref status);
            Vvd(pv[0, 2], 0.0, 0.0, "Plan94", "z 1", ref status);
            Vvd(pv[1, 0], 0.0, 0.0, "Plan94", "xd 1", ref status);
            Vvd(pv[1, 1], 0.0, 0.0, "Plan94", "yd 1", ref status);
            Vvd(pv[1, 2], 0.0, 0.0, "Plan94", "zd 1", ref status);
            Viv(j, -1, "Plan94", "j 1", ref status);

            j = Plan94(2400000.5, 1e6, 10, ref pv);
            Viv(j, -1, "Plan94", "j 2", ref status);

            j = Plan94(2400000.5, -320000, 3, ref pv);
            Vvd(pv[0, 0], 0.9308038666832975759, 1e-11, "Plan94", "x 3", ref status);
            Vvd(pv[0, 1], 0.3258319040261346000, 1e-11, "Plan94", "y 3", ref status);
            Vvd(pv[0, 2], 0.1422794544481140560, 1e-11, "Plan94", "z 3", ref status);
            Vvd(pv[1, 0], -0.6429458958255170006e-2, 1e-11, "Plan94", "xd 3", ref status);
            Vvd(pv[1, 1], 0.1468570657704237764e-1, 1e-11, "Plan94", "yd 3", ref status);
            Vvd(pv[1, 2], 0.6406996426270981189e-2, 1e-11, "Plan94", "zd 3", ref status);
            Viv(j, 1, "Plan94", "j 3", ref status);

            j = Plan94(2400000.5, 43999.9, 1, ref pv);
            Vvd(pv[0, 0], 0.2945293959257430832, 1e-11, "Plan94", "x 4", ref status);
            Vvd(pv[0, 1], -0.2452204176601049596, 1e-11, "Plan94", "y 4", ref status);
            Vvd(pv[0, 2], -0.1615427700571978153, 1e-11, "Plan94", "z 4", ref status);
            Vvd(pv[1, 0], 0.1413867871404614441e-1, 1e-11, "Plan94", "xd 4", ref status);
            Vvd(pv[1, 1], 0.1946548301104706582e-1, 1e-11, "Plan94", "yd 4", ref status);
            Vvd(pv[1, 2], 0.8929809783898904786e-2, 1e-11, "Plan94", "zd 4", ref status);
            Viv(j, 0, "Plan94", "j 4", ref status);

            Assert.Equal(0, status);
        }
    }
}
