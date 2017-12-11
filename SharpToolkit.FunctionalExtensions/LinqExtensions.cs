﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpToolkit.FunctionalExtensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>>
            GetPermutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static (IEnumerable<T> trues, IEnumerable<T> falses)
            Partition<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return (collection.Where(predicate), collection.Where(x => predicate(x) == false));
        }

        public static U Do<T, U>(this T obj, Func<T, U> fn)
        {
            return fn(obj);
        }

    }
}
