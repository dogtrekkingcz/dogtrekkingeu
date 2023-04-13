using System.IdentityModel.Tokens.Jwt;
using Grpc.Core;

namespace DogtrekkingCzShared.JwtToken
{
    public class JwtTokenService : IJwtTokenService
    {
        private string _userId = "";

        public void Parse(ServerCallContext context)
        {
            var token = context.RequestHeaders.Get("authorization")?.Value;
            if (token == null)
            {
                return;
            }

            var handler = new JwtSecurityTokenHandler();

            if (token.Contains("Bearer "))
                token = token.Substring(7);

            if (handler.CanReadToken(token))
            {
                var jsonToken = handler.ReadToken(token);
                if (jsonToken != null)
                { 
                    var securityToken = jsonToken as JwtSecurityToken;
                    _userId = securityToken?.Claims?.FirstOrDefault(c => c.Type == "oid")?.Value ?? "";
                }
            }
        }

        public string GetUserId()
        {
            return _userId;
        }
    }
}
