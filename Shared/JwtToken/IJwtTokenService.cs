using Grpc.Core;

namespace DogtrekkingCzShared.Services.JwtToken
{
    public interface IJwtTokenService
    {
        public void Parse(ServerCallContext context);

        public string GetUserId();
    }
}
