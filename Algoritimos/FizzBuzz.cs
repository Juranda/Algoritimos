namespace Algoritimos
{
    public static class FizzBuzz
    {
        public static string Play(int number)
        {
            string output = string.Empty;

            if (number.IsDivisiableBy(3)) output += "Fizz";

            if (number.IsDivisiableBy(5)) output += "Buzz";

            if(output.Equals(string.Empty)) return number.ToString();

            return output;
        }

        static bool IsDivisiableBy(this int number1, int number2)
        {
            return number1 % number2 == 0;
        }
    }
}