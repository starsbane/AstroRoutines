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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Fk524 function.
        /// </summary>
        [Fact]
        public void TestFk524()
        {
            var status = 0;

            var r2000 = 0.8723503576487275595;
            var d2000 = -0.7517076365138887672;
            var dr2000 = 0.2019447755430472323e-4;
            var dd2000 = 0.3541563940505160433e-5;
            var p2000 = 0.1559;
            var v2000 = 86.87;

            Fk524(r2000, d2000, dr2000, dd2000, p2000, v2000,
                   out var r1950, out var d1950, out var dr1950, out var dd1950, out var p1950, out var v1950);

            Vvd(r1950, 0.8636359659799603487, 1e-13, "Fk524", "r1950", ref status);
            Vvd(d1950, -0.7550281733160843059, 1e-13, "Fk524", "d1950", ref status);
            Vvd(dr1950, 0.2023628192747172486e-4, 1e-17, "Fk524", "dr1950", ref status);
            Vvd(dd1950, 0.3624459754935334718e-5, 1e-18, "Fk524", "dd1950", ref status);
            Vvd(p1950, 0.1560079963299390241, 1e-13, "Fk524", "p1950", ref status);
            Vvd(v1950, 86.79606353469163751, 1e-11, "Fk524", "v1950", ref status);

            Assert.Equal(0, status);
        }
    }
}
