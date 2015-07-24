using System.Collections.Generic;

namespace Xnlab.WordSearch
{
    public sealed class WordSearch : WordNode
    {
        public WordSearch(string[] words)
            : base(' ')
        {
            Build(words);
        }

        private void Build(string[] words)
        {
            foreach (var word in words)
            {
                var first = word[0];
                WordNode child;
                if (!Children.TryGetValue(first, out child))
                {
                    child = new WordNode(first);
                    Children.Add(first, child);
                }
                child.Add(word);
            }
        }

        public IEnumerable<string> Find(string chars)
        {
            var result = new List<string>();
            var wordChars = new WordCharacters(chars);
            foreach (var child in Children.Values)
            {
                child.Visit(wordChars.Clone(), result);
            }
            return result;
        }
    }
}
