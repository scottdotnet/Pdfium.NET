using Pdfium.NET.Internal.Types;
using System;
using System.Runtime.InteropServices;

namespace Pdfium.NET.Internal.Imports
{
    internal static class FPDF
    {
        /// <summary>
        /// Initialize the FPDFSDK library
        /// Convenience function to call FPDF_InitLibraryWithConfig() for backwards compatibility purposes. This will be deprecated in the future.
        /// </summary>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_InitLibrary();

        /// <summary>
        /// Initialize the FPDFSDK library
        /// You have to call this function before you can call any PDF processing functions.
        /// </summary>
        /// <param name="config">Configuration information.</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_InitLibraryWithConfig(ref FPDF_LIBRARY_CONFIG config);

        /// <summary>
        /// Release all resources allocated by the FPDFSDK library.
        /// </summary>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_DestroyLibrary();

        /// <summary>
        /// Open and load a PDF document.
        /// Loaded document can be closed by FPDF_CloseDocument().
        /// If this function fails, you can use FPDF_GetLastError() to retrieve the reason why it failed.
        /// The encoding for <paramref name="file_path"/> is UTF-8.
        /// The encoding for <paramref name="password"/> can be either UTF-8 or Latin-1. PDFs, depending on the security handler revision, will only accept one or the other encoding. If <paramref name="password"/>'s encoding and the PDF's expected encoding do not match, FPDF_LoadDocument() will automatically convert <paramref name="password"/> to the other encoding.
        /// </summary>
        /// <param name="file_path">Path to the PDF file (including extension).</param>
        /// <param name="password">A string used as the password for the PDF file. If no password is needed, empty or NULL can be used.See comments below regarding the encoding.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_DOCUMENT FPDF_LoadDocument([MarshalAs(UnmanagedType.LPStr)] string file_path, [MarshalAs(UnmanagedType.LPStr)] string password);

        /// <summary>
        /// Open and load a PDF document from memory.
        /// The memory buffer must remain valid when the document is open.
        /// The loaded document can be closed by FPDF_CloseDocument.
        /// If this function fails, you can use FPDF_GetLastError() to retrieve the reason why it failed.
        /// See the comments for FPDF_LoadDocument() regarding the encoding for <paramref name="password"/>.
        /// </summary>
        /// <param name="data_buf">Pointer to a buffer containing the PDF document.</param>
        /// <param name="size">Number of bytes in the PDF document.</param>
        /// <param name="password">A string used as the password for the PDF file. If no password is needed, empty or NULL can be used.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_DOCUMENT FPDF_LoadMemDocument(ref byte data_buf, int size, [MarshalAs(UnmanagedType.LPStr)] string password);

        /// <summary>
        /// Load PDF document from a custom access descriptor.
        /// The application must keep the file resources <paramref name="fileRead"/> points to valid until the returned FPDF_DOCUMENT is closed. <paramref name="fileRead"/> itself does not need to outlive the FPDF_DOCUMENT.
        /// The loaded document can be closed with FPDF_CloseDocument().
        /// See the comments for FPDF_LoadDocument() regarding the encoding for <paramref name="password"/>.
        /// </summary>
        /// <param name="fileRead">A structure for accessing the file.</param>
        /// <param name="password">Optional password for decrypting the PDF file.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_DOCUMENT FPDF_LoadCustomDocument(FPDF_FILEREAD fileRead, [MarshalAs(UnmanagedType.LPStr)] string password);

        /// <summary>
        /// Get the file version of the given PDF document.
        /// If the document was created by FPDF_CreateNewDocument, then this function will always fail.
        /// </summary>
        /// <param name="doc">Handle to a document.</param>
        /// <param name="fileVersion">The PDF file version. File version: 14 for 1.4, 15 for 1.5, ...</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_GetFileVersion(FPDF_DOCUMENT doc, out int fileVersion);

        /// <summary>
        /// Get last error code when a function fails.
        /// If the previous SDK call succeeded, the return value of this function is not defined. This function only works in conjunction with APIs that mention FPDF_GetLastError() in their documentation.
        /// </summary>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_ERR FPDF_GetLastError();

