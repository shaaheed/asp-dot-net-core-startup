using System.Collections.Generic;
using System.Threading.Tasks;

namespace Msi.Email
{
    public interface IEmailClient
    {
        Task SendAsync(string to, string subject, string message, bool isHtml = true);

        Task SendAsync(IEnumerable<string> tos, string subject, string message, bool isHtml = true);
    }
}
