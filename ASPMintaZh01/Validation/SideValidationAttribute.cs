using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMintaZh01.Validation
{
    public class SideValidationAttribute : ValidationAttribute
    {
        List<string> enabledSides;
        public SideValidationAttribute(string[] enabledSides)
        {
            this.enabledSides = enabledSides.ToList();
        }

        public override bool IsValid(object value)
        {
            string input = (string)value;
            return enabledSides.Contains(input);
        }

        public override string FormatErrorMessage(string name)
        {
            string error = "Endélyezett oldalak: ";
            foreach (var item in enabledSides)
            {
                error += item + ", ";
            }
            return error.Substring(0, error.Length - 2);
        }
    }
}
