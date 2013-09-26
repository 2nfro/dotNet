using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects;
using Nfro.Core.Objects.Data;
using Nfro.Core.Objects.Business;
using Nfro.Core.Security;

namespace Nfro.Core.Providers {
    public class UserProvider : DataProvider {
        //Password should be hashed not encrypted

        protected override string TABLE {
            get { return "tbUser"; }
        }

        public long GetUserId(String email, String pw) {
            UserRow user = db.Single<UserRow>("WHERE Email = @1", TABLE, email);

            if(user == null) {
                return -1;
            }

            String pwEncrypted = user.PW;
            if(AES.Decrypt(pwEncrypted, pw + user.UserId) == pw) {
                return user.UserId;
            }
            return -1;
        }

        public bool ContainsEmail(String email) {
            if(db.Single<UserRow>("WHERE Email = @0", email) != null) {
                return true;
            }
            return false;
        }

        public long CreateNewUser(UserInfo userInfo, String pw) {
            UserRow user = new UserRow() { Email = userInfo.Email, Active = false, Name = userInfo.Name, PW = AES.Encrypt(pw, pw + "0") };
            db.Insert(user);
            user.PW = AES.Encrypt(pw, pw + user.UserId);
            db.Update(user);
            return user.UserId;
        }

        public bool IsUserActive(long userId) {
            UserRow userRow = db.Single<UserRow>(userId);
            if(userRow == null) {
                return false;
            }
            return userRow.Active;
        }

        public void ActivateUser(long id) {
            UserRow user = db.Single<UserRow>(id);
            if(user != null) {
                user.Active = true;
                db.Update(user);
            }
        }

        public UserInfo GetUserInfo(int userId) {
            UserRow user = db.Single<UserRow>(userId);
            if(user == null) {
                return null;
            }
            return user.ToUserInfo();
        }
    }
}
