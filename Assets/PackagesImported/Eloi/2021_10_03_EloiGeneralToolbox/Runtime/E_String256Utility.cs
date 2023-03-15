using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_StringByte64Utility : MonoBehaviour
    {
        //public static readonly string b64AsString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        //public static readonly char[] b64AsChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".ToCharArray();


        public static void GetText64FromText(in string text, out string textAsB64)
        {
            Base64EncodeUsingUTF8(in text, out textAsB64);

        }
        public static void GetTextFromTextB64(in string textAsB64, out bool converted, out string text)
        {
            try
            {
                Base64DecodeUTF8(in textAsB64, out text);
                converted = true;
                return;
            }
            catch (Exception e) { }
            text = "";
            converted = false;
        }

        public static void Base64EncodeUsingUTF8(in string plainText, out string base64EncodedData)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            base64EncodedData = System.Convert.ToBase64String(plainTextBytes);
        }
        public static void Base64DecodeUTF8(in string base64EncodedData, out string plainText)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            plainText = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static void Base64EncodeUsingUnicode(in string plainText, out string base64EncodedData)
        {
            var plainTextBytes = System.Text.Encoding.Unicode.GetBytes(plainText);
            base64EncodedData = System.Convert.ToBase64String(plainTextBytes);
        }
        public static void Base64DecodeUnicode(in string base64EncodedData, out string plainText)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            plainText = System.Text.Encoding.Unicode.GetString(base64EncodedBytes);
        }
        #region IF ON THE SAME SYSTEM
        //https://stackoverflow.com/questions/472906/how-do-i-get-a-consistent-byte-representation-of-strings-in-c-sharp-without-manu
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        // Do NOT use on arbitrary bytes; only use on GetBytes's output on the SAME system
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        #endregion

        public static void Base64EncodeUsingUTF8FileSafe(in string plainText, out string base64EncodedData)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            base64EncodedData = System.Convert.ToBase64String(plainTextBytes);
            base64EncodedData= base64EncodedData.Replace("/", "_");
            base64EncodedData= base64EncodedData.Replace("+", "-");
        }
        public static void Base64DecodeUTF8FileSafe(in string base64EncodedData, out string plainText)
        {
            string t = base64EncodedData.Replace( "_","/");
            t = t.Replace("-","+" );
            var base64EncodedBytes = System.Convert.FromBase64String(t);
            plainText = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

        }


    }

}