using System.Runtime.InteropServices;

namespace Pdfium.NET.Internal.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FS_SIZEF
    {
        public FS_SIZEF(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }
        public float Height { get; }
    }
}
