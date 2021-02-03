using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDOLChecker
{
    public class Result
    {
        public string InputString { get; set; }
        public bool IsValidSedol { get; set; }
        public bool IsUserDefined { get; set; }
        public string ValidationDetails { get; set; }
    }
}