using System;
using System.Collections.Generic;
using System.Text;

namespace Nfro.Core.Objects.Business {
    public class Token {
        public String TokenString { get; set; }
        public DateTime DateExpires { get; set; }
        public Device DeviceType { get; set; }
        public long UserId { get; set; }
    }
}
