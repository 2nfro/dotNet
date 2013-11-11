using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nfro.Core.Objects.Business;
using System.Runtime.Serialization;

namespace Nfro.Core.Objects.Results {
    [DataContract]
    public class TokenValueResult : Result{
        [DataMember]
        public Token Token { get; set; }
        [DataMember]
        public bool NeedsActivation { get; set; }

        public TokenValueResult() : base(false) {
            Errors = new String[0];
            Token = null;
        }

        public TokenValueResult(String[] errors) : base(false) {
            Errors = errors;
            Token = null;
        }

        public TokenValueResult(Token token) : base(true) {
            Token = token;
        }
    }
}
