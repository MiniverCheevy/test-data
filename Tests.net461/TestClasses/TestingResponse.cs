using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Messages;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class TestingResponse : Response
    {
        public const string OhNo = "Oh noes!";
        public const string CustomErrorBehavior = "Custom Error Behavior is Custom";
        public string TestingData { get; set; }
    }
}