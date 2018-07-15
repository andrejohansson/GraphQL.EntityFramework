﻿using System;
using System.Collections.Generic;
using EfCoreGraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

static class ArgumentGraphs
{
    static Dictionary<Type, GraphType> entries = new Dictionary<Type, GraphType>();

    static ArgumentGraphs()
    {
        GraphTypeTypeRegistry.Register(typeof(Comparison), typeof(ComparisonGraph));
        Add<WhereExpressionGraph>();
        Add<ComparisonGraph>();
    }

    public static void RegisterInContainer(Action<Type, GraphType> registerInstance)
    {
        foreach (var entry in entries)
        {
            registerInstance(entry.Key, entry.Value);
        }
    }

    static void Add<T>()
        where T : GraphType, new()
    {
        var value = new T();
        entries.Add(typeof(T), value);
    }
}