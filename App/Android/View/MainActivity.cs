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
using Nfro.App.Android.Providers.Cached;
using Nfro.Core.Objects.Business;

namespace Nfro.App.Android.View {
    [Activity]			
    public class MainActivity : BaseActivity, IAndroidMainView {
        private Button appListButton;

        public void showAppsList() {
            Intent intent = new Intent(this, typeof(AppListActivity));
            StartActivity(intent);
        }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.MainLayout);

            CachedUserInfoProvider userInfoProvider = new CachedUserInfoProvider();
            UserInfo userInfo = userInfoProvider.GetUserInfo();
            this.Title = userInfo.Name;

            appListButton = FindViewById<Button>(Resource.Id.appsListButton);
            appListButton.Click += (object sender, EventArgs e) => {
                showAppsList();
            };
        }
    }
} 

