using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Objects.Results {
    public class Result {
        public static readonly String INVALID_TOKEN_ERROR = "INVALID_TOKEN";
        public static readonly String USER_APP_EXISTS_ERROR = "USER_APP_EXISTS";
        public static readonly String ACCOUNT_EXISTS_ERROR = "An account with this email address already exists.";
        public static readonly String EMAIL_PW_ERROR = "Wrong email and password combination.";
        public static readonly String INVALID_CODE_ERROR = "The code you have given is incorrect.";
        public static readonly String INVALID_CODE_MAX_ERROR = "Because you have given the incorrect code too many times, it has now been reset. Please check your email for the new code.";

        public readonly Boolean Success;
        public String[] Errors { get; set; }

        public Result(bool success=true) {
            Success = success;
        }

        public Result(String[] errors) {
            Success = false;
            Errors = errors;
        }
    }
}
