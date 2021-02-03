using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SEDOLChecker
{
    public class Program
    {
        public static void Main()
        {
            var inputText = Console.ReadLine();
            SedolValidator sedolValidator = new SedolValidator();

            sedolValidator.ValidateSedol(inputText);
        }
    }
}