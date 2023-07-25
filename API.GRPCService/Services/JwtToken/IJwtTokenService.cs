using Grpc.Core;

namespace API.GRPCService.Services.JwtToken
{
    public interface IJwtTokenService
    {
        public void Parse(ServerCallContext context);

        public string GetUserId();
    }
}
