﻿using Msi.Service;
using System.Threading.Tasks;

namespace Msi.View.Abstraction
{
    public interface IViewRenderer : IScopedService
    {
        Task<string> RenderAsync<TModel>(string viewName, TModel model);
    }
}
