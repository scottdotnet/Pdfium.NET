namespace Pdfium.NET.Internal
{
    public interface IHandle<T>
    {
        bool IsNull { get; }

        T SetToNull();
    }
}
