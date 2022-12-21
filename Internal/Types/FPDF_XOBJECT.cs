using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_XOBJECT : IHandle<FPDF_XOBJECT>
    {
        IntPtr _ptr;

        FPDF_XOBJECT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_XOBJECT: 0x" + _ptr.ToString("X16");

        public static FPDF_XOBJECT Null => new FPDF_XOBJECT();

        public FPDF_XOBJECT SetToNull() => new FPDF_XOBJECT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
