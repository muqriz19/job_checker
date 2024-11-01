using be.Interfaces;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace be.Services;

public class Scraper : IScraper
{
    private readonly HtmlWeb _web;
    public Scraper()
    {
        _web = new HtmlWeb();
    }

    private HtmlDocument LoadDocument(string url)
    {
        return _web.Load(url);
    }

    public ICollection<T> GetItems<T>(string url, string elementCheck, Func<HtmlNode, T> formatter)
    {
        var document = LoadDocument(url);
        var allElements = document.DocumentNode.QuerySelectorAll(elementCheck);
        ICollection<T> allItems = [];

        foreach (var element in allElements)
        {
            T finalItem = formatter(element);
            allItems.Add(finalItem);
        }

        return allItems;
    }
}