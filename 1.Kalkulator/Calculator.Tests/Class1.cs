using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Kalkulator;

namespace Calculator.Tests
{
    public class Calculator_tests
    {
        [Fact]
        public void Adding_two_positive_integers()
        {
            // arrange
            var x = 5;
            var y = 10;
            var calc = new ExampleCalculator();

            // act
            var result = calc.Add(x, y);

            // assert
            Assert.Equal(15, result);
        }
    }
}
