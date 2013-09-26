using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using BasicOauth2 = DotNetOpenAuth.OAuth2;

namespace Nfro.Services.App.Authentication {
    public abstract class IOAuthenticator2 {
        protected String Key { get; }
        protected String Secret { get; }
        protected String LoginLinkUri { get; }
        protected String AuthorizationURL { get; }
        protected String CallBackURL { get; }

        protected String Code { get; set; }
        protected BasicOauth2.AuthorizationServerDescription ServerDescription { get; }

        public String GetRequestURL(){
            return LoginLinkUri;
        }

        public bool ProcessAuthenticate(String code, out String accessToken, out String refreshToken) {
            try {
                Code = code;
               NativeApplicationClient clientProvider = new NativeApplicationClient(ServerDescription, Key, Secret);

               var auth = new OAuth2Authenticator<NativeApplicationClient>(clientProvider, GetAuthorization);
                auth.LoadAccessToken();
                accessToken = auth.State.AccessToken;
                refreshToken = auth.State.RefreshToken;
                return true;
            }
            catch(Exception e) {
                accessToken = null;
                refreshToken = null;
                return false;
            }
        }

        private BasicOauth2.IAuthorizationState GetAuthorization(NativeApplicationClient arg) {
            // Get the auth URL:
            BasicOauth2.IAuthorizationState state = new BasicOauth2.AuthorizationState(new[] { AuthorizationURL });
            state.Callback = new Uri(CallBackURL);

            // Retrieve the access token by using the authorization code:
            return arg.ProcessUserAuthorization(Code, state);
        }
    }
}
