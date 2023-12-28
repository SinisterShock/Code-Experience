using LW03Controllers.Models;

namespace LW03Controllers.Services
{
    public interface IWordService
    {
        void AddWord(string word, string meaning);
        List<MyDictionaryEntry> GetWords();
    }
}
