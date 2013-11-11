using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Results;

namespace Nfro.App.Core.Providers.Cached {
    public interface ICachedTokenProvider {
        bool IsTokenPersisted();

        void SaveToken(Token token);
        Token GetToken();
    }
}
