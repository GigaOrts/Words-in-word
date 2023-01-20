using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "откорок";
            List<string> correctWordsList = new List<string>();
            List<string> wordsList = new List<string>
            {
                "кот", "ток", "око", "мимо", "гром", "ром", "мама",
                "рог", "морг", "огр", "мор", "порог", "бра", "раб", "зубр"
            };
            
            foreach (string verifiableWord in wordsList)
            {
                Console.WriteLine(verifiableWord);

                WordsInWordSearcher searcher = new WordsInWordSearcher(word);
                if (searcher.TryCheckWord(verifiableWord))
                    correctWordsList.Add(verifiableWord);
            }

            Console.WriteLine("Полученный массив слов");
            foreach (string correctWord in correctWordsList)
            {
                Console.WriteLine(correctWord);
            }
        }
    }

    class WordsInWordSearcher
    {
        public WordsInWordSearcher(string word)
        {
            CorrectWord = word;
        }

        public string CorrectWord { get; private set; }

        private Dictionary<char, int> _wordLetters;
        private Dictionary<char, int> _verifiableWordLetters;

        private List<char> _alphabet = new List<char>()
        {
            'а','б','в','г','д',
            'е','ё','ж','з','и',
            'й','к','л','м','н',
            'о','п','р','с','т',
            'у','ф','х','ц','ч',
            'ш','щ','ъ','ы','ь',
            'э','ю','я'
        };

        public bool TryCheckWord(string verifiableWord)
        {
            _wordLetters = new Dictionary<char, int>();
            _verifiableWordLetters = new Dictionary<char, int>();

            foreach (char letter in CorrectWord)
            {
                SearchInAlphabet(letter, _wordLetters);
            }

            foreach (char letter in verifiableWord)
            {
                SearchInAlphabet(letter, _verifiableWordLetters);
            }

            return CheckIsWordsMatching(_wordLetters, _verifiableWordLetters);
        }

        private void SearchInAlphabet(char letter, Dictionary<char, int> letterCollection)
        {
            foreach (char alphabetLetter in _alphabet)
            {
                CountLetters(letter, letterCollection, alphabetLetter);
            }
        }

        private void CountLetters(char letter, Dictionary<char, int> letterCollection, char alphabetLetter)
        {
            int counter = 1;

            if (letter == alphabetLetter)
            {
                if (letterCollection.ContainsKey(alphabetLetter) == false)
                    letterCollection.Add(alphabetLetter, counter);
                else
                    letterCollection[alphabetLetter] += counter;
            }
        }

        private bool CheckIsWordsMatching(Dictionary<char, int> wordLetters, Dictionary<char, int> verifiableWordLetters)
        {
            if (wordLetters.Count < verifiableWordLetters.Count)
                return false;

            foreach (var letter in wordLetters)
            {
                if (verifiableWordLetters.TryGetValue(letter.Key, out int verifiableLetterCount) == false)
                    return false;

                if (verifiableLetterCount > letter.Value)
                    return false;
            }

            return true;
        }
    }
}