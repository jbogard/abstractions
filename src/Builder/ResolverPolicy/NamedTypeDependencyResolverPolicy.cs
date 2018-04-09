﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Unity.Builder;
using Unity.Policy;

namespace Unity.ResolverPolicy
{
    /// <summary>
    /// An implementation of <see cref="IResolverPolicy"/> that stores a
    /// type and name, and at resolution time puts them together into a
    /// <see cref="NamedTypeBuildKey"/>.
    /// </summary>
    public class NamedTypeDependencyResolverPolicy : IResolverPolicy
    {
        /// <summary>
        /// Create an instance of <see cref="NamedTypeDependencyResolverPolicy"/>
        /// with the given type and name.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name (may be null).</param>
        public NamedTypeDependencyResolverPolicy(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        /// <summary>
        /// ResolvePipeline the value for a @delegate.
        /// </summary>
        /// <param name="context">Current build context.</param>
        /// <returns>The value for the @delegate.</returns>
        public object Resolve(IBuilderContext context)
        {
            return (context ?? throw new ArgumentNullException(nameof(context)))
                .NewBuildUp(Type, Name);
        }

        /// <summary>
        /// The type that this resolver resolves.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// The name that this resolver resolves.
        /// </summary>
        public string Name { get; }
    }
}