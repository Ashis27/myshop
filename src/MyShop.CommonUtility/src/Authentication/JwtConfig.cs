using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.CommonUtility.Authentication
{
    public static class JwtConfig
    {
        private static readonly string _authenticationProviderKey = "IdentityApiKey";
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SecretKey)])), SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SecretKey)])),

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = _authenticationProviderKey;
                options.DefaultChallengeScheme = _authenticationProviderKey;

            }).AddJwtBearer(_authenticationProviderKey, configureOptions =>
            {
                //JWT Authentication
                if (!configuration.GetValue<bool>("IsIDPEnable"))
                {
                    configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                    configureOptions.TokenValidationParameters = tokenValidationParameters;
                    configureOptions.SaveToken = true;
                }
                //OIDC Authentication(Using IDP)
                else
                {
                    configureOptions.Authority = configuration.GetValue<string>("IdentityUrl");
                    if (!configuration.GetValue<bool>("IsApiGatway"))
                    {
                        configureOptions.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                    }
                    else
                    {
                        configureOptions.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidAudiences = new[] { "catalog", "basket" }
                        };
                    }
                }

                configureOptions.RequireHttpsMetadata = false;
                configureOptions.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
        }
    }
}
