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
using Nfro.App.Core.View;
using Nfro.Core.Objects.Results;

namespace Nfro.App.Android.Task {
    public class LoginTask : AsyncTask<ILoginView, Java.Lang.Void, TokenValueResult> {

        protected override void OnPreExecute() {

        }

        protected override TokenValueResult RunInBackground(params ILoginView[] @params) {

        }

        protected override void OnPostExecute(TokenValueResult result) {

        }

    }
}

