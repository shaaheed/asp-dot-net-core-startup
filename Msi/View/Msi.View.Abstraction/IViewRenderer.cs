using Msi.Service;
using System.Threading.Tasks;

namespace Msi.View.Abstraction
{
    public interface IViewRenderer : ITransientService
    {
        Task<string> RenderAsync<TModel>(string viewName, TModel model);
    }
}
