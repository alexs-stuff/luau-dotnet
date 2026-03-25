#pragma warning disable CS8500
#pragma warning disable CS8981

using System;
using System.Runtime.InteropServices;

namespace Luau.Native
{
    // malloc/free

    unsafe partial class NativeMethods
    {
        public static void* malloc(nuint size)
        {
            if (IntPtr.Size == 8)
            {
                return (void*)Marshal.AllocHGlobal(new IntPtr(unchecked((long)size)));
            }

            return (void*)Marshal.AllocHGlobal(new IntPtr(unchecked((int)size)));
        }

        public static void free(void* ptr)
        {
            if (ptr != null)
            {
                Marshal.FreeHGlobal((IntPtr)ptr);
            }
        }
    }
    }
}