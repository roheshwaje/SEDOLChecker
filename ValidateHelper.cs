using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SEDOLChecker
{
    public class ValidateHelper
    {
        Result result = new Result();
        public Result ValidateInputSedol(string _InputString)
        {
            try
            {
                result.InputString = _InputString;
                bool _IsValidSedol = false;
                string _ErrorMessage = "";
                Regex _AlphaNumeric = new Regex("^[a-zA-Z0-9]*$");

                if (string.IsNullOrEmpty(_InputString) || _InputString.Length != 7)
                {
                    _ErrorMessage = "Input string was not 7-characters long";
                    result.IsUserDefined = false;
                    result.IsValidSedol = _IsValidSedol;
                    result.ValidationDetails = _ErrorMessage;
                    return result;
                }
                else if (!_AlphaNumeric.IsMatch(_InputString))
                {
                    _ErrorMessage = "SEDOL contains invalid characters";
                    result.IsUserDefined = false;
                    result.IsValidSedol = _IsValidSedol;
                    result.ValidationDetails = _ErrorMessage;
                    return result;
                }
                else
                {

                    if (ValidateSedolChecker(_InputString))
                    {
                        _ErrorMessage = "ValidSedol";
                        _IsValidSedol = true;
                        result.IsUserDefined = true;
                        result.IsValidSedol = _IsValidSedol;
                        result.ValidationDetails = _ErrorMessage;
                        return result;
                    }
                    else
                    {
                        _ErrorMessage = "Checksum digit does not agree with the rest of the input";
                        result.IsUserDefined = false;
                        result.IsValidSedol = _IsValidSedol;
                        result.ValidationDetails = _ErrorMessage;

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                result.IsUserDefined = false;
                result.IsValidSedol = false;
                result.ValidationDetails = ex.ToString();

                return result;
            }
        }

        public bool ValidateSedolChecker(string _InputString)
        {
            try
            {
                Regex NumericOnly = new Regex("^[0-9]*$");
                char[] charArray = _InputString.ToCharArray();
                int num1, num2, num3, num4, num5, num6, num7, sumOfNum1To6;
                if (NumericOnly.IsMatch(charArray[0].ToString()))
                {
                    num1 = Convert.ToInt32(charArray[0].ToString()) * 1;
                }
                else
                {
                    num1 = returnAlphabetValue(Convert.ToChar(charArray[0]));
                    num1 = (num1 + 9) * 1;
                }
                if (NumericOnly.IsMatch(charArray[1].ToString()))
                {
                    num2 = Convert.ToInt32(charArray[1].ToString()) * 3;
                }
                else
                {
                    num2 = returnAlphabetValue(Convert.ToChar(charArray[1]));
                    num2 = (num2 + 9) * 3;
                }
                if (NumericOnly.IsMatch(charArray[2].ToString()))
                {
                    num3 = Convert.ToInt32(charArray[2].ToString()) * 1;
                }
                else
                {
                    num3 = returnAlphabetValue(Convert.ToChar(charArray[2]));
                    num3 = (num3 + 9) * 1;
                }
                if (NumericOnly.IsMatch(charArray[3].ToString()))
                {
                    num4 = Convert.ToInt32(charArray[3].ToString()) * 7;
                }
                else
                {
                    num4 = returnAlphabetValue(Convert.ToChar(charArray[3]));
                    num4 = (num4 + 9) * 7;
                }
                if (NumericOnly.IsMatch(charArray[4].ToString()))
                {
                    num5 = Convert.ToInt32(charArray[4].ToString()) * 3;
                }
                else
                {
                    num5 = returnAlphabetValue(Convert.ToChar(charArray[4]));
                    num5 = (num5 + 9) * 3;
                }
                if (NumericOnly.IsMatch(charArray[5].ToString()))
                {
                    num6 = Convert.ToInt32(charArray[5].ToString()) * 9;
                }
                else
                {
                    num6 = returnAlphabetValue(Convert.ToChar(charArray[5]));
                    num6 = (num6 + 9) * 9;
                }

                sumOfNum1To6 = num1 + num2 + num3 + num4 + num5 + num6;
                num7 = Convert.ToInt32(charArray[6].ToString());

                int checker = (10 - (sumOfNum1To6 % 10)) % 10;
                if (checker == num7)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public int returnAlphabetValue(char c)
        {
            int charValue = 0;
            //string.ToLower(c);
            string alphabet = Convert.ToString(c);
            alphabet = alphabet.ToLower();
            Dictionary<string, int> myAlphaValue = new Dictionary<string, int>();
            myAlphaValue.Add("a", 1);
            myAlphaValue.Add("b", 2);
            myAlphaValue.Add("c", 3);
            myAlphaValue.Add("d", 4);
            myAlphaValue.Add("e", 5);
            myAlphaValue.Add("f", 6);
            myAlphaValue.Add("g", 7);
            myAlphaValue.Add("h", 8);
            myAlphaValue.Add("i", 9);
            myAlphaValue.Add("j", 10);
            myAlphaValue.Add("k", 11);
            myAlphaValue.Add("l", 12);
            myAlphaValue.Add("m", 13);
            myAlphaValue.Add("n", 14);
            myAlphaValue.Add("o", 15);
            myAlphaValue.Add("p", 16);
            myAlphaValue.Add("q", 17);
            myAlphaValue.Add("r", 18);
            myAlphaValue.Add("s", 19);
            myAlphaValue.Add("t", 20);
            myAlphaValue.Add("u", 21);
            myAlphaValue.Add("v", 22);
            myAlphaValue.Add("w", 23);
            myAlphaValue.Add("x", 24);
            myAlphaValue.Add("y", 25);
            myAlphaValue.Add("z", 26);


            if (myAlphaValue.ContainsKey(alphabet))
            {
                charValue = myAlphaValue[alphabet];
                return charValue;
            }
            return 0;
        }
    }
}