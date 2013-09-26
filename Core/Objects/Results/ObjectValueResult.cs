using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Objects.Results {
    /*
     * Use For simple object results only
     */
    public class ObjectValueResult : Result {
        public readonly Object Value;

        public ObjectValueResult(Object value) : base(true) {
            Value = value;
        }

        public ObjectValueResult(String[] errors) : base(false) {
            Value = null;
            Errors = errors;
        }
    }
}
