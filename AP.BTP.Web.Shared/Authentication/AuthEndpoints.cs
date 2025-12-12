using AP.BTP.Contracts.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AP.BTP.Web.Shared.Authentication
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app, IConfiguration config)
        {
            app.MapGet("/auth/login-callback", async (HttpContext context, [FromServices] IMemoryCache cache) =>
            {
                string key = context.Request.Query["key"].ToString();
                if (string.IsNullOrEmpty(key) || !cache.TryGetValue<LoginResponseDto>(key, out LoginResponseDto? LoginResponse))
                {
                    return Results.BadRequest("Invalid or expired key.");
                }

                cache.Remove(key);

                if (LoginResponse == null)
                {
                    return Results.Unauthorized();
                }

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                string authority = $"https://{config["AUTH0:DOMAIN"]}/";
                string? audience = config["AUTH0:CLIENT_ID"];

                ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"{authority}.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever()
                );

                OpenIdConnectConfiguration openIdConfig = await configManager.GetConfigurationAsync(CancellationToken.None);

                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authority,
                    ValidAudience = audience,
                    IssuerSigningKeys = openIdConfig.SigningKeys,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };

                try
                {
                    ClaimsPrincipal principal = handler.ValidateToken(LoginResponse.id_token, validationParameters, out _);

                    List<Claim> claims = principal.Claims.Select(c =>
                    {
                        if (c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                        {
                            return c.Value.Split(',').Select(r => new Claim(ClaimTypes.Role, r.Trim()));
                        }
                        return [new Claim(c.Type, c.Value)];
                    }).SelectMany(c => c).ToList();

                    claims.Add(new Claim("access_token", LoginResponse.access_token));
                    claims.Add(new Claim("id_token", LoginResponse.id_token));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, LoginResponse.UserId.ToString()));
                    claims.Add(new Claim(ClaimTypes.GivenName, LoginResponse.FirstName));
                    claims.Add(new Claim(ClaimTypes.Surname, LoginResponse.LastName));
                    claims.Add(new Claim(ClaimTypes.MobilePhone, LoginResponse.PhoneNumber));
                    claims.Add(new Claim(ClaimTypes.Email, LoginResponse.Email));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal cookiePrincipal = new ClaimsPrincipal(identity);

                    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cookiePrincipal);

                    return Results.Redirect("/");
                }
                catch (SecurityTokenValidationException)
                {
                    return Results.Unauthorized();
                }
            });


            app.MapGet("/logout", async (HttpContext context) =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                context.Response.Cookies.Delete(".AspNetCore.Cookies");
                return Results.Redirect("/");
            });
        }
    }
}
