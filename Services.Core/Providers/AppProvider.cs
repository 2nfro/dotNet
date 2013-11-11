using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Data;

namespace Nfro.Core.Providers {
    public class AppProvider : DataProvider {

        protected override string TABLE {
	        get { return "tbApp"; }
        }

        public AppInfo[] GetAppList() {
            List<AppRow> apps = db.Fetch<AppRow>("WHERE Active = @0", true);
            return apps.Select<AppRow, AppInfo>((x) => {
                return x.ToAppInfo();
            }).ToArray();
        }
    }
}
