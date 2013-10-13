﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects.Business;

namespace Nfro.App.Core.Providers.Cached {
    public interface ICachedUserInfoProvider {
        bool isUserInfoPersisted();

        void saveUserInfo(UserInfo userInfo);

        UserInfo getUserInfo();
    }
}
