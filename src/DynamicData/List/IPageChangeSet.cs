// Copyright (c) 2011-2020 Roland Pheasant. All rights reserved.
// Roland Pheasant licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using DynamicData.Operators;

// ReSharper disable once CheckNamespace
namespace DynamicData;

/// <summary>
/// Represents a paged subset of data reduced by a defined set of parameters
/// Changes are always published in the order.
/// </summary>
/// <typeparam name="T">The type of the object.</typeparam>
public interface IPageChangeSet<T> : IChangeSet<T>
{
    /// <summary>
    /// Gets the parameters used to virtualise the stream.
    /// </summary>
    IPageResponse Response { get; }
}
