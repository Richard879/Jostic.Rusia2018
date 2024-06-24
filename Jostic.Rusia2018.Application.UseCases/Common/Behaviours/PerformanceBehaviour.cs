using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace Jostic.Rusia2018.Application.UseCases.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();
            var elapsedMiliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMiliseconds > 10)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning("Clean Architecture Long Running Request: {name} ( { elapsedMiliseconds } milliseconds) { @request }",
                    requestName,
                    elapsedMiliseconds,
                    JsonSerializer.Serialize(request));
            }

            return response;
        }
    }
}