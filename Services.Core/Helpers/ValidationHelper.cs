using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nfro.Services.Core.Helpers {
    public class ValidationHelper {
        private List<String> errors;
        public String[] Errors { get { return errors.ToArray(); } }
        public Boolean HasErrors { get { return errors.Count > 0; } }


        private String textValue;
        private String textName;

        public ValidationHelper(String name, String text) {
            textName = name;
            textValue = text;
            errors = new List<string>();
        }

        public ValidationHelper CheckIsAlphanumeric() {
            Match match = Regex.Match(textValue, "^[a-zA-Z0-9]+$");
            if(!match.Success) {
                errors.Add(String.Format("{0} must contain only numbers and letter.", textName));
            }
            return this;
        }

        public ValidationHelper CheckIsRegex(String regex) {
            Match match = Regex.Match(textValue, regex);
            if(!match.Success) {
                errors.Add(String.Format("{0} is invalid.", textName));
            }
            return this;
        }

        public ValidationHelper CheckIsEmail() { 
            String regexEmail = "^[A-Z0-9\\._-]+@[A-Z0-9\\.-]+\\.[A-Z]{2,4}$";
            Match match = Regex.Match(textValue, regexEmail, RegexOptions.IgnoreCase);
            if(!match.Success) {
                errors.Add(String.Format("{0} is not a valid email address.", textValue));
            }
            return this;
        }

        public ValidationHelper CheckMinimumLength(int minLength) {
            if(textValue.Length < minLength) {
                errors.Add(String.Format("{0} must have a minimum length of {1}.", textName, minLength));
            }
            return this;
        }

        public ValidationHelper CheckMaximumLength(int maxLength) {
            if(textValue.Length > maxLength) {
                errors.Add(String.Format("{0} must have a maximum length {1}.", textName, maxLength));
            }
            return this;
        }

        public ValidationHelper CheckExactLength(int length) {
            if(textValue.Length != length) {
                errors.Add(String.Format("{0} must have as length of {1}.", textName, length));
            }
            return this;
        }
    }
}