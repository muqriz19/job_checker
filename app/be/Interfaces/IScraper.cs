using HtmlAgilityPack;

namespace be.Interfaces;

public interface IScraper
{
    public ICollection<T> GetItems<T>(string url, string elementCheck, Func<HtmlNode, T> formatter);
}