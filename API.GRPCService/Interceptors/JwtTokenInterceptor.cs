using Grpc.Core.Interceptors;
using Grpc.Core;
using PetsOnTrail.Interfaces.Actions.Entities.JwtToken;
using Microsoft.AspNetCore.Mvc.RazorPages;
using API.GRPCService.Extensions;

namespace API.GRPCService.Interceptors
{
    public class JwtTokenInterceptor : Interceptor
    {
        private readonly ILogger _logger;
        private readonly IJwtTokenService _jwtTokenService;

        public JwtTokenInterceptor(ILogger<JwtTokenInterceptor> logger, IJwtTokenService jwtTokenService) 
        { 
            _logger = logger;
            _jwtTokenService = jwtTokenService;

            _logger.LogInformation($"{nameof(JwtTokenInterceptor)}: created");
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            _logger.LogInformation($"{nameof(JwtTokenInterceptor)}: running unary server handler with request: '{request}'/context headers: '{context.RequestHeaders.Dump()}'");

            var tokenSource = context.RequestHeaders.Get("authorization");
            if (tokenSource is not null)
            { 
                var token = tokenSource?.Value ?? string.Empty;

                await _jwtTokenService.Parse(token, context.CancellationToken);
            }

            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(JwtTokenInterceptor)}: error while trying to run continuation with accepted request: '{request}'/context: '{context}'");
                throw;
            }
        }

        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context, AsyncClientStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            _logger.LogInformation($"{nameof(JwtTokenInterceptor)}: running async client streaming call with context: '{context}'");

            var tokenSource = context.Options.Headers?.Get("authorization");
            if (tokenSource is not null)
            {
                var token = tokenSource?.Value ?? string.Empty;

                _jwtTokenService.Parse(token, CancellationToken.None);
            }

            return base.AsyncClientStreamingCall(context, continuation);
        }
    }
}
