namespace Algorithms.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(11)]
        public void Play_ReciveIntNotDivisiableBy3or5_ReturnIntInString(int number)
        {
            var result = FizzBuzz.Play(number);

            Assert.Equal(number.ToString(), result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void Play_NumeberIsDivisiableBy3_ReturnFizz(int number)
        {
            var result = FizzBuzz.Play(number);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void Play_NumeberIsDivisiableBy5_ReturnBuzz(int number)
        {
            var result = FizzBuzz.Play(number);

            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(60)]
        public void Play_NumeberIsDivisiableBy3And5_ReturnFizzBuzz(int number)
        {
            var result = FizzBuzz.Play(number);

            Assert.Equal("FizzBuzz", result);
        }
    }
}