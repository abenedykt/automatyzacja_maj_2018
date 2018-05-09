using Xunit;

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

        [Theory,
            InlineData(1.5, 2, 0.75),
            InlineData(2, 1.5, 1.3333333333333333),
            InlineData(20, 2, 10),
            InlineData(19, 2, 9.5),
            InlineData(19, 0, double.PositiveInfinity),
            InlineData(-19, 0, double.NegativeInfinity),
            InlineData(0, 0, double.NaN),
            ]
        public void Dividing_two_positive_integers_parametrized(double x, double y, double expected_result)
        {
            // arrange
            var calc = new ExampleCalculator();

            // act
            var result = calc.Divide(x, y);

            // assert
            Assert.Equal(expected_result, result);
        }
    }
}
