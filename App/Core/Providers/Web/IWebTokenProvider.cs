using System;
using Nfro.Core.Objects.Business;
using Nfro.Core.Objects.Results;

namespace Nfro.App.Core.Providers.Web {
    public interface IWebTokenProvider {

        TokenValueResult Authenticate(UserInfo userInfo, String password);

        bool IsValid(Token token);
    }
}