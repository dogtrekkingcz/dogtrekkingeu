using Grpc.Core;

namespace SharedCode.JwtToken
{
    public interface IJwtTokenService
    {
        public void Parse(ServerCallContext context);

        public string GetUserId();
    }
}
