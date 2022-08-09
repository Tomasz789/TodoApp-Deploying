using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TodoApp.DataVerifier
{
    /// <summary>
    /// Static class for validing data.
    /// There are three data types for validating: username, email and password.
    /// </summary>
    public static class Verifier
    {
        /// <summary>
        /// Verify given data.
        /// </summary>
        /// <param name="data">String representation of entity data - username, email or password.</param>
        /// <param name="type">Data type - see enum EntityDataType</param>
        /// <returns>True if data is valid.</returns>
        public static bool Verify(string data, EntityDataType type)
        {
            string regexValue = string.Empty;

            if (string.IsNullOrEmpty(data))
            {
                return false;
            }

            switch (type)
            {
                case EntityDataType.EMAIL:
                {
                    regexValue = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";//"^[/w-/.]+@([/w-]+/.)+[/w-]{2,4}$";
                }
                break;
                case EntityDataType.USERNAME:
                {
                    regexValue  = "^[A-Za-z][A-Za-z0-9_]{6,29}$";
                }
                break;
                case EntityDataType.PASSWORD:
                {
                        regexValue = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,32}$";
                }
                break;
            }

            var regex = new Regex(regexValue);

            if (!regex.IsMatch(data))
            {
                return false;
            }

            return true;
        }

        public static void VerifyTextValue(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
               throw new ArgumentNullException(nameof(text));
            }
        }

        public static void VerifyDate(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                throw new ArgumentException(nameof(dateTime));
            }
        }
    }
}
