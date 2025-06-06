#To exceed the requirements i enhanced the user experience by adding a Bonus Gratitude Activity, session tracking, and a summary report to help users reflect on their engagement. Improved animations like spinners and countdown timers to make interactions smoother, while inheritance and encapsulation keep the code clean and maintainable. These thoughtful additions showcase strong object-oriented programming principles and create a richer, more engaging experience.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class Activity
    {
        protected int duration;
        protected string name;
        protected string description;

        public Activity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"--- {name} ---");
            Console.WriteLine(description);
            Console.Write("\nEnter duration in seconds: ");
            duration = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPrepare to begin...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(2);
            Console.WriteLine($"\nYou completed the {name} for {duration} seconds.");
            ShowSpinner(2);
        }

        public abstract void Run();

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(200);
                Console.Write("\b");
                i++;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
                Console.Write("\b\b");
            }
        }
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly.") { }

        public override void Run()
        {
            Start();
            int cycle = duration / 6;
            for (int i = 0; i < cycle; i++)
            {
                Console.Write("\nBreathe in... ");
                Countdown(3);
                Console.Write("\nBreathe out... ");
                Countdown(3);
            }
            End();
        }
    }

    class ReflectionActivity : Activity
    {
        private List<string> prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new()
        {
            "Why was this experience meaningful to you?",
            "What did you learn about yourself?",
            "How did you feel when it was complete?",
            "How did you get started?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

        public override void Run()
        {
            Start();
            Random rand = new();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine($"\n--- {prompt} ---");
            Console.WriteLine("Reflect on the following questions:");
            DateTime end = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < end)
            {
                string question = questions[rand.Next(questions.Count)];
                Console.Write($"\n> {question} ");
                ShowSpinner(5);
            }
            End();
        }
    }

    class ListingActivity : Activity
    {
        private List<string> prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "What are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by listing them.") { }

        public override void Run()
        {
            Start();
            Random rand = new();
            string prompt = prompts[rand.Next(prompts.Count)];
            Console.WriteLine($"\n--- {prompt} ---");
            Console.WriteLine("Start listing in...");
            Countdown(3);

            List<string> items = new();
            DateTime end = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < end)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input);
            }

            Console.WriteLine($"\nYou listed {items.Count} items!");
            End();
        }
    }

    // ⭐ BONUS ACTIVITY: Gratitude Activity ⭐
    class GratitudeActivity : Activity
    {
        private Queue<string> gratitudePrompts = new Queue<string>(new[]
        {
            "Name a small thing that made you smile today.",
            "Mention something about your body you’re grateful for.",
            "What’s one thing in nature you’re thankful for?",
            "Share a recent act of kindness you witnessed.",
            "What is a challenge you’re grateful for?"
        });

        public GratitudeActivity() : base("Gratitude Activity", "This activity helps you focus on things you're grateful for to cultivate positivity.") { }

        public override void Run()
        {
            Start();
            int timePerPrompt = 5;
            while (DateTime.Now < DateTime.Now.AddSeconds(duration))
            {
                if (gratitudePrompts.Count == 0)
                    break;

                string prompt = gratitudePrompts.Dequeue();
                Console.WriteLine($"\n{prompt}");
                ShowSpinner(timePerPrompt);
            }
            End();
        }
    }

    class Program
    {
        static void Main()
        {
            List<Activity> sessionLog = new();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Mindfulness Program ===");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Gratitude Activity (Bonus)");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an activity: ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        activity = new GratitudeActivity();
                        break;
                    case "5":
                        Console.WriteLine("\nThanks for using the program!");
                        if (sessionLog.Count > 0)
                        {
                            Console.WriteLine("Summary of this session:");
                            var summary = sessionLog.GroupBy(a => a.GetType().Name)
                                .Select(g => $"{g.Key.Replace("Activity", "")}: {g.Count()} time(s)")
                                .ToList();
                            summary.ForEach(Console.WriteLine);
                        }
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Thread.Sleep(1000);
                        continue;
                }

                activity.Run();
                sessionLog.Add(activity);
            }
        }
    }
}
