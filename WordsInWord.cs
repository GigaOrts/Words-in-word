using System.Collections.Generic;
using System.Linq;
using System;

namespace Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            string word = "арбуз";

            List<string> dictionary = new List<string>() {
                "бра",
                "раб",
                "зубр",
                "кот",
                "ток",
            };

            Console.WriteLine(String.Join(", ", GenerateWordsFromWord(word, dictionary)));
        }

        public static List<string> GenerateWordsFromWord(string text, List<string> dictionary)
        {
            List<string> words = new List<string>();

            foreach (string record in dictionary)
                if (ContainWordInText(text, record))
                    words.Add(record);

            words.Sort();

            return words;
        }

        public static bool ContainWordInText(string text, string word)
        {
            List<char> textSymbols = text.ToCharArray().ToList();
            List<char> wordSymbols = word.ToCharArray().ToList();

            foreach (char symbol in wordSymbols)
                if (textSymbols.Contains(symbol))
                    textSymbols.Remove(symbol);
                else
                    return false;

            return true;
        }
    }
}