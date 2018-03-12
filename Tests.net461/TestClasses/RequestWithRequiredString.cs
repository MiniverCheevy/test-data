using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class RequestWithRequiredString
    {
        [Required]
        public string RequiredString { get; set; }
    }
}