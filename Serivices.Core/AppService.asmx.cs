using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Nfro.Core.Objects;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Results;
using Nfro.Core.Providers;

namespace Nfro.Services.Core {
    /// <summary>
    /// Summary description for AppServices
    /// </summary>
    [WebService(Namespace = NAMESPACE)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AppService: CoreService {
        private static readonly String APP_CREATION_FAILURE = "Failed to connect to app.";

        [WebMethod]
        public AppInfo[] GetAppInfos() {
            AppService appService = new AppService();
            return appService.GetAppInfos();
        }

        [WebMethod]
        public ObjectValueResult CreateUserApp(Token token, AppType appType) { 
            bool isValid = isValidToken((int)token.UserId, token.TokenString);
            if(!isValid) {
                return new ObjectValueResult(new String[] { Result.INVALID_TOKEN_ERROR });
            }

            UserAppProvider appProvider = new UserAppProvider();
            UserAppInfo userAppInfo = appProvider.GetUserApp(token.UserId, appType);
            if(userAppInfo != null) {
                return new ObjectValueResult(new String[] { Result.USER_APP_EXISTS_ERROR });
            }

            userAppInfo = appProvider.CreateUserApp(token.UserId, appType);
            if(userAppInfo == null) {
                return new ObjectValueResult(new String[] { APP_CREATION_FAILURE });
            }
            return new ObjectValueResult(userAppInfo);
        }

        //get app data
        public void GetAppData() { 
            
        }

        //load app data
        public void SaveToApp(){
            
        }
    }
}
