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
using Nfro.Core.Objects.Results;
using Nfro.App.Core.Providers.Cached;

namespace Nfro.App.Android.Providers.Cached {		
    public class CachedTokenProvider : ICacheProvider, ICachedTokenProvider {
        private readonly String TOKEN_FILE = "userInfo.dat";

        public bool IsTokenPersisted() {
            return IsDataPersisted(TOKEN_FILE, Storage.FILES);
        }

        public void SaveToken(Token token) {
            Save(TOKEN_FILE, token);
        }

        public Token GetToken() {
            try {
                return (Token)Read(TOKEN_FILE);
            }
            catch(Exception e) { 
                //TODO: Log exception
                return null;
            }
        }
    }
}

