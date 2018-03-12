﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Messages;
using Voodoo.Operations.Async;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class ExecutorAsyncThatThrowsExceptions : ExecutorAsync<EmptyRequest, TestResponse>
    {
        public ExecutorAsyncThatThrowsExceptions(EmptyRequest request) : base(request)
        {
        }

        protected override async Task<TestResponse> ProcessRequestAsync()
        {
            await Task.Delay(300);
            throw new Exception("Boom");
#pragma warning disable 162
            response.ExecuteFinished = true;
#pragma warning restore 162
        }
    }
}