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
        /// Test Fw2m function.
        /// </summary>
        [Fact]
        public void TestFw2m()
        {
            var status = 0;
            var gamb = -0.2243387670997992368e-5;
            var phib = 0.4091014602391312982;
            var psi = -0.9501954178013015092e-3;
            var eps = 0.4091014316587367472;
            var r = new double[3, 3];

            Fw2m(gamb, phib, psi, eps, ref r);

            Vvd(r[0, 0], 0.9999995505176007047, 1e-12, "Fw2m", "11", ref status);
            Vvd(r[0, 1], 0.8695404617348192957e-3, 1e-12, "Fw2m", "12", ref status);
            Vvd(r[0, 2], 0.3779735201865582571e-3, 1e-12, "Fw2m", "13", ref status);

            Vvd(r[1, 0], -0.8695404723772016038e-3, 1e-12, "Fw2m", "21", ref status);
            Vvd(r[1, 1], 0.9999996219496027161, 1e-12, "Fw2m", "22", ref status);
            Vvd(r[1, 2], -0.1361752496887100026e-6, 1e-12, "Fw2m", "23", ref status);

            Vvd(r[2, 0], -0.3779734957034082790e-3, 1e-12, "Fw2m", "31", ref status);
            Vvd(r[2, 1], -0.1924880848087615651e-6, 1e-12, "Fw2m", "32", ref status);
            Vvd(r[2, 2], 0.9999999285679971958, 1e-12, "Fw2m", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
