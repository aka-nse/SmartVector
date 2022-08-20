using System;
using System.Collections.Generic;
using System.Text;

namespace SmartVector
{
    /// <summary>
    /// Provides abstraction of vectorized primitive operations.
    /// </summary>
    public abstract partial class VectorOperation
    {
        private sealed partial class _Emulated : VectorOperation
        {
        }
        public static VectorOperation Emulated { get; } = new _Emulated();

        public virtual VectorOperation Fallback => Emulated;

    }


    public abstract partial class VectorOperationSpecialized : VectorOperation
    {
    }
}
