using System;
using System.Collections.Generic;

// Observer (Subscriber)
public class Subscriber
{
    private string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{_name} received breaking news: {news}");
    }
}

// Subject (News Agency)
public class NewsAgency
{
    private List<Subscriber> _subscribers = new List<Subscriber>();

    public void Subscribe(Subscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void PublishNews(string news)
    {
        Console.WriteLine($"Breaking news published: {news}");
        NotifySubscribers(news);
    }

    private void NotifySubscribers(string news)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(news);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        NewsAgency newsAgency = new NewsAgency();
        Subscriber subscriber1 = new Subscriber("Subscriber 1");
        Subscriber subscriber2 = new Subscriber("Subscriber 2");

        newsAgency.Subscribe(subscriber1);
        newsAgency.Subscribe(subscriber2);

        newsAgency.PublishNews("Earthquake reported!");
    }
}
