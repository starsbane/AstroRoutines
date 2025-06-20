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
        /// Test Pmat06 function.
        /// </summary>
        [Fact]
        public void TestPmat06()
        {
            var rbp = new double[3, 3];
            var status = 0;

            Pmat06(2400000.5, 50123.9999, ref rbp);

            Vvd(rbp[0, 0], 0.9999995505176007047, 1e-12, "Pmat06", "11", ref status);
            Vvd(rbp[0, 1], 0.8695404617348208406e-3, 1e-14, "Pmat06", "12", ref status);
            Vvd(rbp[0, 2], 0.3779735201865589104e-3, 1e-14, "Pmat06", "13", ref status);

            Vvd(rbp[1, 0], -0.8695404723772031414e-3, 1e-14, "Pmat06", "21", ref status);
            Vvd(rbp[1, 1], 0.9999996219496027161, 1e-12, "Pmat06", "22", ref status);
            Vvd(rbp[1, 2], -0.1361752497080270143e-6, 1e-14, "Pmat06", "23", ref status);

            Vvd(rbp[2, 0], -0.3779734957034089490e-3, 1e-14, "Pmat06", "31", ref status);
            Vvd(rbp[2, 1], -0.1924880847894457113e-6, 1e-14, "Pmat06", "32", ref status);
            Vvd(rbp[2, 2], 0.9999999285679971958, 1e-12, "Pmat06", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
