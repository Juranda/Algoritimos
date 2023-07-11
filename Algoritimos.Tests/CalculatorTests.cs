using FluentAssertions;

namespace Algorithms.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(3, -2)]
        public void Add_ValidNumbers_ReturnsSum(double number1, double number2)
        {
            double result = Calculator.Add(number1, number2);

            result.Should().Be(number1 + number2);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(-42, 29)]
        public void Subtract_ValidNumbers_ReturnsSubtraction(double number1, double number2)
        {
            double result = Calculator.Subtract(number1, number2);

            result.Should().Be(number1 - number2);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(3, -2)]
        public void Multiply_ValidNumbers_ReturnsMultiplication(double number1, double number2)
        {
            double result = Calculator.Multiply(number1, number2);

            result.Should().Be(number1 * number2);
        }

        [Fact]
        public void Divide_DivideBy0_ThrowsException()
        {
            var action = () => Calculator.Divide(2d, 0d);
            action.Should().Throw<DivideByZeroException>();
        }


        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(3, -2)]
        public void Divide_ValidNumbers_ReturnDivision(double number1, double number2)
        {
            double result = Calculator.Divide(number1, number2);

            result.Should().Be(number1 / number2);
        }

        [Theory]
        [InlineData("10 + 24", 34)]
        [InlineData("300 - 250", 50)]
        [InlineData("5 * 20", 100)]
        [InlineData("20/4", 5)]
        [InlineData("4,5 * 2", 9)]
        public void EvaluateExpression_ValidExpression_ReturnsResult(string expression, double expectedResult)
        {
            double result = Calculator.EvaluateExpression(expression);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void EvaluateExpression_InvalidExpression_ThrowsInvalidExpressionException()
        {
            Action action = () => Calculator.EvaluateExpression("3 , 44 _ 5 2");
            action.Should().Throw<InvalidExpressionException>();
        }
    }
}
