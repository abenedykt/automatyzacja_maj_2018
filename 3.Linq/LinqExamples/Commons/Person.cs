namespace LinqExamples.Commons
{
    internal class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            Name = name;
        }

        public Sex Sex => Name.EndsWith("a") ? Sex.Female : Sex.Male;
    }
}
