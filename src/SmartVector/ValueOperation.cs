using System;

namespace SmartVector
{
    /// <summary>
    /// Provides methods which generalizes standard operations.
    /// </summary>
    public static partial class ValueOperation
    {
        private static class Cache<T>
        {
            public static IValueOperation<T> Instance => _Instance ?? throw new NotSupportedException();
            private static IValueOperation<T>? _Instance;
            private static readonly object _LockToken = new object();


            static Cache()
            {
                var attrs = typeof(T).GetCustomAttributes(typeof(ValueOperationAttribute), false);
                if(attrs.Length != 1)
                {
                    return;
                }
                if(attrs[0] is not ValueOperationAttribute attr)
                {
                    return;
                }
                _Instance = Activator.CreateInstance(attr.OperationProviderType) as IValueOperation<T>;
            }


            public static void Register(IValueOperation<T> operation)
            {
                lock(_LockToken)
                {
                    if(Cache<T>._Instance is not null)
                    {
                        throw new InvalidOperationException("An operation strategy instance was already set.");
                    }
                    Cache<T>._Instance = operation;
                }
            }
        }


        /// <summary>
        /// Registers value operation strategy.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operation"></param>
        public static void Register<T>(IValueOperation<T> operation)
            => Cache<T>.Register(operation);
    }
}
