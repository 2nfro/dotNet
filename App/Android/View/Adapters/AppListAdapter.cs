using System;
using Android.Widget;
using Nfro.Core.Objects.Business;
using andView = Android.Views;
using Android.Content;

namespace Nfro.App.Android.View {
    public class AppListAdapter : ArrayAdapter<AppInfo> {
        private AppInfo[] _appInfos;

        public AppListAdapter(Context context, AppInfo[] appInfos) : base(context, Resource.Id.listView1, appInfos){
            _appInfos = appInfos;
        }

        public override andView.View GetView(int position, andView.View convertView, andView.ViewGroup parent) {
            AppInfo appInfo = _appInfos[position];
            TextView text = new TextView(this.Context);
            text.Text = appInfo.AppName;
            return text;
        }
    }
}

