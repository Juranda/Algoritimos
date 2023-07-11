using FluentAssertions;

namespace Algoritimos.Tests
{
    public class CalculadoraTests
    {
        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(3, -2)]
        public void Add_ValidNumbers_ReturnsSum(double number1, double number2)
        {
            double result = Calculadora.Add(number1, number2);

            Assert.Equal(number1 + number2, result);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(-42, 29)]
        public void Subtract_ValidNumbers_ReturnsSubtraction(double number1, double number2)
        {
            double result = Calculadora.Subtract(number1, number2);

            Assert.Equal(number1 - number2, result);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(3, -2)]
        public void Multiply_ValidNumbers_ReturnsMultiplication(double number1, double number2)
        {
            double result = Calculadora.Multiply(number1, number2);

            Assert.Equal(number1 * number2, result);
        }

        [Fact]
        public void Divide_DivideBy0_ThrowsException()
        {
            var action = () => Calculadora.Divide(2d, 0d);
            action.Should().Throw<DivideByZeroException>();
        }


        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 2)]
        [InlineData(3, -2)]
        public void Divide_ValidNumbers_ReturnDivision(double number1, double number2)
        {
            double result = Calculadora.Divide(number1, number2);

            Assert.Equal(number1 / number2, result);
        }

        [Theory]
        [InlineData("10 + 24", 34)]
        [InlineData("300 - 250", 50)]
        [InlineData("5 * 20", 100)]
        [InlineData("20/4", 5)]
        [InlineData("4,5 * 2", 9)]
        public void EvaluateExpression_ValidExpression_ReturnsResult(string expression, double expectedResult)
        {
            double result = Calculadora.EvaluateExpression(expression);

            result.Should().Be(expectedResult);
        }
    }
}
