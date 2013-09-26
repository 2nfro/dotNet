using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Objects.Data {
    public class UserCodeRow {
        public long UserCodeId { get; set; }
        public long UserId { get; set; }
        public String UserCode { get; set; }
        public DateTime DateExpires { get; set; }
        public int Attempts { get; set; }
    }
}
