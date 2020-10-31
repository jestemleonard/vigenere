using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Xml;

namespace vigenere
{
    class Program
    {

        static string alphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        public static string Encrypt(string input, string key)
        {
            string output = String.Empty;

            //Make sure there are only valid letters in input/key
            Correct(ref input);
            Correct(ref key);

            //Make both strings the same length by repeating the shorter one
            if (input.Length > key.Length)
                key = RepeatShorter(key, input.Length);
            else if (input.Length < key.Length)
                input = RepeatShorter(input, key.Length);

            //Encryption
            for(int i = 0; i < input.Length; i++)
            {
                output += alphabet[(alphabet.IndexOf(input[i]) + alphabet.IndexOf(key[i])) % alphabet.Length];
            }

            return output;

        }

        public static string Decrypt(string input, string key)
        {
            string output = String.Empty;

            //Make sure there are only valid letters in input/key
            Correct(ref input);
            Correct(ref key);

            //Make both strings the same length by repeating the shorter one
            if (input.Length > key.Length)
                key = RepeatShorter(key, input.Length);
            else if (input.Length < key.Length)
                input = RepeatShorter(input, key.Length);

            //Decryption
            for (int i = 0; i < input.Length; i++)
            {
                output += alphabet[(alphabet.IndexOf(input[i]) - alphabet.IndexOf(key[i]) + alphabet.Length) % alphabet.Length];
            }

            return output;
        }

        static void Correct(ref string input)
        {
            string temp = String.Empty;
            input = input.ToUpper();
            foreach (char c in input)
            {
                if (alphabet.Contains(c))
                    temp += c;
            }

            input = temp;
        }

        static string RepeatShorter(string input, int length)
        {
            string output = String.Empty;
            for (int i = 0; i < length; i++)
                output += input[i % (input.Length)];
            return output;
        }
    }

}
