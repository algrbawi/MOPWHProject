using aspnetcore.ntier.BLL;
using aspnetcore.ntier.BLL.Utilities.AutoMapperProfiles;
using aspnetcore.ntier.BLL.Utilities.Settings;
using aspnetcore.ntier.DAL;
using aspnetcore.ntier.Dashboard.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;
namespace aspnetcore.ntier.Dashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRateLimiter(_ => _
                                                .AddFixedWindowLimiter(policyName: "RateLimit", options =>
                                                {
                                                    options.PermitLimit = 10;
                                                    options.Window = TimeSpan.FromSeconds(120);
                                                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                                                    options.QueueLimit = 0;
                                                }).OnRejected = async (context, cancelationToken) =>
                                                {
                                                    context.HttpContext.Response.Redirect("/RateLimit", false);
                                                });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    //options.AccessDeniedPath = "/Forbidden/";
                    options.LoginPath = "/account/login";
                    options.AccessDeniedPath = "/account/logout";
                }
                ).AddJwtBearer(options =>
                {
                    var jwtSettings = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.AccessTokenSecret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }); ;
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
            builder.Services.RegisterDALDependencies(builder.Configuration);
            builder.Services.RegisterBLLDependencies(builder.Configuration);
            //Disable Filter in ApiControler Filter
            builder.Services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddScoped<ExceptionFilter>();
            builder.Services.AddScoped<DashboardExceptionFilter>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseRateLimiter();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();

                string body = string.Empty;

                if (context.Request.ContentLength > 0)
                {
                    context.Request.Body.Position = 0;

                    using var reader = new StreamReader(
                        context.Request.Body,
                        Encoding.UTF8,
                        leaveOpen: true);

                    body = await reader.ReadToEndAsync();

                    context.Request.Body.Position = 0;
                }

                // Store for later use
                context.Items["RequestBody"] = body;

                await next();
            });
            app.Use(async (context, next) =>
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    try
                    {
                        var trackUserAction = context.GetEndpoint();
                        if (trackUserAction is not null && trackUserAction.Metadata.GetMetadata<aspnetcore.ntier.Dashboard.Attributes.TrackUser>() is not null)
                        {

                        }

                    }
                    catch (Exception)
                    {
                    }

                }

                await next();
            });

            app.UseSwagger();
            if (!app.Environment.IsProduction())
            {
                app.UseSwaggerUI(c =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToString());
                    }
                });
            }

            app.Run();
        }
    }
}
