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
        /// Test Pap function.
        /// </summary>
        [Fact]
        public void TestPap()
        {
            var status = 0;
            var a = new double[3];
            var b = new double[3];

            a[0] =  1.0;
			a[1] =  0.1;
			a[2] =  0.2;

			b[0] = -3.0;
			b[1] = 1e-3;
			b[2] =  0.2;
			
            var theta = Pap(a, b);

            Vvd(theta, 0.3671514267841113674, 1e-12, "Pap", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
