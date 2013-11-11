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
using Nfro.App.Core.Providers.Cached;

namespace Nfro.App.Android.Providers.Cached {
    public class CachedUserInfoProvider : ICacheProvider, ICachedUserInfoProvider {
        private readonly String USER_INFO_FILE = "userInfo.dat";

        public bool IsUserInfoPersisted() {
            return IsDataPersisted(USER_INFO_FILE, Storage.FILES);
        }

        public void SaveUserInfo(UserInfo userInfo) {
            Save(USER_INFO_FILE, userInfo);
        }

        public UserInfo GetUserInfo() {
            try {
                return (UserInfo)Read(USER_INFO_FILE);
            }
            catch(Exception e) { 
                //TODO: Log exception
                return null;
            }
        }
    }
}

