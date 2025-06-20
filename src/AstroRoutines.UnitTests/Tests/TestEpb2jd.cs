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
        /// Test Epb2jd function.
        /// </summary>
        [Fact]
        public void TestEpb2jd()
        {
            var status = 0;
            var epb = 1957.3;

            Epb2jd(epb, out var djm0, out var djm);

            Vvd(djm0, 2400000.5, 1e-9, "Epb2jd", "djm0", ref status);
            Vvd(djm, 35948.1915101513, 1e-9, "Epb2jd", "mjd", ref status);

            Assert.Equal(0, status);
        }
    }
}
