using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Objects.Business {
    public class UserCode {
        public long UserId { get; set; }
        public String Code { get; set; }
        public DateTime DateExpires { get; set; }
        public int Attempts { get; set; }
    }
}
