namespace Interpreter
{

    public abstract class Expression
    {
        public abstract int Interpret();        
    }

    public class NumberExpression : Expression
    {
        private readonly int _value;
        public NumberExpression(int val)
        {
            this._value = val;
        }
        public override int Interpret()
        {
           return _value;
        }
    }

    public class AdditionExpression : Expression
    {
        private readonly Expression _leftExpression;
        private readonly Expression _rightExpression;

        public AdditionExpression(Expression _leftExpression, Expression _rightExpression)
        {
            this._leftExpression = _leftExpression;
            this._rightExpression = _rightExpression;
        }

        public override int Interpret()
        {
            return _leftExpression.Interpret()+_rightExpression.Interpret();
        }
    }

    public class Context
    {
        private readonly Dictionary<string, int> _inputs;

        public Context()
        {
            this._inputs = new Dictionary<string, int>();
        }
        public void Setinput(string name, int val)
        {
            _inputs[name] = val;
        }

        public int Getinput(string name)
        {
            return _inputs.ContainsKey(name) ? _inputs[name] : 0;
        }
    }


    public class Parser
    {
        public static Expression Parse(string expression, Context context)
        {
            Stack<Expression> stack = new Stack<Expression>();
            string[] tokens = expression.Split(' ');
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int n))
                {
                    stack.Push(new NumberExpression(n));
                }
                else if (token == "+")
                {
                    Expression right = stack.Pop();
                    Expression left = stack.Pop();
                    stack.Push(new AdditionExpression(left, right));
                }
                else
                {
                    stack.Push(new NumberExpression(context.Getinput(token)));
                }
            }
            return stack.Pop();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.Setinput("a", 20);
            context.Setinput("b", 20);
            string exp1 = "a b +";
            string exp2 = "a b -";

            Expression ex1=Parser.Parse(exp1, context);
            Expression ex2=Parser.Parse(exp2, context);
            Console.WriteLine($"Expression: {exp1}, Result : {ex1.Interpret()}");
            Console.WriteLine($"Expression: {exp2}, Result : {ex2.Interpret()}");


        }
    }
}
