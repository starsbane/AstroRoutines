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
        /// Test Cal2jd function.
        /// </summary>
        [Fact]
        public void TestCal2jd()
        {
            var status = 0;
            var j = Cal2jd(2003, 6, 1, out var djm0, out var djm);

            Vvd(djm0, 2400000.5, 0.0, "Cal2jd", "djm0", ref status);
            Vvd(djm, 52791.0, 0.0, "Cal2jd", "djm", ref status);
            Viv(j, 0, "Cal2jd", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
