namespace Algorithms
{
    public static class Calculator
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Divide(double number1, double number2)
        {
            if(number2 == 0) throw new DivideByZeroException();

            double result = number1 / number2;
            return result;
        }

        public static double EvaluateExpression(string expression)
        {
            List<object> values = new List<object>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (i == 0 && !char.IsNumber(expression[i])) throw new InvalidExpressionException($"Expression can't start with '{expression[0]}'");
                
                if (char.IsWhiteSpace(expression[i])) continue;

                string stringNumber = string.Empty;

                if(char.IsNumber(expression[i]))
                {
                    if(values.Any())
                    {
                        object last = values.Last();
                        if (typeof(double).IsAssignableFrom(last.GetType())) throw new InvalidExpressionException($"'Number' 'Number' is not valid, try 'Number' 'Action' 'Number', like '2 + 2'");
                    }

                    while (i < expression.Length && (char.IsNumber(expression[i]) || expression[i] == ','))
                    {
                        stringNumber += expression[i];
                        i++;
                    }

                    double number = double.Parse(stringNumber);
                    values.Add(number);
                }
                
                if (i >= expression.Length) continue;

                char c = expression[i];
                if (char.IsWhiteSpace(c)) continue;

                switch(c)
                {
                    case '+': values.Add(Add); break;
                    case '-': values.Add(Subtract); break;
                    case '*': values.Add(Multiply); break;
                    case '/': values.Add(Divide); break;

                    default: throw new InvalidExpressionException($"Character '{c}' not identified.");
                }
            }

            double total = 0;

            for (int i = 0; i < values.Count; i++)
            {
                try
                {
                    double number = (double)values[i];

                    if (i == 0)
                    {
                        total = number;
                    }
                } catch (InvalidCastException invalidCastException)
                {
                    Func<double, double, double> func = values[i] as Func<double, double, double>;

                    total = func(total, (double)values[i + 1]);

                    i++;
                }
            }

            return total;
        }
    }
}
