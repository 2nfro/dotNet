using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Objects.Business {
    public class Token {
        public String TokenString { get; set; }
        public DateTime DateExpires { get; set; }
        public Device DeviceType { get; set; }
        public long UserId { get; set; }
    }
}
