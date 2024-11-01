using be.Models;
using HtmlAgilityPack;

namespace be.Interface;

public interface IScraper
{
    public ICollection<T> GetItems<T>(string url, string elementCheck, Func<HtmlNode, T> formatter);
}