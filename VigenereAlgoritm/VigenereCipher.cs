using System;
using System.Collections.Generic;
using System.Text;

namespace VigenereAlgoritm
{
	class VigenereCipher
	{
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string letters;

        public VigenereCipher(string alphabet = null)
        {
            letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
        }

        private string GetRepeatKey(string s, int n)
        {
            var p = s;
            while (p.Length < n)
			{
                p += p; 
            }

            return p.Substring(0, n);
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            string gamma = GetRepeatKey(password, text.Length);
            string retValue = "";
            int q = letters.Length;

            for (int i = 0; i < text.Length; i++)
            {
                int letterIndex = letters.IndexOf(text[i]);
                int codeIndex = letters.IndexOf(gamma[i]);
                if (letterIndex < 0)
                {
                    retValue += text[i];
                }
                else
                {
                    retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                }
            }

            return retValue;
        }

        public string Encrypt(string plainMessage, string password)
            => Vigenere(plainMessage, password);



        public string Decrypt(string encryptedMessage, string password)
            => Vigenere(encryptedMessage, password, false);
    }
}
