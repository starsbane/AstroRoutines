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
        /// Test Jdcalf function.
        /// </summary>
        [Fact]
        public void TestJdcalf()
        {
            var status = 0;
            var iydmf = new int[4];
            double dj1 = 2400000.5, dj2 = 50123.9999;

            var j = Jdcalf(4, dj1, dj2, ref iydmf);

            Viv(iydmf[0], 1996, "Jdcalf", "y", ref status);
            Viv(iydmf[1], 2, "Jdcalf", "m", ref status);
            Viv(iydmf[2], 10, "Jdcalf", "d", ref status);
            Viv(iydmf[3], 9999, "Jdcalf", "f", ref status);
            Viv(j, 0, "Jdcalf", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
