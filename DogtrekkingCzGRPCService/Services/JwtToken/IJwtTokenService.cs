using Grpc.Core;

namespace DogtrekkingCzGRPCService.Services.JwtToken
{
    public interface IJwtTokenService
    {
        public void Parse(ServerCallContext context);

        public string GetUserId();
    }
}
