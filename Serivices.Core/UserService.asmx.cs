using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Results;
using Nfro.Core.Objects;
using Nfro.Core.Providers;
using Nfro.Core.Security;

namespace Nfro.Services.Core {
    /// <summary>
    /// Summary description for UserServices
    /// </summary>
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService: CoreService {

        private static readonly int USER_CODE_EXPIRATION_DAYS = 7;
        private static readonly int MAX_USERCODE_ATTEMPTS = 5;

        [WebMethod]
        public Result CreateNewUser(UserInfo userInfo, String password) {
            String[] errors = ValidateNewUserInfo(userInfo.Name, userInfo.Email, password);
            if(errors != null) {
                return new Result(errors);
            }

            UserProvider userProvider = new UserProvider();
            if(userProvider.ContainsEmail(userInfo.Email)) {
                return new Result(new String[] { Result.ACCOUNT_EXISTS_ERROR });
            }
            long userId = userProvider.CreateNewUser(userInfo, password);

            UserCode userCode = new UserCode{Attempts = 0, Code = UserCodeGenerator.GenerateCode((int)userId), 
                DateExpires = DateTime.Now.AddDays(USER_CODE_EXPIRATION_DAYS), UserId = userId};
            UserCodeProvider userCodeProvider = new UserCodeProvider();
            userCodeProvider.CreateNewUserCode(userCode);

            //TODO : Send Email

            return new Result();
        }

        [WebMethod]
        public Result ActivateUser(int userId, String code) {
            String[] errors = ValidateText("User Code", code);
            if(errors.Length > 0) {
                return new Result(errors);
            }

            UserCodeProvider userCodeProvider = new UserCodeProvider();
            int attemptsMade = 0;
            bool isActivated = userCodeProvider.TryActivatingCode(userId, code, out attemptsMade);

            if(!isActivated) {
                if(attemptsMade >= MAX_USERCODE_ATTEMPTS) {
                    UserCode userCode = new UserCode {
                        UserId = userId,
                        DateExpires = DateTime.Now.AddDays(USER_CODE_EXPIRATION_DAYS),
                        Attempts = 0,
                        Code = UserCodeGenerator.GenerateCode((int)userId)
                    };
                    userCodeProvider.CreateNewUserCode(userCode);
                    //TODO: Send Email
                    return new Result(new String[] { Result.INVALID_CODE_MAX_ERROR });
                }
                return new Result(new String[] { Result.INVALID_CODE_ERROR });
            }

            userCodeProvider.RemoveUserCode(userId);
            UserProvider userProvider = new UserProvider();
            userProvider.ActivateUser(userId);

            //TODO: Send Success email

            return new Result();
        }

        [WebMethod]
        public TokenValueResult AuthenticateUser(UserInfo userInfo, String password, Device device) {
            String[] errors = ValidateLoginInfo(userInfo.Email, password);
            if(errors.Length > 0) {
                return new TokenValueResult(errors);
            }

            UserProvider userProvider = new UserProvider();
            long userId = userProvider.GetUserId(userInfo.Email, password);
            if(userId < 0) {
                return new TokenValueResult(new String[] { Result.EMAIL_PW_ERROR });
            }

            if(!userProvider.IsUserActive(userId)) {
                return new TokenValueResult(new String[0]) { NeedsActivation = true, Token = new Token { UserId = userId } };
            }

            Token token = new Token() { TokenString = TokenGenerator.GenerateToken((int)userId), DeviceType = device, DateExpires = GetNewTokenExpirationDate(device) };
            TokenProvider tokenProvider = new TokenProvider();
            tokenProvider.SaveToken(token);

            return new TokenValueResult(token);
        }

        [WebMethod]
        public void LogOut(int userId, Device device) {
            TokenProvider tokenProvider = new TokenProvider();
            tokenProvider.DeleteToken(userId, device);
        }

        private String[] ValidateNewUserInfo(String name, String email, String password){
            String[] errors = ValidateText("Name", name);
            if(errors.Length > 0) {
                return errors;
            }
            errors = ValidateEmail(email);
            if(errors.Length > 0) {
                return errors;
            }
            errors = ValidatePassword(password);
            if(errors.Length > 0) {
                return errors;
            }
            return new String[0];
        }

        private String[] ValidateLoginInfo(String email, String password) {
            String[] errors = ValidateEmail(email);
            if(errors.Length > 0) {
                return errors;
            }
            errors = ValidatePassword(password);
            if(errors.Length > 0) {
                return errors;
            }
            return new String[0];
        }
    }
}
