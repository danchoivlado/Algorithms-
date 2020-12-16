using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Word_Cruncher
{
    class Program
    {
        private static Dictionary<int, List<string>> wordsByLen;
        private static string currentWord;
        private static string desiredWord;
        private static List<string> selectedWords;
        private static HashSet<string> usedWords;
        private static HashSet<string> results = new HashSet<string>();
        private static Dictionary<string, int> occurence;

        static void Main(string[] args)
        {
            var inputWords = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            desiredWord = Console.ReadLine();

            wordsByLen = new Dictionary<int, List<string>>();
            occurence = new Dictionary<string, int>();
            foreach (var word in inputWords)
            {
                var wordLen = word.Length;

                if (!wordsByLen.ContainsKey(wordLen))
                {
                    wordsByLen.Add(wordLen, new List<string>() { word });
                }
                else
                {
                    wordsByLen[wordLen].Add(word);
                }

                if (!occurence.ContainsKey(word))
                {
                    occurence.Add(word, 1);
                }
                else
                {
                    occurence[word] += 1;
                }
            }

            usedWords = new HashSet<string>();
            selectedWords = new List<string>();
            currentWord = string.Empty;
            WorGen(desiredWord.Length);
            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static void WorGen(int length)
        {
            if (length <= 0)
            {
                if (currentWord == desiredWord)
                {
                    results.Add(string.Join(" ", selectedWords));
                }
                return;
            }

            foreach (var words in wordsByLen)
            {
                if (length - words.Key < 0)
                    continue;

                foreach (var word in words.Value)
                {
                    if (selectedWords.Contains(word))
                        continue;

                    if (Compare(currentWord + word, desiredWord)  && occurence[word] > 0)
                    {
                        occurence[word]--;
                        selectedWords.Add(word);
                        currentWord += word;
                        WorGen(length - word.Length);
                        selectedWords.Remove(word);
                        occurence[word]++;
                        currentWord = currentWord.Remove(currentWord.Length - word.Length, word.Length);
                    }
                }
            }
        }

        private static bool Compare(string initial, string desiredWord)
        {
            for (int i = 0; i < initial.Length; i++)
            {
                if (initial[i] != desiredWord[i])
                    return false;
            }
            return true;
        }

    }
}
