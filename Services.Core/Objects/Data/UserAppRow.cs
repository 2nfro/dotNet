using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Nfro.Core.Objects.Data {
    [TableName("tbUserApp")]
    [PrimaryKey("UserAppId")]
    public class UserAppRow {
        public long UserAppId { get; set; }
        public long AppId { get; set; }
        public long UserId { get; set; }
    }
}
