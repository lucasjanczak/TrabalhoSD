using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Client.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Web.Controllers
{
    public class GoogleOAuthController : Controller
    {
        [HttpGet("~/api/oauth/google/callback"), HttpPost("~/api/oauth/google/callback"), IgnoreAntiforgeryToken]
        public async Task<IActionResult> LogInCallback()
        {
            var result = await HttpContext.AuthenticateAsync(OpenIddictClientAspNetCoreDefaults.AuthenticationScheme);

            if (result.Principal is not ClaimsPrincipal { Identity.IsAuthenticated: true })
            {
                throw new InvalidOperationException("The external authorization data cannot be used for authentication.");
            }

            var identity = new ClaimsIdentity(authenticationType: "ExternalLogin");

            identity.SetClaim(ClaimTypes.Email, result.Principal.GetClaim(ClaimTypes.Email))
                .SetClaim(ClaimTypes.Name, result.Principal.GetClaim(ClaimTypes.Name))
                .SetClaim(ClaimTypes.NameIdentifier, result.Principal.GetClaim(ClaimTypes.NameIdentifier));

            identity.SetClaim(Claims.Private.RegistrationId, result.Principal.GetClaim(Claims.Private.RegistrationId));

            var properties = new AuthenticationProperties(result.Properties.Items)
            {
                RedirectUri = result.Properties.RedirectUri ?? "/"
            };

            properties.StoreTokens(result.Properties.GetTokens().Where(token => token.Name is
                OpenIddictClientAspNetCoreConstants.Tokens.BackchannelAccessToken or
                OpenIddictClientAspNetCoreConstants.Tokens.BackchannelIdentityToken or
                OpenIddictClientAspNetCoreConstants.Tokens.RefreshToken));

            return SignIn(new ClaimsPrincipal(identity), properties);
        }
    }
}
