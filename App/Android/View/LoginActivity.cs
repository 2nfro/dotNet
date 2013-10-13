using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.Android;
using Nfro.App.Core.View;

namespace Nfro.App.Android.View {
    [Activity(Label = "LoginActivity")]
    public class LoginActivity: BaseActivity, ILoginView {
        private EditText emailTextBox;
        private EditText passwordTextBox;
        private Button loginButton;

        String Nfro.App.Core.View.ILoginView.GetPassword(){
            return emailTextBox.Text ?? "";
        }

        String Nfro.App.Core.View.ILoginView.GetEmailAddress(){
            return passwordTextBox.Text ?? "";
        }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.LoginLayout);

            emailTextBox = FindViewById<EditText>(Resource.Id.emailText);
            passwordTextBox = FindViewById<EditText>(Resource.Id.passwordText);
            loginButton = FindViewById<Button>(Resource.Id.loginButon);

        }

    }
}