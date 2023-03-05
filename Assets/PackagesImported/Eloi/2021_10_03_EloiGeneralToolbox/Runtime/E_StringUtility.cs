using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Eloi
{
    public class E_StringUtility
    {
        public static readonly string abc = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string Num ="0123456789";
        public static readonly string AlphaNum="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static bool IsFilled(in string text)
        {
            if (text == null)
                return false;
            if (text.Length<=0)
                return false;
            if (string.IsNullOrWhiteSpace(text)) {
                return false;
            }
            return true;

        }
        public static void  ComputeSha256Hash(string textTohash, out string hash256Result)
        {
            //source: https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/#:~:text=The%20HashAlgorithm%20class%20is%20the,byte%20array%20of%20256%20bits.
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textTohash));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hash256Result=  builder.ToString();
            }
        }
        
        public static void Capitalize(in string text, out string result)
        {
            //source=https://stackoverflow.com/questions/913090/how-to-capitalize-the-first-character-of-each-word-or-the-first-character-of-a
            result = Regex.Replace(text, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }

        public static void SubstringBetween(int indexStart, int indexEnd, in string text, out string textFound)
        {
            int tl = text.Length;
            if (indexStart >= tl) indexStart = tl;
            if (indexEnd >= tl) indexEnd = tl;
            if (indexStart <0) indexStart = 0;
            if (indexEnd <0) indexEnd = 0;

            if (indexEnd < indexStart) {
                int t = indexEnd;
                indexEnd = indexStart;
                indexStart = t;
            }
            int l = indexEnd - indexStart;
            if (l == 0) textFound = "";
            else textFound = text.Substring(indexStart, l);
        }
        public static void SubstringBetween(int indexStart, int indexEnd, in string text, out string textFound, bool startInclude = true, bool endInclude = true)
        {
          
            if (!startInclude)
                indexStart += 1;
            if (!endInclude)
                indexEnd -= 1;
            SubstringBetween(indexStart, indexEnd, in text, out textFound);
        }

        public static void ConvertHexaToInt(string hexaText, out byte result)
        {
            try
            {
                result = byte.Parse(hexaText, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception) { result = 0; };
        }
        public static void ConvertHexaToInt(string hexaText, out int result)
        {
            try
            {
                result = Int32.Parse(hexaText, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception) { result = 0;};
        }

        public static bool IsNullOrEmpty( in string t)
        {
            return !IsFilled(t);
        }

        public static void ConvertToAlphaNumByReplacing(in string text, out string textResult, in string replaceNoneAlphaby="_")
        {
            Regex rgx = new Regex("[^a-zA-Z0-9_]");
            textResult = rgx.Replace(text, replaceNoneAlphaby);
        }

        public static void Clamp(in string givenText, out string clampText, in uint maxChar=32)
        {
            if (givenText.Length < maxChar)
                clampText = givenText;
            else 
               clampText = givenText.Substring(0, (int)maxChar);
        }

        public static bool StartWith( string text,  string line, bool ignoreCase, bool trim)
        {
            if (ignoreCase)
            {
                text = text.ToLower();
                line = line.ToLower();
            }
            if (trim)
            {
                text = text.Trim();
                line = line.Trim();
            }

            if (text == null || line == null)
                return false;
            if (text.Length < line.Length)
                return false;

          string textStart = text.Substring(0, line.Length);
          return  AreEquals(in line, in textStart, false, false);
        }

        public static bool EndWith(in string text, in string endWith)
        {
            if (text == null || text.Length == 0)
                return false;
            if (text.Length < endWith.Length)
                return false;

            if (text.Length == endWith.Length)
                return AreEquals(in text, in endWith);
            string t = text.Substring(text.Length - endWith.Length);
            //Debug.Log("^^"+t);
            return AreEquals(in t, in endWith);


        }

        public class Mail { 
            //private static readonly string notWantedCharInMail = "!#$%&'*+-/=?^_`{|}~";//19
            //private static readonly string notWantedCharSaveEquivalent = "♚♟♞♙♘♖♕♔♜♛♗♝♤♡♧♢←↑→";//19
            //public static void MaskSpecialCharOfEmail(string mail, out string maskedMail)
            //{
            //    char[] mailAsChar = mail.ToCharArray();
            //    for (int i = 0; i < mailAsChar; i++)
            //    {
            //        for (int i = 0; i < notWantedCharInMail; i++)
            //        {

            //        }
            //        if(mailAsChar[i]==)

            //    }
            //}
        }
        public static bool AreFilled(in string a, in string b, in bool ignoreCase, in bool useTrim)
        {
            return IsFilled(in a) && IsFilled(b);
        }

        public static void Contain(out bool valueIsContainedInGroup, in string value, in IEnumerable<string> groupOfValue, in bool ignoreCase, in bool useTrim) {
            foreach (string item in groupOfValue)
            {

                if (AreEquals(in value, in item, in ignoreCase, in useTrim)) {
                    valueIsContainedInGroup = true;
                    return;
                }
            }
            valueIsContainedInGroup = false;
        }


        public static bool AreNotEquals(in string a, in string b, in bool ignoreCase, in bool useTrim) {
            return !AreEquals(in a, in b, in ignoreCase, in useTrim);
        }
        private static bool m_true=true;
        public static bool AreEquals(in string a, in string b)
        {
            return AreEquals(in a, in b, in m_true, in m_true);
        }
        public static bool AreEquals(in string a, in string b, in bool ignoreCase, in bool useTrim)
        {

            if (a == null && b == null)
                return true;
            if ((a != null && b == null) 
                || (a == null && b != null))
                return false;

            string ta = a.ToString(), tb = b.ToString();
            //if (!ignoreCase && !useTrim)
            //{
            //    return (a.Length == b.Length && a.IndexOf(b) == 0);
            //}
            //else {
            if (ignoreCase)
                {
                    ta = ta.ToLower();
                    tb = tb.ToLower();
                }
                if (useTrim)
                {
                    ta = ta.Trim();
                    tb = tb.Trim();
            }
            return (ta.Length == tb.Length && ta == tb);
           // return (ta.Length == tb.Length && ta .IndexOf( tb)==0);
            //}

            //return false;
        }

        public static void SplitInTwo(in string text, in  int charIndex, out string leftPart, out string rightPart)
        {
            if (!E_StringUtility.IsFilled(text) || text.Length < 1)
                E_ThrowException.ThrowNotMyProblemException("Eloi", "Text can't be null, empty or too short");
            if (charIndex<0)
                E_ThrowException.ThrowNotMyProblemException("Eloi", "You need to give a index to split the text with");
            leftPart = text.Substring(0, charIndex);
            rightPart = text.Substring(charIndex+1);
        }
    }
}