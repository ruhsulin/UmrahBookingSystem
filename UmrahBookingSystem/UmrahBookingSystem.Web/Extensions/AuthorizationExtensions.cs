using Microsoft.AspNetCore.Authorization;
using UmrahBookingSystem.Domain.Constants;

namespace UmrahBookingSystem.Web.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddWebAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy(AuthorizationPolicies.AdminOnly, p => p.RequireRole(Roles.Admin))
                .AddPolicy(AuthorizationPolicies.ClientOnly, p => p.RequireRole(Roles.Client))
                .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build());

            return services;
        }
    }
}