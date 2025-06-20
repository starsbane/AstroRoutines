//
// Copyright 2025 Alex Man (Starsbane)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Software Routines from the IAU SOFA Collection were used. 
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Apio function.
        /// </summary>
        /// <remarks>
        /// Prepare for CIRS to observed transformation.
        /// </remarks>
        [Fact]
        public void TestApio()
        {
            var status = 0;
            var sp = -3.01974337e-11;
            var theta = 3.14540971;
            var elong = -0.527800806;
            var phi = -1.2345856;
            var hm = 2738.0;
            var xp = 2.47230737e-7;
            var yp = 1.82640464e-6;
            var refa = 0.000201418779;
            var refb = -2.36140831e-7;
            var astrom = new ASTROM();

            Apio(sp, theta, elong, phi, hm, xp, yp, refa, refb, ref astrom);

            Vvd(astrom.along, -0.5278008060295995734, 1e-12, "Apio", "along", ref status);
            Vvd(astrom.xpl, 0.1133427418130752958e-5, 1e-17, "Apio", "xpl", ref status);
            Vvd(astrom.ypl, 0.1453347595780646207e-5, 1e-17, "Apio", "ypl", ref status);
            Vvd(astrom.sphi, -0.9440115679003211329, 1e-12, "Apio", "sphi", ref status);
            Vvd(astrom.cphi, 0.3299123514971474711, 1e-12, "Apio", "cphi", ref status);
            Vvd(astrom.diurab, 0.5135843661699913529e-6, 1e-12, "Apio", "diurab", ref status);
            Vvd(astrom.eral, 2.617608903970400427, 1e-12, "Apio", "eral", ref status);
            Vvd(astrom.refa, 0.2014187790000000000e-3, 1e-15, "Apio", "refa", ref status);
            Vvd(astrom.refb, -0.2361408310000000000e-6, 1e-18, "Apio", "refb", ref status);

            Assert.Equal(0, status);
        }
    }
}
