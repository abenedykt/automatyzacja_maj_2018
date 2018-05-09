using System;

namespace HelloWeb
{
    public class ExampleComment
    {
        public string Name { get; }
        public string Email { get; }
        public string Text { get; }

        public ExampleComment()
        {
            Name = GenerateUserName();
            Email = GenerateEmail();
            Text = GenerateComment();
        }

        private string GenerateComment()
        {
            return Guid.NewGuid().ToString();
        }

        private string GenerateUserName()
        {
            return Guid.NewGuid().ToString();
        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }
    }
}