namespace Msi.Core
{
    public class NotFoundException : BusinessExceptionBase
    {
        public NotFoundException(string message) : base(404, message)
        { 
        }
    }
}
