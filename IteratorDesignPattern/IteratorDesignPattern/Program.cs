using System;
using System.Collections.Generic;

// Iterator Interface
public interface IArticleIterator
{
    bool HasNext();
    Article Next();
}

// Aggregate Interface
public interface IArticleCollection
{
    IArticleIterator GetIterator();
}

// Article Class
public class Article
{
    public string Title { get; set; }
    public string Content { get; set; }
}

// Concrete ArticleIterator Class
public class ArticleIterator : IArticleIterator
{
    private List<Article> _articles;
    private int _currentIndex = 0;

    public ArticleIterator(List<Article> articles)
    {
        _articles = articles;
    }

    public bool HasNext()
    {
        return _currentIndex < _articles.Count;
    }

    public Article Next()
    {
        Article article = _articles[_currentIndex];
        _currentIndex++;
        return article;
    }
}

// Concrete ArticleCollection Class
public class ArticleCollection : IArticleCollection
{
    private List<Article> _articles = new List<Article>();

    public void AddArticle(Article article)
    {
        _articles.Add(article);
    }

    public IArticleIterator GetIterator()
    {
        return new ArticleIterator(_articles);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArticleCollection articles = new ArticleCollection();
        articles.AddArticle(new Article { Title = "Breaking News", Content = "..." });
        articles.AddArticle(new Article { Title = "Tech Update", Content = "..." });
        articles.AddArticle(new Article { Title = "Health Tips", Content = "..." });

        IArticleIterator iterator = articles.GetIterator();

        while (iterator.HasNext())
        {
            Article article = iterator.Next();
            Console.WriteLine($"Title: {article.Title}");
            Console.WriteLine($"Content: {article.Content}\n");
        }
    }
}

