using System;
using System.Collections.Generic;
using System.Text;
using Nfro.Core.Objects;
using System.Runtime.Serialization;

namespace Nfro.Core.Objects.Business {
    [DataContract]
    public class AppInfo {
        [DataMember]
        public AppType AppType { get; set; }
        [DataMember]
        public String AppName { get; set; }
    }
}
