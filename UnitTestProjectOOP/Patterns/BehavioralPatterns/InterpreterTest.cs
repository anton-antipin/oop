using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP.Patterns.BehavioralPatterns.Interpreter;

namespace UnitTestProjectOOP.Patterns.BehavioralPatterns
{
    [TestClass]
    public class InterpreterTest
    {
        [TestMethod]
        public void ContextNewVariableIsNotModified()
        {
            string constVariable = "z";
            int constValue = 5;
            int returnValue = 0;
            ContextGrammar context = new ContextGrammar();

            context.SetVariable(constVariable, constValue);
            returnValue = context.GetVariable(constVariable);

            Assert.AreEqual(constValue, returnValue);
        }

        [TestMethod]
        public void ContextExistVariableIsNotModified()
        {
            string constVariable = "z";
            int constValue1 = 5;
            int constValue2 = 7;
            int returnValue = 0;
            ContextGrammar context = new ContextGrammar();

            context.SetVariable(constVariable, constValue1);
            context.SetVariable(constVariable, constValue2);
            returnValue = context.GetVariable(constVariable);

            Assert.AreEqual(constValue2, returnValue);
        }

        [TestMethod]
        public void NumberExpressionInterpretIsNotModified()
        {
            string constVariable = "z";
            int constValue = 5;
            int returnValue = 0;
            ContextGrammar context = new ContextGrammar();
            IExpression expression = new NumberExpression(constVariable);

            context.SetVariable(constVariable, constValue);
            
            returnValue = expression.Interpret(context);

            Assert.AreEqual(constValue, returnValue);
        }

        [TestMethod]
        public void ExpressionInterpretAreEqual()
        {
            int constValueX = 5;
            int constValueY = 5;
            int constValueZ = 5;
            int constResult = (constValueX + constValueY) - constValueZ;
            int result = 0;

            result = I_Example.Instance.Main(constValueX, constValueY, constValueZ);

            Assert.AreEqual(constResult, result);
        }

    }
}
