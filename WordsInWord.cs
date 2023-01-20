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
            string word = "арбуз";
            List<string> correctWordsList = new List<string>();
            List<string> wordsList = new List<string>
            {
                "кот", "ток", "око", "мимо", "гром", "ром", "мама",
                "рог", "морг", "огр", "мор", "порог", "бра", "раб", "зубр"
            };

            do
            {
                Console.Write("Enter a string (2 < Length < 15): ");
                word = Console.ReadLine();
            } while (2 < word.Length && 15 < word.Length);

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

        private Dictionary<Letter, int> wordLetters;
        private Dictionary<Letter, int> verifiableWordLetters;
        
        private List<Letter> _letters = new List<Letter>()
        {
            new Letter('а'),
            new Letter('б'),
            new Letter('в'),
            new Letter('г'),
            new Letter('д'),
            new Letter('е'),
            new Letter('ё'),
            new Letter('ж'),
            new Letter('з'),
            new Letter('и'),
            new Letter('й'),
            new Letter('к'),
            new Letter('л'),
            new Letter('м'),
            new Letter('н'),
            new Letter('о'),
            new Letter('п'),
            new Letter('р'),
            new Letter('с'),
            new Letter('т'),
            new Letter('у'),
            new Letter('ф'),
            new Letter('х'),
            new Letter('ц'),
            new Letter('ч'),
            new Letter('ш'),
            new Letter('щ'),
            new Letter('ъ'),
            new Letter('ы'),
            new Letter('ь'),
            new Letter('э'),
            new Letter('ю'),
            new Letter('я')
        };

        public bool TryCheckWord(string verifiableWord)
        {
            wordLetters = new Dictionary<Letter, int>();
            verifiableWordLetters = new Dictionary<Letter, int>();

            foreach (char letter in CorrectWord)
            {
                UpdateLetterCounter(letter, wordLetters);
            }

            foreach (char letter in verifiableWord)
            {
                UpdateLetterCounter(letter, verifiableWordLetters);
            }

            return CheckIsWordsMatching(wordLetters, verifiableWordLetters);
        }

        private bool CheckIsWordsMatching(Dictionary<Letter, int> wordLetters, Dictionary<Letter, int> verifiableWordLetters)
        {
            foreach (var letter in wordLetters)
            {
                if (verifiableWordLetters.TryGetValue(letter.Key, out int verifiableLetterValue) == false)
                    return false;

                if (verifiableLetterValue != letter.Value)
                    return false;
            }

            return true;
        }

        private void UpdateLetterCounter(char letter, Dictionary<Letter, int> letterCollection)
        {
            foreach (Letter AlphabetLetter in _letters)
            {
                if (letter == AlphabetLetter.Value)
                {
                    if (letterCollection.ContainsKey(AlphabetLetter) == false)
                        letterCollection.Add(AlphabetLetter, ++AlphabetLetter.Count);
                    else
                        letterCollection[AlphabetLetter] = ++AlphabetLetter.Count;
                }
            }
        }
    }

    class Letter
    {
        public char Value { get; private set; }
        public int Count { get; set; }

        public Letter(char value)
        {
            Value = value;
        }
    }
}