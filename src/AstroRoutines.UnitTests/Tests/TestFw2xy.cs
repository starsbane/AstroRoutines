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
        /// Test Fw2xy function.
        /// </summary>
        [Fact]
        public void TestFw2xy()
        {
            var status = 0;
            var gamb = -0.2243387670997992368e-5;
            var phib = 0.4091014602391312982;
            var psi = -0.9501954178013015092e-3;
            var eps = 0.4091014316587367472;

            Fw2xy(gamb, phib, psi, eps, out var x, out var y);

            Vvd(x, -0.3779734957034082790e-3, 1e-14, "Fw2xy", "x", ref status);
            Vvd(y, -0.1924880848087615651e-6, 1e-14, "Fw2xy", "y", ref status);

            Assert.Equal(0, status);
        }
    }
}