        /// <summary>
        /// Whether the document's cross reference table is valid or not.
        /// </summary>
        /// <param name="document">Handle to a document. Returned by FPDF_LoadDocument.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_DocumentHasValidCrossReferenceTable(FPDF_DOCUMENT document);

        /// <summary>
        /// Get the byte offsets of trailer ends.
        /// </summary>
        /// <param name="document">Handle to document. Returned by FPDF_LoadDocument().</param>
        /// <param name="buffer">The address of a buffer that receives the byte offsets.</param>
        /// <param name="length">The size, in ints, of <paramref name="buffer"/>.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_GetTrailerEnds(FPDF_DOCUMENT document, ref byte buffer, out long length);

        /// <summary>
        /// Get file permission flags of the document.
        /// </summary>
        /// <param name="document">Handle to a document. Returned by FPDF_LoadDocument.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern uint FPDF_GetDocPermissions(FPDF_DOCUMENT document);

        /// <summary>
        /// Get the revision for the security handler.
        /// </summary>
        /// <param name="document">Handle to a document. Returned by FPDF_LoadDocument.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_GetSecurityHandlerRevision(FPDF_DOCUMENT document);

        /// <summary>
        /// Get total number of pages in the document.
        /// </summary>
        /// <param name="document">Handle to document. Returned by FPDF_LoadDocument.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_GetPageCount(FPDF_DOCUMENT document);

        /// <summary>
        /// Load a page inside the document.
        /// The loaded page can be rendered to devices using FPDF_RenderPage.
        /// The loaded page can be closed using FPDF_ClosePage.
        /// </summary>
        /// <param name="document">Handle to document. Returned by FPDF_LoadDocument.</param>
        /// <param name="page_index">Index number of the page. 0 for the first page.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_PAGE FPDF_LoadPage(FPDF_DOCUMENT document, int page_index);

        /// <summary>
        /// Get page width.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage().</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern float FPDF_GetPageWidthF(FPDF_PAGE page);

        /// <summary>
        /// Get page width.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage().</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern double FPDF_GetPageWidth(FPDF_PAGE page);

        /// <summary>
        /// Get page height.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage().</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern float FPDF_GetPageHeightF(FPDF_PAGE page);

        /// <summary>
        /// Get page height.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage().</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern double FPDF_GetPageHeight(FPDF_PAGE page);

        /// <summary>
        /// Get the bounding box of the page. This is the intersection between its media box and its crop box.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="rect">Pointer to a rect to receive the page bounding box. On an error, <paramref name="rect"/> won't be filled.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_GetPageBoundingBox(FPDF_PAGE page, out FS_RECTF rect);

        /// <summary>
        /// Get the size of the page at the given index.
        /// </summary>
        /// <param name="document">Handle to document. Returned by FPDF_LoadDocument().</param>
        /// <param name="page_index">Page index, zero for the first page.</param>
        /// <param name="size">Pointer to a FS_SIZEF to receive the page size (in points).</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_GetPageSizeByIndexF(FPDF_DOCUMENT document, int page_index, out FS_SIZEF size);

        /// <summary>
        /// Get the size of the page at the given index.
        /// </summary>
        /// <param name="document">Handle to document. Returned by FPDF_LoadDocument.</param>
        /// <param name="page_index">Page index, zero for the first page.</param>
        /// <param name="width">Pointer to a double to receive the page width (in points).</param>
        /// <param name="height">Pointer to a double to receive the page height (in points).</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_GetPageSizeByIndex(FPDF_DOCUMENT document, int page_index, out double width, out double height);

        /// <summary>
        /// Render contents of a page to a device (screen, bitmap, or printer).
        /// This function is only supported on Windows.
        /// </summary>
        /// <param name="dc">Handle to the device context.</param>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="start_x">Left pixel position of the display area in device coordinates.</param>
        /// <param name="start_y">Top pixel position of the display area in device coordinates.</param>
        /// <param name="size_x">Horizontal size (in pixels) for displaying the page.</param>
        /// <param name="size_y">Vertical size (in pixels) for displaying the page.</param>
        /// <param name="rotate">Page orientation: 0 (normal), 1 (rotated 90 degrees clockwise), 2 (rotated 180 degrees), 3 (rotated 90 degrees counter-clockwise)</param>
        /// <param name="flags">0 for normal display, or combination of flags defined above.</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_RenderPage(HDC dc, FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

