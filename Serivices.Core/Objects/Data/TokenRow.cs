using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Nfro.Core.Objects.Data {
    [PetaPoco.TableName("tbToken")]
    [PetaPoco.PrimaryKey("TokenId")]
    public class TokenRow {
        public long TokenId { get; set; }
        public long UserId { get; set; }
        public String Token { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpires { get; set; }
        public int DeviceId { get; set; }
    }
}
