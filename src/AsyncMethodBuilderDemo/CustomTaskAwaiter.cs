using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMethodBuilderDemo
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public struct CustomTaskAwaiter : ICriticalNotifyCompletion
    {
        //private static readonly AsyncMethodBuilder<CustomTaskAwaiter> _builder = AsyncMethodBuilder<CustomTaskAwaiter>.Create();

        private bool _isCompleted;

        public bool IsCompleted => _isCompleted;

        public void OnCompleted(Action continuation)
        {
            Console.WriteLine("CustomTaskAwaiter: OnCompleted");
            continuation();
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            Console.WriteLine("CustomTaskAwaiter: UnsafeOnCompleted");
            continuation();
        }

        public void GetResult()
        {
            Console.WriteLine("CustomTaskAwaiter: GetResult");
        }

        public CustomTaskAwaiter GetAwaiter()
        {
            return this;
        }

        //public static CustomTaskAwaiter Create()
        //{
        //    return _builder.AwaitOnCompleted<CustomTaskAwaiter, CustomTaskAwaiter>(_builder, ref _builder, ref _builder);
        //}
    }

    public static class AsyncExtensions
    {
        //public static CustomTaskAwaiter GetAwaiter(this Task task)
        //{
        //    Console.WriteLine("AsyncExtensions: GetAwaiter");
        //    return CustomTaskAwaiter.Create();
        //}
    }

}