        /// <summary>
        /// Render contents of a page to a device independent bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to the device independent bitmap (as the output buffer). The bitmap handle can be created by FPDFBitmap_Create or retrieved from an image object by FPDFImageObj_GetBitmap.</param>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="start_x">Left pixel position of the display area in device coordinates.</param>
        /// <param name="start_y">Top pixel position of the display area in device coordinates.</param>
        /// <param name="size_x">Horizontal size (in pixels) for displaying the page.</param>
        /// <param name="size_y">Vertical size (in pixels) for displaying the page.</param>
        /// <param name="rotate">Page orientation: 0 (normal), 1 (rotated 90 degrees clockwise), 2 (rotated 180 degrees), 3 (rotated 90 degrees counter-clockwise)</param>
        /// <param name="flags">0 for normal display, or combination of flags defined above.</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_RenderPageBitmap(FPDF_BITMAP bitmap, FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int flags);

        /// <summary>
        /// Render contents of a page to a device independent bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to the device independent bitmap (as the output buffer). The bitmap handle can be created by FPDFBitmap_Create or retrieved by FPDFImageObj_GetBitmap.</param>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="matrix">The transform matrix, which must be invertible. See PDF Reference 1.7, 4.2.2 Common Transformations.</param>
        /// <param name="clipping">The rect to clip to in device coords.</param>
        /// <param name="flags">0 for normal display, or combination of the Page Rendering flags defined above. With the FPDF_ANNOT flag, it renders all annotations that do not require user-interaction, which are all annotations except widget and popup annotations.</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_RenderPageBitmapWithMatrix(FPDF_BITMAP bitmap, FPDF_PAGE page, out FS_MATRIX matrix, out FS_RECTF clipping, int flags);

        /// <summary>
        /// Render contents of a page to a Skia SkPictureRecorder.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="size_x">Horizontal size (in pixels) for displaying the page.</param>
        /// <param name="size_y">Vertical size (in pixels) for displaying the page.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_RECORDER FPDF_RenderPageSkp(FPDF_PAGE page, int size_x, int size_y);

        /// <summary>
        /// Close a loaded PDF page.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_ClosePage(FPDF_PAGE page);

        /// <summary>
        /// Close a loaded PDF document.
        /// </summary>
        /// <param name="document">Handle to the loaded document. Returned by FPDF_LoadDocument</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDF_CloseDocument(FPDF_DOCUMENT document);

        /// <summary>
        /// Convert the screen coordinates of a point to page coordinates.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="start_x">Left pixel position of the display area in device coordinates.</param>
        /// <param name="start_y">Top pixel position of the display area in device coordinates.</param>
        /// <param name="size_x">Horizontal size (in pixels) for displaying the page.</param>
        /// <param name="size_y">Vertical size (in pixels) for displaying the page.</param>
        /// <param name="rotate">Page orientation: 0 (normal), 1 (rotated 90 degrees clockwise), 2 (rotated 180 degrees), 3 (rotated 90 degrees counter-clockwise)</param>
        /// <param name="device_x">X value in device coordinates to be converted.</param>
        /// <param name="device_y">Y value in device coordinates to be converted.</param>
        /// <param name="page_x">A pointer to a double receiving the converted X value in page coordinates.</param>
        /// <param name="page_y">A pointer to a double receiving the converted Y value in page coordinates.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_DeviceToPage(FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, int device_x, int device_y, out double page_x, out double page_y);

