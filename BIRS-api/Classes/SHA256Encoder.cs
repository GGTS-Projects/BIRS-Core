﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BIRS_api.Classes
{
    public static class SHA256Encoder
    {
        private static readonly SHA256 encoder = SHA256.Create();

        /// <summary>
        /// Method encodes a given string to an SHA256 encoded string. If <paramref name="givenString"/> is <c>null</c> or empty,
        /// an empty string is returned. For conversion, the ASCII bytes of the string are used.
        /// </summary>
        /// <param name="givenString">String that will be converted.</param>
        /// <returns>SHA256 encoded version of <paramref name="givenString"/></returns>
        public static string EncodeString(string givenString)
        {
            string hashString = string.Empty;

            if (string.IsNullOrEmpty(givenString))
            {
                return hashString;
            }

            var hash = encoder.ComputeHash(Encoding.ASCII.GetBytes(givenString));
            foreach (byte b in hash)
            {
                hashString = hashString + string.Format("{0:x2}", b);
            }

            return hashString;
        }
    }
}
