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

        [Fact]
        public void Subtracting_two_positive_integers()
        {
            // arrange
            var x = 10;
            var y = 3;
            var calc = new ExampleCalculator();

            // act
            var result = calc.Subtract(x, y);

            // assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Multiplying_two_positive_integers()
        {
            // arrange
            var x = 10;
            var y = 3;
            var calc = new ExampleCalculator();

            // act
            var result = calc.Multiple(x, y);

            // assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void Dividing_two_positive_integers()
        {
            // arrange
            var x = 20;
            var y = 2;
            var calc = new ExampleCalculator();

            // act
            var result = calc.Divide(x, y);

            // assert
            Assert.Equal(10, result);
        }
    }
}
