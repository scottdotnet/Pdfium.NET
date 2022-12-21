﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HDC : IHandle<HDC>
    {
        IntPtr _ptr;

        HDC(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "HDC: 0x" + _ptr.ToString("X16");

        public static HDC Null => new HDC();

        public HDC SetToNull() => new HDC(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}