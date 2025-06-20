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
        /// Test C2tpe function.
        /// </summary>
        [Fact]
        public void TestC2tpe()
        {
            var status = 0;
            var tta = 2400000.5;
            var uta = 2400000.5;
            var ttb = 53736.0;
            var utb = 53736.0;
            var deps = 0.4090789763356509900;
            var dpsi = -0.9630909107115582393e-5;
            var xp = 2.55060238e-7;
            var yp = 1.860359247e-6;

            C2tpe(tta, ttb, uta, utb, dpsi, deps, xp, yp, out var rc2t);

            Vvd(rc2t[0, 0], -0.1813677995763029394, 1e-12, "C2tpe", "11", ref status);
            Vvd(rc2t[0, 1], 0.9023482206891683275, 1e-12, "C2tpe", "12", ref status);
            Vvd(rc2t[0, 2], -0.3909902938641085751, 1e-12, "C2tpe", "13", ref status);

            Vvd(rc2t[1, 0], -0.9834147641476804807, 1e-12, "C2tpe", "21", ref status);
            Vvd(rc2t[1, 1], -0.1659883635434995121, 1e-12, "C2tpe", "22", ref status);
            Vvd(rc2t[1, 2], 0.7309763898042819705e-1, 1e-12, "C2tpe", "23", ref status);

            Vvd(rc2t[2, 0], 0.1059685430673215247e-2, 1e-12, "C2tpe", "31", ref status);
            Vvd(rc2t[2, 1], 0.3977631855605078674, 1e-12, "C2tpe", "32", ref status);
            Vvd(rc2t[2, 2], 0.9174875068792735362, 1e-12, "C2tpe", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
