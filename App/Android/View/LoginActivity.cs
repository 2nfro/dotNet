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
using Nfro.App.Android;
using Nfro.App.Core.View;
using Nfro.App.Android.Task;
using Nfro.App.Core.Task;

namespace Nfro.App.Android.View {
    [Activity]
    public class LoginActivity: BaseActivity, IAndroidLoginView {
        private EditText emailTextBox;
        private EditText passwordTextBox;
        private Button loginButton;

        public String GetPassword(){
            return passwordTextBox.Text ?? "";
        }

        public String GetEmailAddress(){
            return emailTextBox.Text ?? "";
        }

        public void ToMain() {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.LoginLayout);

            emailTextBox = FindViewById<EditText>(Resource.Id.emailText);
            passwordTextBox = FindViewById<EditText>(Resource.Id.passwordText);
            loginButton = FindViewById<Button>(Resource.Id.loginButon);

            loginButton.Click += (object sender, EventArgs e) => {
                ILoginTask task = new LoginTask(this);
                task.Authenticate();
            };
        }

    }
}