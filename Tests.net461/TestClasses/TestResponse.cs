using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Messages;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class TestResponse : Response
    {
        public bool ExecuteFinished { get; set; }
    }
}