namespace Msi.Converter.Abstractions
{
    public interface IConverter<TInput, TOutput>
    {
        TOutput ConvertAsync(TInput content, IConverterOptions options = default);
    }
}
