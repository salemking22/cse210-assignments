using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        
        int gradePercentage;
        if (!int.TryParse(userInput, out gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a numeric grade.");
            return;
        }

        string letter;
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard! You'll do better next time.");
        }

        string sign = "";
        int lastDigit = gradePercentage % 10;

        if (gradePercentage >= 60 && gradePercentage < 90)
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}
