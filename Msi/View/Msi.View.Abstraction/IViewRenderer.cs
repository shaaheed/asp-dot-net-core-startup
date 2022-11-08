using Msi.Service.Abstractions;

namespace Msi.View.Abstraction
{
    public interface IViewRenderer : IScopedService
    {
        Task<string> RenderAsync<TModel>(string viewName, TModel model);
    }
}
