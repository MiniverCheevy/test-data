using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Validation;

namespace Voodoo.TestData.Tests.TestClasses
{
    [Serializable]
    public class ClassWithDate
    {
        [RequiredDateTime]
        public DateTime DateAndTime { get; set; }
    }
}