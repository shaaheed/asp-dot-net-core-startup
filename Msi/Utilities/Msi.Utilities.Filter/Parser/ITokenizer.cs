namespace Msi.Utilities.Filter
{
    public interface ITokenizer
    {
        void Reset();
        Token GetNextToken(string text);
    }
}
