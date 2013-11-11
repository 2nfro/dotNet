using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.OAuth2;

namespace Nfro.Services.App.Authentication {
    public abstract class IOAuthenticator2 {
        protected abstract String Key { get; }
        protected abstract String Secret { get; }
        protected abstract String LoginLinkUri { get; }
        protected abstract String AuthorizationURL { get; }
        protected abstract String CallBackURL { get; }

        protected String Code { get; set; }
        protected abstract AuthorizationServerDescription ServerDescription { get; }

        public String GetRequestURL(){
            return LoginLinkUri;
        }

        public bool ProcessAuthenticate(String code, out String accessToken, out String refreshToken) {
            try {
                accessToken = null;
                refreshToken = null;
                return true;
            }
            catch(Exception e) {
                accessToken = null;
                refreshToken = null;
                return false;
            }
        }
    }
}
