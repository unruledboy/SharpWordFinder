using System.Collections.Generic;

namespace Xnlab.WordSearch
{
    internal class WordCharacters
    {
        private readonly List<char> _remainingChars;
        private readonly List<char> _takenChars;

        public WordCharacters(string word)
        {
            _remainingChars = new List<char>(word.ToCharArray());
            _takenChars = new List<char>();
        }

        public WordCharacters(WordCharacters chars)
        {
            _remainingChars = new List<char>(chars._remainingChars);
            _takenChars = new List<char>(chars._takenChars);
        }

        public bool Take(char c)
        {
            if (!_remainingChars.Contains(c)) return false;
            _takenChars.Add(c);
            _remainingChars.Remove(c);
            return true;
        }

        public string Word
        {
            get { return new string(_takenChars.ToArray()); }
        }

        public WordCharacters Clone()
        {
            return new WordCharacters(this);
        }
    }
}
