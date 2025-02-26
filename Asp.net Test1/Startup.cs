using AutoMapper;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.Dashboard;
using Hangfire.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace Asp.net_Test1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestRepository, TestRepository>();

            services.AddHttpClient();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test测试Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "请输入OAuth接口返回的Token，前置Bearer。示例：Bearer {Roken}",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Asp.net Test1.xml"), true);
            });

            var config = new MapperConfiguration(e =>
            {
                e.AddProfile<ViewModelAutoMapper>();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHangfire(x =>
            {
                x.UseRedisStorage(Configuration["HangfireConfig:RedisConnectionString"], new RedisStorageOptions
                {
                    Prefix = Configuration["HangfireConfig:RedisPrefix"],
                    Db = Configuration.GetValue<int>("HangfireConfig:RedisDB")
                });
            });

            services.AddHangfireServer(x => x.WorkerCount = Configuration.GetValue<int>("HangfireConfig:WorkerCount"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Test测试Api");
                });
            }


            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new CustomAuthorizeFilter() }
            });

            var localTime = TZConvert.GetTimeZoneInfo("Asia/Shanghai");
            //RecurringJob.AddOrUpdate<ITestService>(x => x.GetList(), "*/2 * * * * ", localTime);

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin(); //允许任何源访问
                builder.AllowAnyHeader(); //允许任何请求头
                builder.AllowAnyHeader(); //允许任何HTTP方法
                builder.AllowCredentials(); //允许发送凭证（如cookies）
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
        {
            public bool Authorize([NotNull] DashboardContext context)
            {
                return true;
            }
        }
    }
}
