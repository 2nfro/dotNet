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
using Nfro.Core.Helpers;
using Nfro.App.Core.View;
using Nfro.App.Core.Task;
using Nfro.Core.Objects.Business;
using Nfro.App.Android.View;
using Nfro.Core.Objects.Results;
using AndroidView = Android.Views;
using Nfro.App.Android.Providers.Web;
using Nfro.App.Android.Providers.Cached;

namespace Nfro.App.Android.Task {
    public class LoginTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, TokenValueResult>, ILoginTask {
        private IAndroidLoginView _view;

        public LoginTask(IAndroidLoginView view){
            _view = view;
        }

        public void Authenticate() {
            _view.ShowLoadingDialog("Logging In", "Please Wait...");
            this.Execute();
        }

        protected override TokenValueResult RunInBackground(params Java.Lang.Void[] @params){
            WebTokenProvider tokenProvider = new WebTokenProvider();
            UserInfo userInfo = new UserInfo() { Email = _view.GetEmailAddress() };
            return tokenProvider.Authenticate(userInfo, _view.GetPassword());
        }

        protected override void OnPostExecute(TokenValueResult result) {
            if (result.Success) {
                _view.HideLoadingDialog();
                CachedTokenProvider tokenProvider = new CachedTokenProvider();
                tokenProvider.SaveToken(result.Token);
                _view.ToMain();
            }
            else {
                String error = result.Errors.ToOneLine();
                _view.HideLoadingDialog();
                _view.DisplayError(error);
            }
        }
    }
}

