using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Data;
using PetaPoco;

namespace Nfro.Core.Providers {
    public class UserAppProvider : AppProvider {

        protected override string TABLE {
            get {
                return "tbUserApp";
            }
        }

        public UserAppInfo GetUserApp(long userId, AppType appType) {
            UserAppInfo userAppInfo = db.Single<UserAppInfo>(GetUserAppInfoJoin(userId, appType));
            return userAppInfo;
        }

        public UserAppInfo CreateUserApp(long userId, AppType appType) {
            try {
                int appId = (int)appType;
                UserAppRow userAppRow = new UserAppRow() { AppId = appId, UserId = userId };
                db.Insert(userAppRow);
                return db.Single<UserAppInfo>(GetUserAppInfoJoin(userId, appType));
            }
            //TODO: Add logging of error
            catch(Exception e) {
                Console.Out.WriteLine(e.Message);
            }
            return null;
        }

        //TODO: Write join for tbUserApp and tbApp
        private Sql GetUserAppInfoJoin(long userId, AppType appType) {
            throw new NotImplementedException();
        }
    }
}
