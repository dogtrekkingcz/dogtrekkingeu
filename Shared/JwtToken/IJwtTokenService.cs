using Grpc.Core;

namespace DogtrekkingCzShared.JwtToken
{
    public interface IJwtTokenService
    {
        public void Parse(ServerCallContext context);

        public string GetUserId();
    }
}
