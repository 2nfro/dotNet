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
using Nfro.App.Core.Providers.Web;
using Nfro.Core.Helpers;

namespace Nfro.App.Android.Providers.Web {
    public class WebAppProvider : IAppProvider {

        public Nfro.Core.Objects.Business.AppInfo[] GetAllAppInfos() {
            try{
                Nfro.App.Android.AppServices.AppService appServices = new Nfro.App.Android.AppServices.AppService();
                Nfro.App.Android.AppServices.AppInfo[] appInfos = appServices.GetAppInfos();
                return appInfos.ChangeTo<Nfro.Core.Objects.Business.AppInfo[]>();
            }
            catch(Exception e){
                //TODO: Log e
                return null;
            }
        }
    }
}

