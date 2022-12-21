using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_WIDGET : IHandle<FPDF_WIDGET>
    {
        IntPtr _ptr;

        FPDF_WIDGET(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_WIDGET: 0x" + _ptr.ToString("X16");

        public static FPDF_WIDGET Null => new FPDF_WIDGET();

        public FPDF_WIDGET SetToNull() => new FPDF_WIDGET(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
