namespace WordApi.Interfaces
{
    public interface IWordCountService
    {
        Dictionary<string, int> CountWords(string text);
    }
}
