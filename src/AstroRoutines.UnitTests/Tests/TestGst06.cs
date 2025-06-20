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
        /// Test Gst06 function.
        /// </summary>
        [Fact]
        public void TestGst06()
        { 
            var status = 0;
            var rnpb = new double[3,3];
            rnpb[0, 0] =  0.9999989440476103608;
            rnpb[0, 1] = -0.1332881761240011518e-2;
            rnpb[0, 2] = -0.5790767434730085097e-3;

            rnpb[1, 0] =  0.1332858254308954453e-2;
            rnpb[1, 1] =  0.9999991109044505944;
            rnpb[1, 2] = -0.4097782710401555759e-4;

            rnpb[2, 0] =  0.5791308472168153320e-3;
            rnpb[2, 1] =  0.4020595661593994396e-4;
            rnpb[2, 2] =  0.9999998314954572365;

		   var theta = Gst06(2400000.5, 53736.0, 2400000.5, 53736.0, rnpb);

		   Vvd(theta, 1.754166138018167568, 1e-12, "Gst06", "", ref status);

           Assert.Equal(0, status);
        }
    }
}
