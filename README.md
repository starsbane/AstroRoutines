![GitHub License](https://img.shields.io/github/license/starsbane/AstroRoutines?style=flat) ![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/starsbane/AstroRoutines/total?style=flat) ![GitHub Repo stars](https://img.shields.io/github/stars/starsbane/AstroRoutines?style=flat)


# AstroRoutines
An unofficial .NET Standard 2.0 port of the International Astronomical Union's C SOFA software library, provides a collection of subroutines, helper methods and constants that implement official IAU algorithms for astronomical computations.

This package is based on SOFA ANSI C Release 19 (2023-10-11) and distributed under Apache-2.0 license and the SOFA License. 
Please refer to https://www.iausofa.org/ for details regarding the SOFA releases.

## Packages
[![Static Badge](https://img.shields.io/nuget/v/AstroRoutines.svg)](https://www.nuget.org/packages/AstroRoutines/) [![NuGet Downloads](https://img.shields.io/nuget/dt/AstroRoutines)](https://www.nuget.org/packages/AstroRoutines/) 

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
- Rewritten from C to C# 7.3 (.NET Standard 2.0)
    - Converts unmanaged features such as pointers to managed C# equivlaent
    - Applied some C# syntax candy
- Remaining things such as logic, constants, dataset (as gigantic arrays) are otherwise identical to the original software

### AstroRoutines.UnitTests
- Envolved from console test program to xUnit test project
    - Each t_XXX function is converted to a test method TestXXX
    - Instead of writing result to console, message is written to ITestOutputHelper
- Rewritten from C to C# 12.0 (.NET 8.0)
- Testing data and logic are otherwise identical to the original software

# Example
When using vanilla IAU SOFA C Lbrary, if you call the library like below:
```c
#include <stdio.h>
#include <sofa.h>

static void tx_pn()
{
    double utc1, utc2;
    iauCal2jd(2025, 6, 20, &utc1, &utc2);

    double days;
    iauTf2d('+', 21, 24, 37.5, &days);

    utc2 += days;

    double dut1 = 0.3341;
    double date1;
    double date2;
    iauUtcut1(utc1, utc2, dut1, &date1, &date2);

    double dpsi;
    double deps;
    double epsa;
    double rb[3][3];
    double rp[3][3];
    double rbp[3][3];
    double rn[3][3];
    double rbpn[3][3];
    iauPn06a(date1, date2, &dpsi, &deps, &epsa, rb, rp, rbp, rn, rbpn);

    double x = 0, y = 0, s = 0;
    iauXys06a(date1, date2, &x, &y, &s);

    double cio[3][3];
    iauC2ixys(x, y, s, cio);

    double era0 = iauEra00(date1, date2);
    iauRz(era0, cio);

    char sign = ' ';
    int era[4];
    iauA2tf(5, era0, &sign, &era);

    printf("era = %c %d %d %d %d\n", sign, era[0], era[1], era[2], era[3]);
}
```
Then you may write C# code like below when using this library:
```c#
using System;
using AstroRoutines;

class YourClass
{
    public static void tx_pn()
    {
        double utc1, utc2;
        AR.Cal2jd(2025, 6, 20, out utc1, out utc2);

        AR.Tf2d('+', 21, 24, 37.5, out var days);

        utc2 += days;

        var dut1 = 0.3341;
        var date1 = 0.0;
        var date2 = 0.0;
        AR.Utcut1(utc1, utc2, dut1, ref date1, ref date2);

        double dpsi;
        double deps;
        double epsa;
        var rb = new double[3, 3];
        var rp = new double[3, 3];
        var rbp = new double[3, 3];
        var rn = new double[3, 3];
        var rbpn = new double[3, 3];
        AR.Pn06a(date1, date2, out dpsi, out deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);

        double x = 0, y = 0, s = 0;
        AR.Xys06a(date1, date2, ref x, ref y, ref s);

        var cio = new double[3, 3];
        AR.C2ixys(x, y, s, ref cio);

        var era0 = AR.Era00(date1, date2);
        AR.Rz(era0, ref cio);

        var era = new int[4];
        AR.A2tf(5, era0, out char sign, ref era);

        Console.WriteLine($"{nameof(era)} = {sign}{era[0]:D} {era[1]:D} {era[2]:D} {era[3]:D}");
    }
}
```
This example is just for show case only.

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
This project is distributed under Apache-2.0 license, please check LICENSE file for details.

Software Routines from the IAU SOFA Collection were used. Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).

Using SOFA software is free of charge under the terms and conditions of the SOFA licence, whose text is stated in:
- SOFA-LICENSE.md in this repository
- COnstant SOFA_LICENSE_TEXT in library AstroRoutines
- https://www.iausofa.org/tandc.html.

# Alternatives to this package
- CHES2023's PyMsOfa: (https://github.com/CHES2023/PyMsOfa): a Python package for the Standards of Fundamental Astronomy (SOFA) service
- Attila Abrudán's World Wide Astronomy (https://github.com/abrudana/wwa/): World Wide Astronomy - SOFA - for Linux, mac OS, Windows

# FAQ
