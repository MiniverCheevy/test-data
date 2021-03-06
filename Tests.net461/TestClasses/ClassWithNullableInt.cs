﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Validation;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class ClassWithNullableInt
    {
        [RequiredNonZeroInt]
        public int? Number { get; set; }
    }
}