        /// <summary>
        /// Convert the page coordinates of a point to screen coordinates.
        /// </summary>
        /// <param name="page">Handle to the page. Returned by FPDF_LoadPage.</param>
        /// <param name="start_x">Left pixel position of the display area in device coordinates.</param>
        /// <param name="start_y">Top pixel position of the display area in device coordinates.</param>
        /// <param name="size_x">Horizontal size (in pixels) for displaying the page.</param>
        /// <param name="size_y">Vertical size (in pixels) for displaying the page.</param>
        /// <param name="rotate">Page orientation: 0 (normal), 1 (rotated 90 degrees clockwise), 2 (rotated 180 degrees), 3 (rotated 90 degrees counter-clockwise)</param>
        /// <param name="page_x">X value in page coordinates.</param>
        /// <param name="page_y">Y value in page coordinates.</param>
        /// <param name="device_x">A pointer to an integer receiving the result X value in device coordinates.</param>
        /// <param name="device_y">A pointer to an integer receiving the result Y value in device coordinates.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_PageToDevice(FPDF_PAGE page, int start_x, int start_y, int size_x, int size_y, int rotate, double page_x, double page_y, out int device_x, out int device_y);

        /// <summary>
        /// Create a device independent bitmap (FXDIB).
        /// The bitmap always uses 4 bytes per pixel. The first byte is always double word aligned.
        /// The byte order is BGRx (the last byte unused if no alpha channel) or BGRA.
        /// The pixels in a horizontal line are stored side by side, with the left most pixel stored first (with lower memory address). Each line uses width * 4 bytes.
        /// Lines are stored one after another, with the top most line stored first. There is no gap between adjacent lines.
        /// This function allocates enough memory for holding all pixels in the bitmap, but it doesn't initialize the buffer. Applications can use FPDFBitmap_FillRect() to fill the bitmap using any color. If the OS allows it, this function can allocate up to 4 GB of memory.
        /// </summary>
        /// <param name="width">The number of pixels in width for the bitmap. Must be greater than 0.</param>
        /// <param name="height">The number of pixels in height for the bitmap. Must be greater than 0.</param>
        /// <param name="alpha">A flag indicating whether the alpha channel is used. Non-zero for using alpha, zero for not using.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_BITMAP FPDFBitmap_Create(int width, int height, int alpha);

        /// <summary>
        /// Create a device independent bitmap (FXDIB)
        /// </summary>
        /// <param name="width">The number of pixels in width for the bitmap. Must be greater than 0.</param>
        /// <param name="height">The number of pixels in height for the bitmap. Must be greater than 0.</param>
        /// <param name="format">A number indicating for bitmap format, as defined above.</param>
        /// <param name="first_scan">A pointer to the first byte of the first line if using an external buffer. If this parameter is NULL, then a new buffer will be created.</param>
        /// <param name="stride">Number of bytes for each scan line. The value must be 0 or greater. When the value is 0, FPDFBitmap_CreateEx() will automatically calculate the appropriate value using <paramref name="width"/> and <paramref name="format"/>. When using an external buffer, it is recommended for the caller to pass in the value. When not using an external buffer, it is recommended for the caller to pass in 0.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_BITMAP FPDFBitmap_CreateEx(int width, int height, int format, IntPtr first_scan, int stride);

        /// <summary>
        /// Get the format of the bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to the bitmap. Returned by FPDFBitmap_Create or FPDFImageObj_GetBitmap.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDFBitmap_GetFormat(FPDF_BITMAP bitmap);

        /// <summary>
        /// Fill a rectangle in a bitmap.
        /// </summary>
        /// <param name="bitmap">The handle to the bitmap. Returned by FPDFBitmap_Create.</param>
        /// <param name="left">The left position. Starting from 0 at the left-most pixel.</param>
        /// <param name="top">The top position. Starting from 0 at the top-most line.</param>
        /// <param name="width">Width in pixels to be filled.</param>
        /// <param name="height">Height in pixels to be filled.</param>
        /// <param name="color">A 32-bit value specifing the color, in 8888 ARGB format.</param>
        [DllImport("libpdfium.so")]
        public static extern void FPDFBitmap_FillRect(FPDF_BITMAP bitmap, int left, int top, int width, int height, FPDF_COLOR color);

