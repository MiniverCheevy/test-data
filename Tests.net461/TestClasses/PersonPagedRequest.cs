using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Messages;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class PersonPagedRequest : PagedRequest

    {
        public string Text { get; set; }

        public override string DefaultSortMember
        {
            get { return "Id"; }
        }
    }
}