using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects.Data;
using Nfro.Core.Objects.Business;

namespace Nfro.Core.Providers {
    public class UserCodeProvider :DataProvider {

        protected override string TABLE {
            get { return "tbUserCode"; }
        }

        public void CreateNewUserCode(UserCode userCode) {
            UserCodeRow userCodeRow = db.SingleOrDefault<UserCodeRow>("WHERE UserId = @0", userCode.UserId);
            if(userCodeRow == null) {
                userCodeRow = new UserCodeRow() { Attempts = 0, UserCode = userCode.Code, UserId = userCode.UserId, DateExpires = userCode.DateExpires };
                db.Insert(userCodeRow);
            }
            else {
                userCodeRow.UserCode = userCode.Code;
                userCodeRow.Attempts = 0;
                userCodeRow.DateExpires = userCode.DateExpires;
                db.Update(userCodeRow);
            }
        }

        public bool TryActivatingCode(int userId, String code, out int attemptsMade) {
            //TODO: Encrypt user code.
            attemptsMade = -1;
            UserCodeRow userCodeRow = db.Single<UserCodeRow>("WHERE UserId = @0", userId);
            if(userCodeRow == null) {
                return false;
            }
            if(userCodeRow.UserCode == code) {
                return true;
            }
            userCodeRow.Attempts++;
            attemptsMade = userCodeRow.Attempts;
            db.Save(userCodeRow);
            return false;
        }

        public void RemoveUserCode(int userId) {
            db.Delete<UserCodeRow>("WHERE UserId = @0", userId);
        }
    }
}
