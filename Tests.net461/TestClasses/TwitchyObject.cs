using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class TwitchyObject
    {
        public string BrokenProperty
        {
            get { throw new NotImplementedException(); }
        }

        public void MethodThatReturnsNothing()
        {
        }
    }
}