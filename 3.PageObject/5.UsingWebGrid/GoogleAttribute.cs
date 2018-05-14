using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WorkingWithPageObjects
{
    internal class GoogleAttribute : DataAttribute
    {
        private readonly string query;

        public GoogleAttribute(string query)
        {
            this.query = query;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new[] { query };
        }
    }
}