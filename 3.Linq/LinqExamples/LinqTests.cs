using LinqExamples.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqExamples
{
    public class LinqTests
    {
        [Fact]
        public void Where()
        {
            var numbers = Enumerable.Range(1, 100);

            var result = numbers.Where(x => x % 2 == 0);
                

            result.Log();
        }
        
        [Fact]
        public void Grouping()
        {
            var people = SomePeople();
            var result = people
                .GroupBy(p => p.Sex)
                .Select(g => $"{g.Key} : {g.Count()}");

            result.Log();
        }

        private IEnumerable<Person> SomePeople()
        {
            yield return new Person("Anna");
            yield return new Person("Marta");
            yield return new Person("Milena");
            yield return new Person("Zofia");
            yield return new Person("Katarzyna");
            yield return new Person("Maria");
            yield return new Person("Jan");
            yield return new Person("Jakub");
            yield return new Person("Marek");
            yield return new Person("Darek");
            yield return new Person("Arek");
        }
    }
}
