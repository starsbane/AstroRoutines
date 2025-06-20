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
        /// Test Tttcg function.
        /// </summary>
        [Fact]
        public void TestTttcg()
        {
            var status = 0;

            double g1 = 0, g2 = 0;

            var j = Tttcg(2453750.5, 0.892482639, ref g1, ref g2);

            Vvd(g1, 2453750.5, 1e-6, "Tttcg", "g1", ref status);
            Vvd(g2, 0.8924900312508587113, 1e-12, "Tttcg", "g2", ref status);

            Viv(j, 0, "Tttcg", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
