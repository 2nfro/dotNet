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
using Nfro.App.Core.Task;
using Nfro.App.Android.Task;
using Nfro.App.Android.Interfaces;

namespace Nfro.App.Android.View {
    [Activity(Label = "Available Apps")]			
    public class AppListActivity : BaseListActivity, IAndroidAppListView {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            ILoadAppsTask task = new LoadAppsTask(this);
        }

        public void DisplayAppInfos(Nfro.Core.Objects.Business.AppInfo[] appInfos) {
            ArrayAdapter adapter = new AppListAdapter(this, appInfos);
            this.ListAdapter = adapter;
        }
    }
}

