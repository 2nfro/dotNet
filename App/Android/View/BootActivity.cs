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
using Nfro.Core.Objects.Business;
using Nfro.App.Android.Providers.Cached;

namespace Nfro.App.Android.View {
    [Activity (Label = "BootActivity", MainLauncher = true)]	
    public class BootActivity : BaseActivity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            LoadStartScreen();
        }

        private void LoadStartScreen(){
            Intent intent;
            intent = new Intent(this, typeof(LoginActivity));



            StartActivity(intent);
            Finish();
        }
    }
}

