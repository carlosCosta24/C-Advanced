using System;
using System.Security.Policy;

public class NewsArticle
{
    public string Title { get; }
    public string Content { get; }

    public NewsArticle(string Title, string Content)
    {
        this.Title = Title;
        this.Content = Content;
    }
} 

public class NewsPublisher
{
    public event EventHandler<NewsArticle> NewNewsPublished;
    protected virtual void OnNewsPublished(NewsArticle News)
    {
        NewNewsPublished?.Invoke(this, News);
    }
    public void PublishNews(string Title, string Content)
    {
        var Article = new NewsArticle(Title, Content);
        OnNewsPublished(Article);
    }
}
public class NewsSubscriber
{
    
    public string Name;
    public NewsSubscriber(string name)
    {
        this.Name = name;
    }

    public void Subscrib(NewsPublisher publisher) 
    {
        publisher.NewNewsPublished += HandleNewNews;
    }
    public void UnSubscrib(NewsPublisher publisher) 
    {
        publisher.NewNewsPublished -= HandleNewNews;
    }

    public void HandleNewNews(object sender, NewsArticle article) 
    {
        Console.WriteLine($"{Name} received an Article:");
        Console.WriteLine($"Title: {article.Title}");
        Console.WriteLine($"Content: {article.Content}");
        

    }
}
public class Program
{

    static void Main()
    {
    
        NewsPublisher Publisher = new NewsPublisher();
        NewsSubscriber Subscriber = new NewsSubscriber("Carlos");

        Subscriber.Subscrib( Publisher );

        Publisher.PublishNews("Tech Update", "The Latest .NET Framework Features");

        Subscriber.UnSubscrib(Publisher);

        Publisher.PublishNews("Tech Update", "The Latest GitHub Actions Features");


        Console.ReadLine();
    } 

}
