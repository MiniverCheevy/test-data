﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voodoo;
using Voodoo.Infrastructure;
using Voodoo.Messages;
using Voodoo.Operations.Async;

namespace Voodoo.TestData.Tests.TestClasses
{
    public class ExecutorAsyncThatFailsValidation : ExecutorAsync<EmptyRequest, TestResponse>
    {
        public ExecutorAsyncThatFailsValidation(EmptyRequest request)
            : base(request)
        {
        }

        protected override async Task Validate()
        {
            await Task.Run(() => { throw new LogicException("Boom"); });
        }

        protected override async Task<TestResponse> ProcessRequestAsync()
        {
            await Task.Run(() => { response.ExecuteFinished = true; });
            return response;
        }
    }
}