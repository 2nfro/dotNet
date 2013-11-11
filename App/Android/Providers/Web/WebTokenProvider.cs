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
using Nfro.Core.Objects;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Results;
using Nfro.Core.Helpers;

namespace Nfro.App.Android.Providers.Web {
    public class WebTokenProvider : IWebTokenProvider{

        public Nfro.Core.Objects.Results.TokenValueResult Authenticate(Nfro.Core.Objects.Business.UserInfo userInfo, string password) {
            try{
                Nfro.App.Android.UserServices.UserService service = new Nfro.App.Android.UserServices.UserService();
                Nfro.App.Android.UserServices.UserInfo changedUserInfo = userInfo.ChangeTo<Nfro.App.Android.UserServices.UserInfo>();
                Nfro.App.Android.UserServices.Device changedDevice = Device.Android.ChangeTo<Nfro.App.Android.UserServices.Device>();
                Nfro.App.Android.UserServices.TokenValueResult tokenValueResult = service.AuthenticateUser(changedUserInfo, password, changedDevice);
                return tokenValueResult.ChangeTo<Nfro.Core.Objects.Results.TokenValueResult>();
            }
            catch(Exception e){
                if(e == null){
                    return new Nfro.Core.Objects.Results.TokenValueResult(new String[] { "Error loggingg in" });
                }
                //TODO: Log exception
                return new Nfro.Core.Objects.Results.TokenValueResult(new String[] { e.Message });
            }
        }

        public bool IsValid(Nfro.Core.Objects.Business.Token token) {
            throw new NotImplementedException();
        }
    }
}

