using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Nfro.Core.Objects.Business {
    [Serializable]
    [DataContract]
    public class UserInfo {
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public long UserId { get; set; }
    }
}
