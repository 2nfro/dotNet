using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Nfro.Core.Providers;
using Nfro.Core.Objects;
using Nfro.Core.Objects.Business;
using Nfro.Services.Core.Helpers;

namespace Nfro.Services.Core {
    /// <summary>
    /// Summary description for CoreService
    /// </summary>
    [WebService(Namespace = "http://localhost.com/services")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CoreService: System.Web.Services.WebService {

        private static String TOKEN_INVALID_STRING = "Your login token is invalid.";

        protected Boolean isValidToken(int userId, String token) {
            String[] errors = ValidateToken(token);
            if(errors.Length > 0) {
                return false;
            }
            TokenProvider provider = new TokenProvider();
            return provider.isValid(token, userId);
        }

        protected String[] ValidateEmail(String email) {
            return new ValidationHelper("Email", email).CheckIsEmail().Errors;
        }

        protected String[] ValidatePassword(String password) {
            return new ValidationHelper("Password", password).CheckIsAlphanumeric().CheckMaximumLength(25).CheckMinimumLength(8).Errors;
        }

        protected String[] ValidateToken(String token) { 
            return new ValidationHelper("Token", token).CheckIsAlphanumeric().HasErrors ? new String[] {TOKEN_INVALID_STRING} : new String[0];
        }

        protected String[] ValidateText(String name, String text) {
            return new ValidationHelper(name, text).CheckIsAlphanumeric().Errors;
        }

        protected DateTime GetNewTokenExpirationDate(Device device) {
            switch(device) { 
                case Device.Android:
                case Device.iPhone:
                case Device.Web:
                    return DateTime.Now.AddMonths(1);
                default:
                    return DateTime.Now.AddDays(7);
            }
        }
    }
}
