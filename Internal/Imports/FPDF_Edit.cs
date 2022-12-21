using PdfiumSharp.Internal.Types;
using System.Runtime.InteropServices;

namespace PdfiumSharp.Internal.Imports
{
    internal static class FPDF_Edit
    {
        /// <summary>
        /// Create a new PDF document.
        /// </summary>
        /// <returns>Returns a handle to a new document, or NULL on failure.</returns>
        [DllImport("pdfium.dll")]
        public static extern FPDF_DOCUMENT FPDF_CreateNewDocument();

        /// <summary>
        /// Create a new PDF page.
        /// </summary>
        /// <param name="document">Handle to document.</param>
        /// <param name="page_index">Suggested 0-based index of the page to create. If it is larger than document's current last index(L), the created page index is the next available index -- L+1.</param>
        /// <param name="width">The page width in points.</param>
        /// <param name="height">The page height in points.</param>
        /// <returns>Returns the handle to the new page or NULL on failure.</returns>
        [DllImport("pdfium.dll")]
        public static extern FPDF_PAGE FPDFPage_New(FPDF_DOCUMENT document, int page_index, double width, double height);

        /// <summary>
        /// Delete the page at <paramref name="page_index"/>.
        /// </summary>
        /// <param name="document">Handle to document.</param>
        /// <param name="page_index">The index of the page to delete.</param>
        [DllImport("pdfium.dll")]
        public static extern void FPDFPage_Delete(FPDF_DOCUMENT document, int page_index);

        /// <summary>
        /// Get the rotation of <paramref name="page"/>.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <returns>
        /// 0 - No rotation.<br/>
        /// 1 - Rotated 90 degrees clockwise.<br/>
        /// 2 - Rotated 180 degrees clockwise.<br/>
        /// 3 - Rotated 270 degrees clockwise.
        /// </returns>
        [DllImport("pdfium.dll")]
        public static extern int FPDFPage_GetRotation(FPDF_PAGE page);

        /// <summary>
        /// Set rotation for <paramref name="page"/>.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <param name="rotate">
        /// The rotation value, one of:<br/>
        /// 0 - No rotation.<br/>
        /// 1 - Rotated 90 degrees clockwise.<br/>
        /// 2 - Rotated 180 degrees clockwise.<br/>
        /// 3 - Rotated 270 degrees clockwise.
        /// </param>
        [DllImport("pdfium.dll")]
        public static extern void FPDFPage_SetRotation(FPDF_PAGE page, int rotate);

        /// <summary>
        /// Insert <paramref name="page_obj"/> into <paramref name="page"/>.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <param name="page_obj">Handle to a page object. The <paramref name="page_obj"/> will be automatically freed.</param>
        [DllImport("pdfium.dll")]
        public static extern void FPDFPage_InsertObject(FPDF_PAGE page, FPDF_PAGEOBJECT page_obj);

        /// <summary>
        /// Remove <paramref name="page_obj"/> from <paramref name="page"/>.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <param name="page_obj">Handle to a page object to be removed.</param>
        /// <returns>Returns TRUE on success.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFPage_RemoveObject(FPDF_PAGE page, FPDF_PAGEOBJECT page_obj);

        /// <summary>
        /// Get number of page objects inside <paramref name="page"/>.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <returns>Returns the number of objects in <paramref name="page"/>.</returns>
        [DllImport("pdfium.dll")]
        public static extern int FPDFPage_CountObjects(FPDF_PAGE page);

        /// <summary>
        /// Get object in <paramref name="page"/> at <paramref name="index"/>.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <param name="index">The index of a page object.</param>
        /// <returns>Returns the handle to the page object, or NULL on failed.</returns>
        [DllImport("pdfium.dll")]
        public static extern FPDF_PAGEOBJECT FPDFPage_GetObject(FPDF_PAGE page, int index);

        /// <summary>
        /// Checks if <paramref name="page"/> contains transparency.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <returns>Returns TRUE if <paramref name="page"/> contains transparency.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFPage_HasTransparency(FPDF_PAGE page);

        /// <summary>
        /// Generate the content of <paramref name="page"/>.
        /// Before you save the page to a file, or reload the page, you must call FPDFPage_GenerateContent or any changes to <paramref name="page"/> will be lost.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <returns>Returns TRUE on success.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFPage_GenerateContent(FPDF_PAGE page);

        /// <summary>
        /// Destroy <paramref name="page_obj"/> by releasing its resources. <paramref name="page_obj"/> must have been created by FPDFPageObj_CreateNew{Path|Rect}() or FPDFPageObj_New{Text|Image}Obj(). This function must be called on newly-created objects if they are not added to a page through FPDFPage_InsertObject() or to an annotation through FPDFAnnot_AppendObject().
        /// </summary>
        /// <param name="page_obj">Handle to a page object.</param>
        [DllImport("pdfium.dll")]
        public static extern void FPDFPageObj_Destroy(FPDF_PAGEOBJECT page_obj);

