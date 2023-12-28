
using LW03Controllers.Models;
using System.Collections;

namespace LW03Controllers.Services
{
    public class WordService : IWordService
    {
        private static List<MyDictionaryEntry> _words = new List<MyDictionaryEntry>();

        public void AddWord(string word, string meaning)
        {
            MyDictionaryEntry myDictionaryEntry = new MyDictionaryEntry();
            myDictionaryEntry.Word = word;
            myDictionaryEntry.Meaning = meaning;

            _words.Add(myDictionaryEntry);
        }

        public List<MyDictionaryEntry> GetWords()
        {
            return _words;
        }
    }
}
