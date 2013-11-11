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
using System.Xml;

namespace Nfro.App.Android.View {		
    public class BaseActivity : Activity {
        private BaseController _baseController;
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            _baseController = new BaseController(this);
            _baseController.onCreate();
        }

        public void DisplayError(String error){
            _baseController.DisplayError(error);
        }

        public void ShowLoadingDialog(String title, String text){
            _baseController.ShowLoadingDialog(title, text);
        }
        public void HideLoadingDialog(){
            _baseController.HideLoadingDialog();
        }
    }
}

