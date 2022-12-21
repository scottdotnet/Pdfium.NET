using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PdfiumSharp.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPDF_STRUCTTREE : IHandle<FPDF_STRUCTTREE>
    {
        IntPtr _ptr;

        FPDF_STRUCTTREE(IntPtr ptr)
            => _ptr = ptr;

        public bool IsNull => _ptr == IntPtr.Zero;

        public override string ToString() => "FPDF_STRUCTTREE: 0x" + _ptr.ToString("X16");

        public static FPDF_STRUCTTREE Null => new FPDF_STRUCTTREE();

        public FPDF_STRUCTTREE SetToNull() => new FPDF_STRUCTTREE(Interlocked.Exchange(ref _ptr, IntPtr.Zero));
    }
}
