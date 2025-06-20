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
        /// Test Xys06a function.
        /// </summary>
        [Fact]
        public void TestXys06a()
        {
            var status = 0;

            double x = 0, y = 0, s = 0;

            Xys06a(2400000.5, 53736.0, ref x, ref y, ref s);

            Vvd(x, 0.5791308482835292617e-3, 1e-14, "Xys06a", "x", ref status);
            Vvd(y, 0.4020580099454020310e-4, 1e-15, "Xys06a", "y", ref status);
            Vvd(s, -0.1220032294164579896e-7, 1e-18, "Xys06a", "s", ref status);

            Assert.Equal(0, status);
        }
    }
}
