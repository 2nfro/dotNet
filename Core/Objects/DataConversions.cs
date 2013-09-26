using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Objects {
    public static class DataConversions {
        public static Business.UserInfo ToUserInfo(this Data.UserRow userRow) {
            return new Business.UserInfo { UserId = userRow.UserId, Email = userRow.Email, Name = userRow.Name };
        }

        public static Business.UserCode ToUserCode(this Data.UserCodeRow userCodeRow) {
            return new Business.UserCode { UserId = userCodeRow.UserId, Attempts = userCodeRow.Attempts, DateExpires = userCodeRow.DateExpires, Code = userCodeRow.UserCode };
        }

        public static Business.Token ToToken(this Data.TokenRow tokenRow) {
            Device device = Device.None;
            if(Enum.IsDefined(typeof(Device), tokenRow.DeviceId)){
                device = (Device)tokenRow.DeviceId;
            }
            return new Business.Token { TokenString = tokenRow.Token, DateExpires = tokenRow.DateExpires, DeviceType = device, UserId = tokenRow.UserId };
        }

        public static Business.AppInfo ToAppInfo(this Data.AppRow appRow) {
            AppType type = AppType.None;
            if(Enum.IsDefined(typeof(AppType), appRow.AppId)) {
                type = (AppType)appRow.AppId;
            }
            return new Business.AppInfo { AppType = type, AppName = appRow.AppName };
        }
    }
}