        /// <summary>
        /// Checks if <paramref name="page_object"/> contains transparency.
        /// </summary>
        /// <param name="page_object">Handle to a page object.</param>
        /// <returns>Returns TRUE if <paramref name="page_object"/> contains transparency.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFPageObj_HasTransparency(FPDF_PAGEOBJECT page_object);

        /// <summary>
        /// Get type of <paramref name="page_object"/>.
        /// </summary>
        /// <param name="page_object">Handle to a page object.</param>
        /// <returns>Returns one of the FPDF_PAGEOBJ_* values on success, FPDF_PAGEOBJ_UNKNOWN on error.</returns>
        [DllImport("pdfium.dll")]
        public static extern int FPDFPageObj_GetType(FPDF_PAGEOBJECT page_object);

        /// <summary>
        /// Transform <paramref name="page_object"/> by the given matrix.<br/>
        /// The matrix is composed as:<br/>
        /// |a c e|<br/>
        /// |b d f|<br/>
        /// and can be used to scale, rotate, shear and translate the <paramref name="page_object"/>.
        /// </summary>
        /// <param name="page_object">Handle to a page object.</param>
        /// <param name="a">Matrix value.</param>
        /// <param name="b">Matrix value.</param>
        /// <param name="c">Matrix value.</param>
        /// <param name="d">Matrix value.</param>
        /// <param name="e">Matrix value.</param>
        /// <param name="f">Matrix value.</param>
        [DllImport("pdfium.dll")]
        public static extern void FPDFPageObj_Transform(FPDF_PAGEOBJECT page_object, double a, double b, double c, double d, double e, double f);

        /// <summary>
        /// Get the transform matrix of a page object.<br/>
        /// The matrix is composed as:<br/>
        /// |a c e|<br/>
        /// |b d f|<br/>
        /// and can be used to scale, rotate, shear and translate the <paramref name="page_object"/>.
        /// </summary>
        /// <param name="page_object">Handle to a page object.</param>
        /// <param name="matrix">Pointer to struct to receive the matrix value.</param>
        /// <returns>Returns TRUE on success.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFPageObj_GetMatrix(FPDF_PAGEOBJECT page_object, out FS_MATRIX matrix);

        /// <summary>
        /// Set the transform matrix of a page object.<br/>
        /// The matrix is composed as:<br/>
        /// |a c e|<br/>
        /// |b d f|<br/>
        /// and can be used to scale, rotate, shear and translate the <paramref name="page_object"/>.
        /// </summary>
        /// <param name="page_object">Handle to a page object.</param>
        /// <param name="matrix">Pointer to struct to receive the matrix value.</param>
        /// <returns>Returns TRUE on success.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFPageObj_SetMatrix(FPDF_PAGEOBJECT page_object, out FS_MATRIX matrix);

        /// <summary>
        /// Transform all annotations in <paramref name="page"/>.<br/>
        /// The matrix is composed as:<br/>
        /// |a c e|<br/>
        /// |b d f|<br/>
        /// and can be used to scale, rotate, shear and translate the <paramref name="page"/> annotations.
        /// </summary>
        /// <param name="page">Handle to a page.</param>
        /// <param name="a">Matrix value.</param>
        /// <param name="b">Matrix value.</param>
        /// <param name="c">Matrix value.</param>
        /// <param name="d">Matrix value.</param>
        /// <param name="e">Matrix value.</param>
        /// <param name="f">Matrix value.</param>
        [DllImport("pdfium.dll")]
        public static extern void FPDFPage_TransformAnnots(FPDF_PAGE page, double a, double b, double c, double d, double e, double f);

        /// <summary>
        /// Create a new text object using one of the standard PDF fonts.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="font">String containing the font name, without spaces.</param>
        /// <param name="font_size">The font size for the new text object.</param>
        /// <returns>Returns a handle to a new text object, or NULL on failure.</returns>
        [DllImport("pdfium.dll")]
        public static extern FPDF_PAGEOBJECT FPDFPageObj_NewTextObj(FPDF_DOCUMENT document, string font, float font_size);

        /// <summary>
        /// Set the text for a text object. If it had text, it will be replaced.
        /// </summary>
        /// <param name="text_object">Hndle to the text object.</param>
        /// <param name="text">The UTF-16LE encoded string containing the text to be added.</param>
        /// <returns>Returns TRUE on success.</returns>
        [DllImport("pdfium.dll")]
        public static extern bool FPDFText_SetText(FPDF_PAGEOBJECT text_object, string text);

        /// <summary>
        /// Get the text of a text object.
        /// </summary>
        /// <param name="text_object">The handle to the text object.</param>
        /// <param name="text_page">The handle to the text page.</param>
        /// <param name="buffer">The address of a buffer that receives the text.</param>
        /// <param name="length">The size, in bytes, of <paramref name="buffer"/>.</param>
        /// <returns>Returns the number of bytes in the text (including the trailing NUL character) on success, 0 on error.</returns>
        [DllImport("pdfium.dll")]
        public static extern int FPDFTextObj_GetText(FPDF_PAGEOBJECT text_object, FPDF_TEXTPAGE text_page, ref byte buffer, long length);
    }
}
