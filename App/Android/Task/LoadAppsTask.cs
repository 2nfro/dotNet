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
using Nfro.App.Core.Task;
using Nfro.Core.Objects.Business;
using Nfro.App.Core.View;
using Nfro.App.Android.Providers.Web;
using Nfro.App.Android.Interfaces;

namespace Nfro.App.Android.Task {
    public class LoadAppsTask: AsyncTask<Java.Lang.Void, Java.Lang.Void, AppInfo[]>, ILoadAppsTask {
        IAndroidAppListView _view;
        public LoadAppsTask(IAndroidAppListView view){
            _view = view;
        }

        public void LoadAppsList() {
            _view.ShowLoadingDialog("Loading Apps", "Please Wait...");
            this.Execute();
        }

        protected override AppInfo[] RunInBackground(params Java.Lang.Void[] @params) {
            WebAppProvider appProvider = new WebAppProvider();
            return appProvider.GetAllAppInfos();
        }

        protected override void OnPostExecute(AppInfo[] result) {
            _view.HideLoadingDialog();
            if(result == null){
                _view.DisplayError("Error getting Apps List. Please try again.");
            }
            else{
                _view.DisplayAppInfos(result);
            }
        }
    }
}

