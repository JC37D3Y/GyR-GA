using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using GyR.Models;

namespace GyR
{
    public partial class Startup
    {
        // Para obtener más información sobre cómo configurar la autenticación, visite https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configuración del contexto de base de datos y administradores para la autenticación de usuarios
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Configuración de la autenticación mediante cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configuración para autenticación de dos factores
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Proveedores de autenticación externa

            // Microsoft Account
            app.UseMicrosoftAccountAuthentication(
                clientId: "TU_MICROSOFT_CLIENT_ID",
                clientSecret: "TU_MICROSOFT_CLIENT_SECRET");

            // Twitter
            app.UseTwitterAuthentication(
                consumerKey: "TU_TWITTER_CONSUMER_KEY",
                consumerSecret: "TU_TWITTER_CONSUMER_SECRET");

            // Facebook
            app.UseFacebookAuthentication(
                appId: "TU_FACEBOOK_APP_ID",
                appSecret: "TU_FACEBOOK_APP_SECRET");

            // Google
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "TU_GOOGLE_CLIENT_ID",
                ClientSecret = "TU_GOOGLE_CLIENT_SECRET"
            });
        }
    }
}
