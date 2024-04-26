using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordApi.Models;

namespace WordApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordCountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] TextInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                return BadRequest("Inmatningen kan inte vara tom eller bara mellanslag");
            }

            var separaratedWords = SeparateWords(input.Text);
            var countedWords = CountWords(separaratedWords);
            
            return Ok(countedWords);
        }

        private string[] SeparateWords(string text)
        {
            var seraratedWords = text.Split(new char[] { ' ', '.', '"', '?', '(', ')', ',', '!', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

            return seraratedWords;
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

            var sortedDict = SortDictionaryByDescending(wordDict);

            return sortedDict;
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
