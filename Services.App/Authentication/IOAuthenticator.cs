using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using SimpleOAuth;

namespace Nfro.Services.App.Authentication {
    public abstract class IOAuthenticator{
        protected abstract String consumerKey { get; }
        protected abstract String consumerSecret { get; }
        protected abstract String requestUrl { get; }
        protected abstract String authorizeUrl { get; }
        protected abstract String callback { get; }
        
        public String GetRequestURL() {
            try {
                var tokens = new Tokens() {
                    ConsumerKey = consumerKey,
                    ConsumerSecret = consumerSecret,
                };

                var request = WebRequest.Create(requestUrl);
                request.SignRequest()
                       .WithTokens(tokens)
                       .WithCallback(callback)
                       .WithEncryption(EncryptionMethod.HMACSHA1)
                       .InHeader();

                var responseStream = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                String response = reader.ReadToEnd();
                String[] results = response.Split('&');
                Dictionary<String, String> resultSet = new Dictionary<string, string>();
                foreach(String result in results) {
                    String[] headerValues = result.Split('=');
                    resultSet.Add(headerValues[0], headerValues[1]);
                }
                String oauthToken = resultSet["oauth_token"];
                String oauthTokenSecret = resultSet["oauth_token_secret"];

                RSACryptoServiceProvider cryptoProvider = new RSACryptoServiceProvider();

                return authorizeUrl + "?oauth_token=" + resultSet["oauth_token"];
            }
            catch(Exception) {
                return null;
            }
        }

        public String[] GetAccessToken(String consumerKey, String consumerSecret, String oauthToken, String oauthSecret, String oauthVerifier, String accessUrl) {
            var tokens = new Tokens() {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                AccessToken = oauthToken,
                AccessTokenSecret = oauthSecret
            };
            var request = WebRequest.Create(accessUrl);
            request.SignRequest()
                    .WithTokens(tokens)
                    .WithVerifier(oauthVerifier)
                    .InHeader();

            var responseStream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String response = reader.ReadToEnd();

            String[] results = response.Split('&');
            Dictionary<String, String> resultSet = new Dictionary<string, string>();
            foreach(String result in results) {
                String[] headerValues = result.Split('=');
                resultSet.Add(headerValues[0], headerValues[1]);
            }

            return new string[] { resultSet["oauth_token_secret"], resultSet["oauth_token"] };
        }
    }
}
