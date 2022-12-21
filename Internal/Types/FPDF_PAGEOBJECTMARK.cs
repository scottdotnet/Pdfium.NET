using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_PAGEOBJECTMARK : IHandle<FPDF_PAGEOBJECTMARK>
    {
        IntPtr _ptr;

        FPDF_PAGEOBJECTMARK(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_PAGEOBJECTMARK: 0x" + _ptr.ToString("X16");

        public static FPDF_PAGEOBJECTMARK Null => new FPDF_PAGEOBJECTMARK();

        public FPDF_PAGEOBJECTMARK SetToNull() => new FPDF_PAGEOBJECTMARK(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
