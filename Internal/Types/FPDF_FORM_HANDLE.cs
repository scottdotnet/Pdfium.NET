using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_FORM_HANDLE : IHandle<FPDF_FORM_HANDLE>
    {
        IntPtr _ptr;

        FPDF_FORM_HANDLE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_FORM_HANDLE: 0x" + _ptr.ToString("X16");

        public static FPDF_FORM_HANDLE Null => new FPDF_FORM_HANDLE();

        public FPDF_FORM_HANDLE SetToNull() => new FPDF_FORM_HANDLE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
