using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace WorkingWithPageObjects
{
    internal class GoogleFromFileAttribute : DataAttribute
    {
        private readonly string fileName;

        public GoogleFromFileAttribute(string fileName)
        {
            this.fileName = fileName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var lines = File.ReadAllLines(fileName);
            
            foreach (var line in lines)
            {
                yield return new[] { line };
            }
        }
    }
}