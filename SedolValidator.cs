using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDOLChecker
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string input)
        {
            ValidateHelper validateHelper = new ValidateHelper();
            var result = validateHelper.ValidateInputSedol(input);
            SedolValidationResult sedolValidationResult = new SedolValidationResult(result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            return sedolValidationResult;
        }
    }
}