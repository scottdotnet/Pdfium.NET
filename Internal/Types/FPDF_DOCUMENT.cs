using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_DOCUMENT : IHandle<FPDF_DOCUMENT>
    {
        IntPtr _ptr;

        FPDF_DOCUMENT(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_DOCUMENT: 0x" + _ptr.ToString("X16");

        public static FPDF_DOCUMENT Null => new FPDF_DOCUMENT();

        public FPDF_DOCUMENT SetToNull() => new FPDF_DOCUMENT(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
