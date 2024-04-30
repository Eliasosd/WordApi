using WordApi.Interfaces;

namespace WordApi.Services
{
    public class WordCountService : IWordCountService
    {
        public Dictionary<string, int> CountWords(string text)
        {
            var separatedWords = SeparateWords(text);
            var countedWords = CountWords(separatedWords);
            var sortedDict = SortDictionaryByDescending(countedWords);
            return sortedDict;
        }

        private string[] SeparateWords(string text)
        {
            var separatedWords = text.Split(new char[] { ' ', '.', '"', '?', '(', ')', ',', '!', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            return separatedWords;
        }

        private Dictionary<string, int> CountWords(string[] wordsToCount)
        {
            var wordDict = new Dictionary<string, int>();

            foreach (var word in wordsToCount)
            {
                var capitalizedWord = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();

                if (wordDict.ContainsKey(capitalizedWord))
                {
                    wordDict[capitalizedWord]++;
                }

                else
                {
                    wordDict[capitalizedWord] = 1;
                }
            }

            return wordDict;
        }

        private Dictionary<string, int> SortDictionaryByDescending(Dictionary<string, int> wordDict)
        {
            var sortedDict = wordDict.OrderByDescending(x => x.Value)
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Value);
            return sortedDict;
        }
    }

}
