using aspnetcore.ntier.BLL.Services;
using aspnetcore.ntier.BLL.Services.Apis;
using aspnetcore.ntier.BLL.Services.Dashboard;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.Log;
using aspnetcore.ntier.BLL.Utilities.AutoMapperProfiles;
using aspnetcore.ntier.BLL.Utilities.Filters;
using aspnetcore.ntier.BLL.Utilities.ModelStateValidation;
using aspnetcore.ntier.BLL.Utilities.Swagger;
using aspnetcore.ntier.BLL.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace aspnetcore.ntier.BLL;

public static class DependencyInjection
{
    public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IWeightService, WeightService>();
        services.AddScoped<ITruckService, TruckService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserTblService, UserTblService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<INationService, NationService>();
        services.AddScoped<ISiteService, SiteService>();
        services.AddScoped<IPictureService, PictureService>();
        services.AddScoped<IWeightClassTblService, WeightClassTblService>();
        services.AddScoped<IDashboardUserService, DashboardUserService>();
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<ModelStateValidation>();
        services.AddScoped<ILogRequestsService, LogRequestService>();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<UserToLoginDTOValidator>();
        services.AddValidatorsFromAssemblyContaining<UserToRegisterDTOValidator>();

        #region Versioning

        services.AddApiVersioning(opt =>
        {
            opt.ReportApiVersions = true;
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ApiVersionReader = new UrlSegmentApiVersionReader();
            opt.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        #endregion

        #region Swagger

        services.AddSwaggerGen(options =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Paste your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });

            options.SchemaFilter<TimeOnlySchemaFilter>();
        });

        services.ConfigureOptions<SwaggerConfigurationOptions>();

        #endregion
    }
}