        /// <summary>
        /// Get data buffer of a bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to the bitmap. Returned by FPDFBitmap_Create or FPDFImageObj_GetBitmap.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern IntPtr FPDFBitmap_GetBuffer(FPDF_BITMAP bitmap);

        /// <summary>
        /// Get width of a bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to the bitmap. Returned by FPDFBitmap_Create or FPDFImageObj_GetBitmap.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDFBitmap_GetWidth(FPDF_BITMAP bitmap);

        /// <summary>
        /// Get height of a bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to the bitmap. Returned by FPDFBitmap_Create or FPDFImageObj_GetBitmap.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDFBitmap_GetHeight(FPDF_BITMAP bitmap);

        /// <summary>
        /// Get number of bytes for each line in the bitmap buffer.
        /// </summary>
        /// <param name="bitmap">Handle to the bitmap. Returned by FPDFBitmap_Create or FPDFImageObj_GetBitmap.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDFBitmap_GetStride(FPDF_BITMAP bitmap);

        /// <summary>
        /// Destroy a bitmap and release all related buffers.
        /// </summary>
        /// <param name="bitmap">Handle to the bitmap. Returned by FPDFBitmap_Create or FPDFImageObj_GetBitmap.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDFBitmap_Destroy(FPDF_BITMAP bitmap);

        /// <summary>
        /// Whether the PDF document prefers to be scaled or not.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern bool FPDF_VIEWERREF_GetPrintScaling(FPDF_DOCUMENT document);

        /// <summary>
        /// Returns the number of copies to be printed.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_VIEWERREF_GetNumCopies(FPDF_DOCUMENT document);

        /// <summary>
        /// Page numbers to initialize print dialog box when file is printed.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_PAGERANGE FPDF_VIEWERREF_GetPrintPageRange(FPDF_DOCUMENT document);

        /// <summary>
        /// Returns the number of elements in a FPDF_PAGERANGE.
        /// </summary>
        /// <param name="pagerange">Handle to the page range.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_VIEWERREF_GetPrintPageRangeCount(FPDF_PAGERANGE pagerange);

        /// <summary>
        /// Returns an element from a FPDF_PAGERANGE.
        /// </summary>
        /// <param name="pagerange">Handle to the page range.</param>
        /// <param name="index">Index of the element.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_VIEWERREF_GetPrintPageRangeElement(FPDF_PAGERANGE pagerange, int index);

        /// <summary>
        /// Returns the paper handling option to be used when printing from the print dialog.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_DUPLEXTYPE FPDF_VIEWERREF_GetDuplex(FPDF_DOCUMENT document);

        /// <summary>
        /// Gets the contents for a viewer ref, with a given key. The value must be of type "name".
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <param name="key">Name of the key in the viewer pref dictionary, encoded in UTF-8.</param>
        /// <param name="buffer">A string to write the contents of the key to.</param>
        /// <param name="length">Length of the buffer.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern uint FPDF_VIEWERREF_GetName(FPDF_DOCUMENT document, [MarshalAs(UnmanagedType.LPStr)] string key, ref byte buffer, uint length);

        /// <summary>
        /// Get the count of named destinations in the PDF document.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern int FPDF_CountNamedDests(FPDF_DOCUMENT document);

        /// <summary>
        /// Get a the destination handle for the given name.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <param name="name">The name of a destination.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_DEST FPDF_GetNamedDestByName(FPDF_DOCUMENT document, [MarshalAs(UnmanagedType.LPStr)] string name);

        /// <summary>
        /// Get the named destination by index.
        /// </summary>
        /// <param name="document">Handle to the loaded document.</param>
        /// <param name="index">The index of a named destination.</param>
        /// <param name="buffer">The buffer to store the destination name.</param>
        /// <param name="buflen">Size of the buffer in bytes on input, length of the result in bytes on output or -1 if the buffer is too small.</param>
        /// <returns></returns>
        [DllImport("libpdfium.so")]
        public static extern FPDF_DEST FPDF_GetNamedDest(FPDF_DOCUMENT document, int index, IntPtr buffer, out int buflen);
    }
}
