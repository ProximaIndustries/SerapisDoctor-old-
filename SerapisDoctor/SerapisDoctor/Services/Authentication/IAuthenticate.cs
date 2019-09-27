using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;

namespace SerapisDoctor.Services.Authentication
{
    public interface IAuthenticate
    {
        void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e);

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e);

        void OnLoginClicked();
    }
}
