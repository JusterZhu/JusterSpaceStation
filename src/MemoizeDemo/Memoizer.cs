using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoizeDemo
{
    internal static class Memoizer
    {
        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> function)
        {
            var cache = new Dictionary<T, TResult>();

            return argument =>
            {
                TResult result;

                if (!cache.TryGetValue(argument, out result))
                {
                    result = function(argument);
                    cache.Add(argument, result);
                }

                return result;
            };
        }

        public static Func<T, TResult> Memoize2<T, TResult>(this Func<T, TResult> func)
        {
            var cache = new ConcurrentDictionary<T, Lazy<TResult>>();

            return arg =>
            {
                // 使用GetOrAdd方法保证线程安全性
                return cache.GetOrAdd(arg, toCache => new Lazy<TResult>(() => func(toCache))).Value;
            };
        }

        public static Func<T, TResult> Memoize3<T, TResult>(this Func<T, TResult> func)
        {
            var cache = new ConcurrentDictionary<T, Lazy<TResult>>();

            return arg =>
            {
                // 使用GetOrAdd方法保证线程安全性
                return cache.GetOrAdd(arg, toCache => new Lazy<TResult>(() => func(toCache))).Value;
            };
        }
    }

    public class Memoizer<TInput, TOutput>
    {
        private readonly ConcurrentDictionary<TInput, Lazy<WeakReference>> cache;
        private readonly Func<TInput, TOutput> createFunc;

        public Memoizer(Func<TInput, TOutput> createFunc)
        {
            if (createFunc == null) throw new ArgumentNullException("createFunc");
            this.createFunc = createFunc;
            this.cache = new ConcurrentDictionary<TInput, Lazy<WeakReference>>();
        }

        public TOutput Get(TInput input)
        {
            // 使用Lazy<WeakReference>来支持延迟加载和弱引用
            var lazy = cache.GetOrAdd(input, _ => new Lazy<WeakReference>(() => new WeakReference(createFunc(input)), LazyThreadSafetyMode.ExecutionAndPublication));

            var weakRef = lazy.Value;
            if (weakRef.IsAlive)
            {
                return (TOutput)weakRef.Target;
            }
            else
            {
                // 如果目标已被垃圾回收器回收，则重新创建并更新弱引用
                var newValue = createFunc(input);
                weakRef.Target = newValue;
                return newValue;
            }
        }
    }
}
