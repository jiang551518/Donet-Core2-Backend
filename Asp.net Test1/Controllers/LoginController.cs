using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.net_Test1
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        protected ITestService _testService { get; set; }

        protected IMapper _mapper { get; set; }

        protected IConfiguration _configuration { get; }
        public LoginController(ITestService testService, IConfiguration configuration, IMapper mapper)
        {
            _testService = testService;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<LoginVM> Login([FromBody] LoginInputVM input)
        {
            var result = new LoginVM();
            var userDetail = await _testService.GetUserDetail(input.Username);
            if (userDetail != null)
            {
                if (userDetail.Pwd != input.Pwd) { throw new Exception("密码错误!"); };
                if (userDetail.Enabled == false) { throw new Exception("用户已禁用!"); };
                if (userDetail.IsDeleted == true) { throw new Exception("用户已删除!"); };
                result = new LoginVM() 
                {
                    Username = userDetail.Username,
                    Realname = userDetail.Realname,
                    Id = userDetail.Id ,
                    Enabled = userDetail.Enabled,
                    Creationtime = userDetail.Creationtime,
                    RoleTypeStr = GetEnumDescription<RoleType>(userDetail.RoleType),
                    RoleType = userDetail.RoleType,
                    LoginNowTime = userDetail.LoginNowTime.ToString("yyyy-MM-dd"),
                    ExcelPasswd = userDetail.ExcelPasswd
                };
                result.JwtToken = await CreateJwtAndSaveCache(result);

                await _testService.UpdateLoginNowTime(userDetail.Id);
            }
            else
            {
                throw new Exception("该用户不存在");
            }
            return result;
        }

        

        #region Jwt Token
        private async Task<string> CreateJwtAndSaveCache(LoginVM vm)
        {
            var invalidTime = DateTime.Now.Add(TimeSpan.FromDays(7));
            var invalidTimeTicks = invalidTime.Ticks;
            //生成JWT Token
            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub,"test"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sid, vm.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, invalidTimeTicks.ToString(), ClaimValueTypes.Integer64)

            };

            var jwt = new JwtSecurityToken(
                        claims: claims,
                        expires: invalidTime
                    );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var identity = new ClaimsIdentity(claims, "msls");
            //将用户数据放入Identity
            User.AddIdentity(identity);
            var redisClient = new FreeRedis.RedisClient("127.0.0.1:6379"); // 根据你的配置修改连接地址
            await redisClient.SetAsync("user_" + vm.Id.ToString(), JsonExtensions.SerializeToJson(vm));
            return encodedJwt;
        }
        #endregion


        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [HttpPost("Sign")]
        public async Task<bool> Sign([FromBody] SignVM vm)
        {
            var input = _mapper.Map<User>(vm);
            var isSuccess = await _testService.Sign(input);
            return isSuccess;
        }


        private string GetEnumDescription<T>(T? enumValue) where T : struct, Enum
        {
            // 处理空值情况
            if (!enumValue.HasValue)
            {
                return string.Empty;
            }

            // 获取枚举类型
            Type enumType = typeof(T);

            // 获取枚举成员名称
            string enumName = Enum.GetName(enumType, enumValue.Value);
            if (enumName == null)
            {
                return string.Empty;
            }

            // 获取Description特性
            FieldInfo fieldInfo = enumType.GetField(enumName);
            if (fieldInfo == null)
            {
                return string.Empty;
            }

            DescriptionAttribute descAttr = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return descAttr?.Description ?? string.Empty;
        }

    }
}
