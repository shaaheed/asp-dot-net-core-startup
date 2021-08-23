namespace Msi.Utilities.Filter
{
    public class Token
    {
        public int Position { get; }
        public string Value { get; }
        public TokenType Type { get; }

        public Token(int position, TokenType type, string value = default)
        {
            Position = position;
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            int length = Value == null ? 0 : Value.Length;
            return $"Position: {Position}, Type: {Type.ToString()}, Value: {Value}, Length: {length}";
        }
    }
}
