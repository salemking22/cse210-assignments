public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}
