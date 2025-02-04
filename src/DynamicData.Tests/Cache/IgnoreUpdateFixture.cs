﻿using System;

using DynamicData.Tests.Domain;

using FluentAssertions;

using Xunit;

namespace DynamicData.Tests.Cache;

public class IgnoreUpdateFixture : IDisposable
{
    private readonly ChangeSetAggregator<Person, string> _results;

    private readonly ISourceCache<Person, string> _source;

    public IgnoreUpdateFixture()
    {
        _source = new SourceCache<Person, string>(p => p.Key);
        _results = new ChangeSetAggregator<Person, string>(_source.Connect().IgnoreUpdateWhen((current, previous) => current == previous));
    }

    public void Dispose()
    {
        _source.Dispose();
    }

    [Fact]
    public void IgnoreFunctionWillIgnoreSubsequentUpdatesOfAnItem()
    {
        var person = new Person("Person", 10);
        _source.AddOrUpdate(person);
        _source.AddOrUpdate(person);
        _source.AddOrUpdate(person);

        _results.Messages.Count.Should().Be(1, "Should be 1 updates");
        _results.Data.Count.Should().Be(1, "Should be 1 item in the cache");
    }
}
