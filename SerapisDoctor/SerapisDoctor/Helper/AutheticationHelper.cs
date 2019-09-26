using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace SerapisDoctor.Helper
{
    //Will be for calendar providers

    public class AutheticationHelper
    {
        string identifier = "";

        public async Task SignInToOutlookAsync()
        {
            AuthenticationResult authResult = null;

            //IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync();

            try
            {
                //IAccount firstAccount = accounts.FirstOrDefault();
                //authResult = await App.PCA.AcquireTokenSilent(App.Scopes, firstAccount)
                //                        .ExecuteAsync();
                //await RefreshUserDataAsync(authResult.AccessToken).ConfigureAwait(false);
                //Device.BeginInvokeOnMainThread(() => { btnSignInSignOut.Text = "Sign out"; });
            }
            catch (MsalUiRequiredException ex)
            {
                try
                {
                    //authResult = await App.PCA.AcquireTokenInteractive(App.Scopes)
                    //                   .WithParentActivityOrWindow(App.ParentWindow)
                    //                   .ExecuteAsync();
                    //await RefreshUserDataAsync(authResult.AccessToken);
                    //Device.BeginInvokeOnMainThread(() => { btnSignInSignOut.Text = "Sign out"; });
                }
                catch (Exception ex2)
                {

                }
            }
        }
    }
}
