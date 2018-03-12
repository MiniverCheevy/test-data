﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class Operation
    {
        public int Id { get; set; }
        public Level? MinimumLevel { get; set; }
        public Department Department { get; set; }
        public string Name { get; set; }
    }
}