using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Xnlab.WordSearch
{
    class Program
    {
        static void Main()
        {
            var time = new Stopwatch();
            time.Start();
            var search = new WordSearch(File.ReadAllLines("words.txt"));
            time.Stop();
            Console.WriteLine("Initialised {0}", time.Elapsed);
            while (true)
            {
                Console.Write("Input Characters:");
                var chars = Console.ReadLine();
                if (string.IsNullOrEmpty(chars))
                {
                    Console.WriteLine("Please provide alphabet letter to contiue");
                    continue;
                }
                time.Restart();
                var result = search.Find(chars.ToLowerInvariant());
                time.Stop(); 
                var words = result.ToArray();
                Console.WriteLine("Found {0} words in {1} ms", words.Length, time.ElapsedMilliseconds);
                var sortedWords = words.OrderByDescending(w => w.Length).Take(10).ToArray();
                if (sortedWords.Length > 0)
                {
                    var first = sortedWords.First();
                    foreach (var word in sortedWords)
                    {
                        Console.WriteLine("{0} ({1})", word.PadRight(first.Length), word.Length);
                    }
                }
            }
        }
    }
}
