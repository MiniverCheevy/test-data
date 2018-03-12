using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Operations;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class CommandWithNonEmptyRequest : Command<RequestWithRequiredString, TestingResponse>
    {
        public CommandWithNonEmptyRequest(RequestWithRequiredString request) : base(request)
        {
        }

        protected override TestingResponse ProcessRequest()
        {
            return response;
        }
    }
}