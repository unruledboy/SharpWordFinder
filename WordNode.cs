using System.Collections.Generic;

namespace Xnlab.WordSearch
{
    public class WordNode
    {
        public bool IsWord { get; set; }
        public char Current { get; private set; }
        public Dictionary<char, WordNode> Children { get; private set; }

        public WordNode(char c)
        {
            Children = new Dictionary<char, WordNode>();
            Current = c;
        }

        public void Add(string word, int index = 0)
        {
            if (word.Length == index + 1)
                IsWord = true;
            else
            {
                var next = word[index + 1];
                WordNode child;
                if (!Children.TryGetValue(next, out child))
                    Children[next] = new WordNode(next);
                else if (Children[next].Children.Count == 0)
                    Children[next] = new WordNode(next) { IsWord = true };
                Children[next].Add(word, index + 1);
            }
        }

        internal void Visit(WordCharacters chars, List<string> results)
        {
            if (chars.Take(Current))
            {
                if (IsWord)
                    results.Add(chars.Word);
                foreach (var child in Children.Values)
                {
                    child.Visit(chars.Clone(), results);
                }
            }
        }
    }
}
