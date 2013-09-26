using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nfro.Core.Security {
    public class TokenGenerator {
        public static String GenerateToken(int userId) {
            DateTime current = DateTime.Now;
            String ticks = current.Ticks.ToString();
            StringBuilder token = new StringBuilder();
            Random rand = new Random();
            Queue<char> charQueue = new Queue<char>();
            int charIndex = userId;
            token.Append(current.GetHashCode());
            int tickLength = ticks.Length;
            token.Append(getChar(charIndex, rand.Next(2) == 0));
            token.Append(ticks[rand.Next(tickLength)]);
            while(charIndex/26 > 0) {
                charIndex /= 13;
                token.Append(getChar(charIndex, rand.Next(2) == 0));
                token.Append(ticks[rand.Next(tickLength)]);
            }
            return token.ToString();
        }

        private static char getChar(int index, bool upperCase) {
            char newChar = (char)(((int)'A') + (index % 26));
            return upperCase ? newChar : newChar.ToString().ToLower()[0];
        }
    }
}
