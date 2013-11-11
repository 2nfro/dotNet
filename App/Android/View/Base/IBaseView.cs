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

namespace Nfro.App.Android.View {
    public interface IBaseView {
        void DisplayError(String error);
        void ShowLoadingDialog(String title, String text);
        void HideLoadingDialog();
    }

    public class BaseController{
        private Activity _activity;
        protected ProgressDialog _loadingDialog;

        public BaseController(Activity activity){
            _activity = activity;
        }

        public void onCreate(){

        }

        public void DisplayError(String error){
            Toast.MakeText(_activity, error, ToastLength.Long).Show();
        }

        public void ShowLoadingDialog(String title, String text){
            HideLoadingDialog();
            _loadingDialog = ProgressDialog.Show(_activity, title, text);
        }

        public void HideLoadingDialog(){
            if(_loadingDialog != null){
                _loadingDialog.Dismiss();
                _loadingDialog = null;
            }
        }
    }
}

