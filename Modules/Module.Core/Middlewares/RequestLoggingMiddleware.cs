﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Msi.UtilityKit;
using Microsoft.AspNetCore.Hosting;
using Core.Infrastructure.Logs;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Comment
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ResponseMiddleware(
            RequestDelegate next,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostingEnvironment)
        {
            _next = next;
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            Log log = new Log();

            log.Host = context.Request.Host.ToString();
            log.Path = context.Request.Path;
            log.Protocol = context.Request.Protocol;
            log.Method = context.Request.Method;
            log.Query = context.Request.Query.ToJson();
            log.Cookies = context.Request.Cookies.ToJson();
            log.RequestHeaders = context.Request.Headers.ToJson();
            log.ResponseHeaders = context.Response.Headers.ToJson();
            log.RequestBody = await RequestBody(context.Request);
            log.Environment = _hostingEnvironment.EnvironmentName;
            log.Status = context.Response.StatusCode;

            //Copy a pointer to the original response body stream
            var originalBodyStream = context.Response.Body;

            //Create a new memory stream...
            using (var responseBody = new MemoryStream())
            {
                //...and use that for the temporary response body
                context.Response.Body = responseBody;

                //Continue down the Middleware pipeline, eventually returning to this class
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    log.StackTrace = ex.StackTrace;

                    string json = string.Empty;
                    json = "[";
                    while (ex != null)
                    {
                        json += $"\"{ex.Message}\"";
                        ex = ex.InnerException;
                    }
                    json += "]";
                    log.Errors = json;


                }

                //Format the response from the server
                var response = await FormatResponse(context.Response);
                log.ResponseBody = response;

                //Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> RequestBody(HttpRequest request)
        {
            var body = request.Body;

            //This line allows us to set the reader for the request back at the beginning of its stream.
            // request.EnableRewind();

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            //...Then we copy the entire request stream into the new buffer.
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            //We convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            request.Body = body;

            return bodyAsText;
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return text;
        }
    }
}
