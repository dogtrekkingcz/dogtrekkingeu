using Grpc.Core.Interceptors;
using Grpc.Core;
using static Grpc.Core.Interceptors.Interceptor;
using DogtrekkingCzShared.Services.JwtToken;

namespace DogtrekkingCzShared.Interceptors
{
    public class JwtTokenInterceptor : Interceptor
    {
        private readonly IJwtTokenService _jwtTokenService;

        public JwtTokenInterceptor(IJwtTokenService jwtTokenService) 
        { 
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
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
