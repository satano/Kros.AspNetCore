﻿using FluentAssertions;
using Kros.AspNetCore.Exceptions;
using Kros.MediatR.PostProcessors;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Kros.MediatR.Extensions.Tests.PostProcessors
{
    public class NullCheckPostProcessorShould
    {
        [Fact]
        public void ThrowExceptionWhenResponseIsNull()
        {
            var postProcessor = new NullCheckPostProcessor<string, string>();

            Action action = () => postProcessor.Process("", null);

            action.Should().Throw<NotFoundException>();
        }

        [Fact]
        public void DoNotThrowExceptionWhenResponseIsNotNull()
        {
            var postProcessor = new NullCheckPostProcessor<string, string>();

            Action action = () => postProcessor.Process("request", "response");

            action.Should().NotThrow<NotFoundException>();
        }
    }
}
