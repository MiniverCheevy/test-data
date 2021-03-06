﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;

namespace Voodoo.TestData.Tests.TestClasses
{
    public enum TestEnum
    {
        Red = 1,
        Blue = 2,
        RedOrangeYellow = 3
    }


    public enum MeasurementType
    {
        [Description("Whole Number")] WholeNumber = 1,
        [Description("Numerator/Denominator - Lowest Common Multiple")] NumDenomLCM = 2,
        [Description("Numerator/Denominator - Sum Method")] NumDenomSum = 3,
        [Description("Numerator/Denominator - Sum Method multiplied by 100")] NumDenomSumX100 = 4
    }

    public enum TestEnumWithDescriptionAndDisplay
    {
        [Description("Crimson")] Red = 1,
        [Display(Name = "Azure")] Blue = 2,
        RedOrangeYellow = 3
    }
}