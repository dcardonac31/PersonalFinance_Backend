using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PersonalFinance.Common.ApplicationInsights.Configuration;
using PersonalFinance.Common.ApplicationInsights.Dtos;
using PersonalFinance.Common.Configuration;
using PersonalFinance.Common.Dtos;


using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mime;

namespace PersonalFinance.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public sealed class ExceptionFilter : IExceptionFilter
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger, IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnException(ExceptionContext context)
        {
            var message = JsonConvert.SerializeObject(MessageError(context.Exception), Formatting.Indented);
            var objResponseService = new ResponseService<string>
            {
                Status = false,
                Message = HttpStatusCode.InternalServerError.ToString(),
                Data = message
            };

            var options = _configuration.GetOptions<AppSettingInfo>(CommonConfiguration.AppInsName);
            if (options.Enabled)
            {
                _logger.LogError(context.Exception, message);
            }

            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(objResponseService, Formatting.Indented));
        }

        private static List<ResponseException> MessageError(Exception ex, int level = 30)
        {
            var listError = new List<ResponseException>();
            var counter = 1;
            while (ex != null && counter <= level)
            {
                listError.Add(new ResponseException
                {
                    ErrorLevel = counter.ToString(),
                    ErrorMessage = ex.Message,
                    ErrorSource = ex.Source,
                    ErrorStackTrace = ex.StackTrace,
                    ErrorTargetSite = ex.TargetSite?.ToString(),
                    ErrorData = ex.Data
                });
                ex = ex.InnerException;
                counter++;
            }
            return listError;
        }
    }
}
