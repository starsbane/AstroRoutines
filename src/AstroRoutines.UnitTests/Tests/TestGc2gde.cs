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
        /// Test Gc2gde function.
        /// </summary>
        [Fact]
        public void TestGc2gde()
        {
            var status = 0;
            double a = 6378136.0, f = 0.0033528;
            double[] xyz = { 2e6, 3e6, 5.244e6 };

            var j = Gc2gde(a, f, xyz, out var e, out var p, out var h);
            Viv(j, 0, "Gc2gde", "j", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gde", "e", ref status);
            Vvd(p, 0.9716018377570411532, 1e-14, "Gc2gde", "p", ref status);
            Vvd(h, 332.36862495764397, 1e-8, "Gc2gde", "h", ref status);

            Assert.Equal(0, status);
        }
    }
}
