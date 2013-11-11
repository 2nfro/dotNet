using System;
using Nfro.Core.Objects.Business;

namespace Nfro.App.Core.Providers.Web {
    public interface IAppProvider {
        AppInfo[] GetAllAppInfos();
    }
}

