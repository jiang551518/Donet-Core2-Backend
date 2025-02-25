using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Asp.net_Test1
{
    public class BaseController : Controller
    {

        protected IConfiguration _configuration { get; }

        protected User user { get; private set; } = null;

        public BaseController( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var traceId = HttpContext.TraceIdentifier;
            var path = HttpContext.Request.Path.Value;

            string userId = null;
            string psd = null;
            string cacheValue = null;
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            var bodyParam = descriptor.Parameters.FirstOrDefault(a => a.BindingInfo?.BindingSource == BindingSource.Body);

            object requestBody = null;

            if (bodyParam != null && context.ActionArguments.ContainsKey(bodyParam.Name))
                requestBody = context.ActionArguments.First(a => a.Key == bodyParam.Name).Value;

            var queryString = HttpContext.Request.QueryString.Value; 

            if (!string.IsNullOrWhiteSpace(queryString)) queryString = HttpUtility.UrlDecode(queryString.TrimStart('?'));


            var tokenHeader = HttpContext.Request.Headers["Authorization"];
            var strToken = tokenHeader.ToString();
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(strToken.Remove(0, 7)); //去除"Bearer "
            var identity = new ClaimsIdentity(jwtToken.Claims);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.User = principal;

            userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sid)?.Value;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                var redisClient = new FreeRedis.RedisClient("127.0.0.1:6379"); 
                cacheValue =  redisClient.Get("user_" + userId); 

                try
                {
                    user = JsonExtensions.DeserializeFromJson<User>(cacheValue);
                }
                catch (Exception ex)
                {
                    throw new Exception("用户未登录");

                }
            }
            if (user == null)
            {
                throw new Exception("用户未登录");
            }
            if (user.Enabled == false)
            {
                throw new Exception("用户已禁用");
            }
            

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}