using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.Services
{
    public class AuthenticationHelper
    {
        public static string TokenForUser = null;
        public static DateTimeOffset expiration;

        private static GraphServiceClient graphClient = null;

        public  static GraphServiceClient GetAuthenticationClient()
        {
            if (graphClient == null)
            {
                try
                {
                    graphClient = new GraphServiceClient(
                         "https://graph.microsoft.com/v1.0",
                         new DelegateAuthenticationProvider(
                             async (requestMessage) =>
                             {
                                 var token = await GetTokenForUserAsync();
                                 requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                                
                             }));

                    return graphClient;
                }
                catch(Exception ex)
                {

                }

            }

            return graphClient;
        }

        private async static Task<string> GetTokenForUserAsync()
        {
            if (TokenForUser == null || expiration <= DateTimeOffset.UtcNow.AddMinutes(5))
            {
                AuthenticationResult authResult = await App.PCA.AcquireTokenAsync(App.Scopes, App.UiPartent);

                TokenForUser = authResult.AccessToken;
                expiration = authResult.ExpiresOn;
            }

            return TokenForUser;
        }

        public static void SignOut()
        {
            foreach (var user in App.PCA.Users)
            {
                App.PCA.Remove(user);
            }
            graphClient = null;
            TokenForUser = null;

        }
    }
}
