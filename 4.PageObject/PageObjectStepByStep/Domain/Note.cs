namespace PageObjectStepByStep.Domain
{
    public class Note
    {
        public Note(string title, string text)
        {
            Title = title;
            Text = text;
        }

        public string Title { get; }
        public string Text { get; }
    }
}