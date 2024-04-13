using API.GRPCService.Services.JwtToken;
using Grpc.Core.Interceptors;
using Grpc.Core;

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
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            _jwtTokenService.Parse(context);

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
    }
}
