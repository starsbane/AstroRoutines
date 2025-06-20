# AstroRoutines
An unoffical .NET Standard 2.0 clone of C Library of the Standards of Fundamental Astronomy (SOFA) software libraries from International Astronomical Union (IAU), provides a collection of subroutines that implement official IAU algorithms for astronomical computations.

This package is based on SOFA ANSI C Release 19 (2023-10-11) and distributed under Apache-2.0 license and SOFA. 
Please refer to https://www.iausofa.org/ for details regarding the SOFA releases.

## Packages
[![Static Badge](https://img.shields.io/nuget/v/AstroRoutines.svg)](https://www.nuget.org/packages/AstroRoutines/)


## Features
- Native managed C# implementation
- Cross-platform
- Method signatures are close to original C library, all you need is to remove iau prefix from method name and add ref or out keyword in Returned parameters (if any)

## Requirements
.NET Standard 2.0 (.NET Framework 4.6.1 - .NET Framework 4.8.1, .NET Core 2.0 - 9.0) for using the library (AstroRoutines)

.NET 8.0+ for running unit tests (AstroRoutines.UnitTests)

Please check (https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0) for details of .NET Standard 2.0.

## Criteria of package release
Each release version passed all tests in AstroRoutines.UnitTests (247 as of 2025-06-20).

## Brief of variation from original software (IAU SOFA C Library Release 19)
Explained as requested by SOFA Software License.

### AstroRoutines
- Rewritten from C to C# 10.0 (.NET 6.0)
    - Converts unmanaged features such as pointers to managed C# equivlaent
    - Applied some C# syntax candy
- Remaining things such as logic, constants, dataset (as gigantic arrays) are otherwise identical to the original software

### AstroRoutines.UnitTests
- Envolved from console test program to xUnit test project
    - Each t_XXX function is converted to a test method TestXXX
    - Instead of writing result to console, message is written to ITestOutputHelper
- Rewritten from C to C# 12.0 (.NET 8.0)
- Testing data and logic are otherwise identical to the original software

# What is SOFA?
SOFA operates under the auspices of the International Astronomical Union (IAU) to provide algorithms and software for use in astronomical computing. The initiative is managed by an international panel, the SOFA Board, appointed through IAU Division A. The Board obtains the latest IAU-approved models and theories from the fundamental-astronomy community, implements them as computer code and checks them for accuracy. SOFA works closely with all the Commissions of the Division and with the International Earth Rotation and Reference Systems Service (IERS).

The SOFA Collection consists of two libraries of routines, one coded in Fortran 77 the other in ANSI C. There is a suite of vector/matrix routines and various utilities that underpin the astronomy algorithms, which include routines for the following:

Astrometry
Calendars
Time Scales
Ecliptic Coordinates
Earth Rotation and Sidereal Time
Ephemerides (medium precision)
Fundamental Arguments
Galactic Coordinates
Geocentric/Geodetic Transformations
Precession, Nutation and Polar Motion
Star Catalog Conversion

Source: (https://www.iausofa.org/background.html)

# Copyright
Software Routines from the IAU SOFA Collection were used. Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).

Using SOFA software is free of charge under the terms and conditions of the SOFA licence, whose text is stated in:
- SOFA-LICENSE.md in this repository
- COnstant SOFA_LICENSE_TEXT in library AstroRoutines
- https://www.iausofa.org/tandc.html.

Please obey the SOFA 

# Alternatives to this package
Attila Abrudán's World Wide Astronomy (https://github.com/abrudana/wwa/)

# FAQ
