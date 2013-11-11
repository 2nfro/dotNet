using System;
using System.Text;

namespace Nfro.Core.Helpers {
    public static class StringHelper {
        public static String ToOneLine(this String[] lines){
            if(lines.Length == 0){
                return "";
            }
            StringBuilder text = new StringBuilder(lines[0]);
            for(int index=1; index<lines.Length; index++){
                text.AppendLine(lines[index]);
            }
            return text.ToString();
        }
    }
}

