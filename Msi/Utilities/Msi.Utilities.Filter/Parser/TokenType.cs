namespace Msi.Utilities.Filter
{
    public enum TokenType : byte
    {
        Word = 1,
        LeftParentheses = 2,
        RightParentheses = 3,
        Space = 4,
        SingleQuote = 5,
        DoubleQuote = 6,
        Eof = 7,
    }
}
