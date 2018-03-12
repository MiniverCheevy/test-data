using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Validation;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class ClassWithCollection
    {
        [CollectionMustHaveAtLeastOneItem]
        public List<string> Items { get; set; }

        public ClassWithCollection()
        {
            Items = new List<string>();
        }
    }
}