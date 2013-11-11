using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Nfro.Core.Objects.Data {
    [PetaPoco.TableName("tbApp")]
    [PetaPoco.PrimaryKey("AppId")]
    public class AppRow {
        public long AppId { get; set; }
        public String AppName { get; set; }
    }
}
