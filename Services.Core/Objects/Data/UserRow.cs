using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Nfro.Core.Objects.Data {
    [PetaPoco.TableName("tbUser")]
    [PetaPoco.PrimaryKey("UserId")]
    public class UserRow {
        public long UserId { get; set; }
        public String Email { get; set; }
        public String PW { get; set; }
        public String Name { get; set; }
        public Boolean Active { get; set; }
    }
}
