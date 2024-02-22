using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (var comment in Comments)
        {
            Console.WriteLine($"  {comment.CommenterName}: {comment.CommentText}");
        }

        Console.WriteLine("\n");
    }
}

class Program
{
    static void Main()
    {
        // Creating videos and adding comments
        List<Video> videos = new List<Video>
        {
            new Video
            {
                Title = "Video 1",
                Author = "Author 1",
                LengthInSeconds = 120
            },
            new Video
            {
                Title = "Video 2",
                Author = "Author 2",
                LengthInSeconds = 180
            },
            new Video
            {
                Title = "Video 3",
                Author = "Author 3",
                LengthInSeconds = 150
            }
        };

        videos[0].AddComment("User1", "Great video!");
        videos[0].AddComment("User2", "Nice content!");
        videos[1].AddComment("User3", "Interesting topic!");
        videos[2].AddComment("User4", "I learned a lot!");

        // Displaying video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
