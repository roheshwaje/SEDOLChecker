using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace SEDOLChecker
{
    public class SedolValidationResult : ISedolValidationResult
    {
        string _InputString;
        public string InputString
        {
            get => _InputString;
        }
        bool _IsValidSedol;
        public bool IsValidSedol
        {
            get => _IsValidSedol;
        }
        bool _IsUserDefined;
        public bool IsUserDefined
        {
            get => _IsUserDefined;
        }
        string _ValidationDetails;
        public string ValidationDetails
        {
            get => _ValidationDetails;
        }
        public SedolValidationResult(string InputString, bool IsValidSedol, bool IsUserDefined, string ValidationDetails)
        {
            _InputString = InputString;
            _IsValidSedol = IsValidSedol;
            _IsUserDefined = IsUserDefined;
            _ValidationDetails = ValidationDetails;
        }

        

    }
}