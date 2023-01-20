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
            FindRepeatingLetters();

            //string word = "арбуз";
            //List<string> correctWordsList = new List<string>();
            //List<string> wordsList = new List<string>
            //{
            //    "кот", "ток", "око", "мимо", "гром", "ром", "мама",
            //    "рог", "морг", "огр", "мор", "порог", "бра", "раб", "зубр"
            //};


            //foreach (string tempWord in wordsList)
            //{
            //    Console.WriteLine(tempWord);

            //    for (int i = 0; i < tempWord.Length; i++)
            //    {
            //        if (word.Contains(tempWord[i]))
            //        {
            //            Console.WriteLine($"{word} contains {tempWord[i]}");

            //            if (i == tempWord.Length - 1)
            //            {
            //                correctWordsList.Add(tempWord);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"преравно на {i} итерации");
            //            break;
            //        }
            //    }

            //    Console.WriteLine(new string('_', 20));
            //}

            //Console.WriteLine("Полученный массив слов");
            //foreach (var item in correctWordsList)
            //{
            //    Console.WriteLine(item);
            //}
        }

        static void FindRepeatingLetters()
        {
            string str;
            int size_counter = 15;
            int[] counter = new int[size_counter];

            do
            {
                Console.Write("Enter a string (2 < Length < 15): ");
                str = Console.ReadLine();
            } while (2 < str.Length && 15 < str.Length);

            for (int i = 0; i < str.Length; ++i)
                    ++counter[str[i] - 'a'];

            for (int i = 0; i < counter.Length; ++i)
                if (counter[i] > 0)
                    Console.WriteLine("{0} = {1}", (char)('A' + i), counter[i]);

        }
    }
}