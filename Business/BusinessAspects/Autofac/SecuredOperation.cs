using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var header = _httpContextAccessor.HttpContext.Request.Headers;

            // Bearer token'ı al
            var bearerToken = header["Authorization"].ToString().Replace("Bearer ", "");

            // Token'ı çöz
            var decodedToken = DecodeToken(bearerToken);

            // İçeriği konsola yazdır
            Console.WriteLine(decodedToken);
            // JSON verisini iki ayrı parçaya bölelim
            int separatorIndex = decodedToken.IndexOf("}.");
            string headerJson = decodedToken.Substring(0, separatorIndex + 1);
            string payloadJson = decodedToken.Substring(separatorIndex + 2);

            // Role alanını çıkaralım
            var payloadJsonElement = JsonSerializer.Deserialize<JsonElement>(payloadJson);
            var roleClaim = payloadJsonElement.GetProperty("http://schemas.microsoft.com/ws/2008/06/identity/claims/role").ToString();
            // JSON verisini işle
            

         
            foreach (var role in _roles)
            {
                if (roleClaim.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }

        public static string DecodeToken(string encodedToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(encodedToken);

            return token.ToString();
        }
    }
}
