using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Validation;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class ClassWithNullableDate
    {
        [RequiredDateTime]
        public DateTime? DateAndTime { get; set; }
    }
}