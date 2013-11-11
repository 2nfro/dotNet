using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nfro.Core.Objects;
using Nfro.Core.Objects.Data;
using Nfro.Core.Objects.Business;
using Nfro.Core.Security;

namespace Nfro.Core.Providers {
    public class TokenProvider : DataProvider{
        protected override string TABLE {
            get { return "tbToken"; }
        }

        public void SaveToken(Token token) {
            String tokenHash = AES.Encrypt(token.TokenString, token.TokenString + token.UserId);
            TokenRow savedTokenRow = db.SingleOrDefault<TokenRow>(@"WHERE UserId = @0 AND DeviceId = @1", token.UserId, (int)token.DeviceType);
            TokenRow tokenRow = new TokenRow() { DateCreated = DateTime.Now, DateExpires = token.DateExpires, DeviceId = (int)token.DeviceType, Token = tokenHash, UserId = token.UserId };
            if(savedTokenRow == null) {
                db.Insert(tokenRow);
            }
            else {
                tokenRow.TokenId = savedTokenRow.TokenId;
                db.Update(tokenRow);
            }
        }

        public Boolean isValid(string token, int userId) {
            TokenRow savedTokenRow = db.SingleOrDefault<TokenRow>(@"WHERE UserId = @0", userId);
            if(savedTokenRow == null) {
                return false;
            }
            if(AES.Decrypt(savedTokenRow.Token, savedTokenRow.Token + userId) == token) {
                return true;
            }
            return false;
        }

        public void DeleteToken(long userId, Device device) {
            if(device == Device.None) {
                db.Delete<TokenRow>("WHERE UserId = @0", userId);
            }
            else {
                db.Delete<TokenRow>("WHERE UserId = @0 AND DeviceId = @1", userId, (int)device);
            }
        }
    }
}
