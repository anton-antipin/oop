// 1. определяет представление грамматики для заданного языка и интерпретатор предложений этого языка
// 2.   - применяется для часто повторяющихся операций
// 3. 

using System.Collections.Generic;

namespace OOP.Patterns.BehavioralPatterns.Interpreter
{
    #region Template
    // содержит общую для интерпретатора информацию
    class Context
    {

    }
    
    // определяет интерфейс выражения
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    // терминальное выражение 
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            
        }
    }
    // нетерминальное выражение
    class NonterminalExpression : AbstractExpression
    {
        AbstractExpression _expression1;
        AbstractExpression _expression2;
        public NonterminalExpression(AbstractExpression leftOperand, AbstractExpression rightOperand)
        {
            _expression1 = leftOperand;
            _expression2 = rightOperand;
        }

        public override void Interpret(Context context)
        {
            _expression1.Interpret(context);
            _expression2.Interpret(context);
        }
    }

    class Client
    {
        void Main()
        {
            Context context = new Context();

            AbstractExpression expression = new NonterminalExpression(new TerminalExpression(), new TerminalExpression());
            expression.Interpret(context);
        }
    }
    #endregion

    #region Grammar
    public class ContextGrammar
    {
        private readonly Dictionary<string, int> _variables = new Dictionary<string, int>();

        public int GetVariable(string name)
        {
            return _variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (_variables.ContainsKey(name))
                _variables[name] = value;
            else
                _variables.Add(name, value);
        }
    }

    public interface IExpression
    {
        int Interpret(ContextGrammar context);
    }
    public class NumberExpression : IExpression
    {
        private string _name;
        public NumberExpression(string name)
        {
            _name = name;
        }

        public int Interpret(ContextGrammar context)
        {
            return context.GetVariable(_name);
        }
    }
    public class AddExpression : IExpression
    {
        private IExpression _leftExpression;
        private IExpression _rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public int Interpret(ContextGrammar context)
        {
            return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
        }
    }
    public class SubtractExpression : IExpression
    {
        private IExpression _leftExpression;
        private IExpression _rightExpression;

        public SubtractExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public int Interpret(ContextGrammar context)
        {
            return _leftExpression.Interpret(context) - _rightExpression.Interpret(context);
        }
    }

    public class I_Example
    {
        private static I_Example _instance;
        private static readonly object _syncObj = new object();

        private I_Example()
        {

        }

        public static I_Example Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_syncObj)
                    {
                        if (_instance == null)
                            _instance = new I_Example();
                    }
                }
                return _instance;
            }
        }

        public int Main(int x, int y, int z)
        {
            ContextGrammar context = new ContextGrammar();
            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);

            IExpression expression = new SubtractExpression(new AddExpression(new NumberExpression("x"), 
                                                                                new NumberExpression("y")), 
                                                            new NumberExpression("z"));
            return expression.Interpret(context);
        }
    }
    #endregion
}
