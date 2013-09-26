using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects.Business;

namespace Nfro.Core.Objects.Results {
    public class TokenValueResult : Result{
        public Token Token { get; set; }
        public bool NeedsActivation { get; set; }

        public TokenValueResult(String[] errors) : base(false) {
            Errors = errors;
            Token = null;
        }

        public TokenValueResult(Token token) : base(true) {
            Token = token;
        }
    }
}
