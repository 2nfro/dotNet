using System;
using Nfro.Core.Objects.Business;

namespace Nfro.App.Core.View {
    public interface IAppListView {
        void DisplayAppInfos(AppInfo[] appInfos);
    }
}

