using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Security {
    public class UserCodeGenerator {

        private readonly static Random _rand = new Random();

        private readonly static int CODE_MIN_LENGTH = 5;
        private readonly static int CODE_MAX_LENGTH = 10;

        private readonly static int A = (int)'A';

        //Code between 5 and 10 characters long.
        public static String GenerateCode(int userId){
            Random rand = new Random(userId);
            int starter = _rand.Next(25);
            for(int i = 0; i < starter; i++) {
                rand.Next();
            }
            int codeLength = rand.Next(CODE_MIN_LENGTH, CODE_MAX_LENGTH + 1);
            StringBuilder codeBuilder = new StringBuilder();
            for(int i = 0; i < codeLength; i++) {
                codeBuilder.Append(GetChar(rand.Next(72)));
            }
            return codeBuilder.ToString();
        }

        private static char GetChar(int charKey) {
            if(charKey > 72 || charKey < 0) {
                throw new Exception("CharKey needs to be greater than 0 and less than 36");
            }
            if(charKey < 20) {
                return (charKey%10).ToString()[0];
            }
            int key = charKey - 20;
            char letter = (char)(A + (key % 26));
            if(key / 26 == 0) {
                return char.ToLower(letter);
            }
            return letter;
        }
    }
}
