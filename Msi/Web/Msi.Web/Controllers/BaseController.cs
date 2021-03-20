using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Domain.Abstractions;
using Msi.Utilities.Filter;
using System;

namespace Msi.Web
{
    public class BaseController : ControllerBase
    {
        private ICommandBus CommandBus => HttpContext?.RequestServices?.GetService<ICommandBus>();
        private IQueryBus QueryBus => HttpContext?.RequestServices?.GetService<IQueryBus>();
        //protected readonly ICacheService _cacheService;

        public BaseController()
        {
            //_cacheService = HttpContext?.RequestServices?.GetService<ICacheService>();
        }

        public virtual async Task<IActionResult> Post<TResponse>(ICommand<TResponse> command)
        {
            var result = await OkAsync(command);
            return result.ToCreatedResult();
        }

        public Task<IActionResult> Put<TResponse>(ICommand<TResponse> command)
        {
            return OkAsync(command);
        }

        public Task<IActionResult> Delete<TResponse>(ICommand<TResponse> command)
        {
            return DeleteAsync(command);
        }

        public Task<IActionResult> Gets<TResponse>(IQuery<TResponse> query)
        {
            return OkAsync(query);
        }

        public Task<IActionResult> Get<TResponse>(IQuery<TResponse> query)
        {
            return OkAsync(query);
        }

        public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            return CommandBus.SendAsync(command, cancellationToken);
        }

        public Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> command, CancellationToken cancellationToken = default)
        {
            return QueryBus.SendAsync(command, cancellationToken);
        }

        public IActionResult Result<T>(PagedCollection<T> pagedCollection, int status = 200, string message = default)
        {
            return new OkObjectResult(pagedCollection.ToResult(status, message));
        }

        public IActionResult Result<T>(T model, int status = 200, string message = default)
        {
            return new OkObjectResult(model.ToResult(status, message));
        }

        public IActionResult Ok<T>(T model, int status = 200, string message = default)
        {
            return Result(model, status, message);
        }

        public async Task<IActionResult> OkAsync<T>(ICommand<T> command, int status = 200, string message = default)
        {
            return Result(await CommandBus.SendAsync(command), status, message);
        }

        public async Task<IActionResult> DeleteAsync<T>(ICommand<T> command, int status = 200, string message = default)
        {
            await CommandBus.SendAsync(command);
            return NoContent();
        }

        public async Task<IActionResult> OkOrUnauthorizeAsync<T>(ICommand<T> command, int status = 200, string message = default)
        {
            var result = await CommandBus.SendAsync(command);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> OkAsync<T>(IQuery<T> command, int status = 200, string message = default)
        {
            return Ok(await QueryBus.SendAsync(command), status, message);
        }

        public async Task<IActionResult> OkAsync<T>(IQuery<T> query, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, int status = 200, string message = default)
        {
            return Ok(await QueryBus.SendAsync(query, pagingOptions, searchOptions), status, message);
        }

        public async Task<IActionResult> Ok<T>(IQuery<PagedCollection<T>> query, int status = 200, string message = default)
        {
            return Ok(await QueryBus.SendAsync(query), status, message);
        }

        public IActionResult Ok<T>(PagedCollection<T> pagedCollection, int status = 200, string message = default)
        {
            return Result(pagedCollection, status, message);
        }

        public IActionResult Created<T>(T value, string location = "", int status = 201, string message = default)
        {
            return new CreatedResult(location, value.ToResult(status, message));
        }

        //public IActionResult FileResult(byte[] bytes, string contentType, string filename)
        //{
        //    if (bytes != null && bytes.Length > 0)
        //    {
        //        string contetntType = contentType;
        //        HttpContext.Response.ContentType = contetntType;
        //        var fileResult = new FileContentResult(bytes, contetntType);
        //        fileResult.FileDownloadName = filename;
        //        return fileResult;
        //    }
        //    return new NoContentResult();
        //}

        //public IActionResult Csv(byte[] bytes, string filename = "")
        //{
        //    return bytes.ToFileResult(HttpContext, @"text/csv", filename);
        //}


    }
}
