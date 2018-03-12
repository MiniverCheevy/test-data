using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Messages;
using Voodoo.Operations;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class CommandThatDoesNotThrowErrors : Command<EmptyRequest, Response>
    {
        public CommandThatDoesNotThrowErrors(EmptyRequest request) : base(request)
        {
        }

        protected override Response ProcessRequest()
        {
            return response;
        }
    }
}