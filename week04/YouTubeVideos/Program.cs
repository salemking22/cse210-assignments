using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Video video1 = new Video("Introduction to C#", "John Doe", 600);
        Video video2 = new Video("Web Development Basics", "Jane Smith", 900);
        Video video3 = new Video("Database Management", "Alex Johnson", 750);
        Video video4 = new Video("Advanced JavaScript", "Sam Brown", 1100);

        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "Clear and concise explanation."));

        video2.AddComment(new Comment("Dave", "Loved the breakdown of concepts."));
        video2.AddComment(new Comment("Eve", "Helpful for beginners."));
        video2.AddComment(new Comment("Frank", "Well structured content."));

        video3.AddComment(new Comment("Grace", "Awesome content!"));
        video3.AddComment(new Comment("Hank", "Helped a lot with my project."));
        video3.AddComment(new Comment("Ivy", "Thanks for the insights."));

        video4.AddComment(new Comment("Jack", "Really informative."));
        video4.AddComment(new Comment("Kathy", "Would love more examples."));
        video4.AddComment(new Comment("Leo", "Great explanations."));

        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
