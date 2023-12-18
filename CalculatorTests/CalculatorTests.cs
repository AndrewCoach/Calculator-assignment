namespace CalculatorTests;

using Calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculatorModelTests
{
    private CalculatorModel calculator;

    [TestInitialize]
    public void Initialize()
    {
        calculator = new CalculatorModel();
    }

    private void SetupCalculation(decimal operand1, decimal operand2, OperationType operation)
    {
        calculator.Operand1 = operand1;
        calculator.Operand2 = operand2;
        calculator.Operation = operation;
    }

    [TestMethod]
    public void AdditionTest()
    {
        SetupCalculation(5, 3, OperationType.Add);
        Assert.AreEqual(8, calculator.Calculate());
    }

    [TestMethod]
    public void SubtractionTest()
    {
        SetupCalculation(5, 3, OperationType.Subtract);
        Assert.AreEqual(2, calculator.Calculate());
    }

    [TestMethod]
    public void MultiplicationTest()
    {
        SetupCalculation(5, 3, OperationType.Multiply);
        Assert.AreEqual(15, calculator.Calculate());
    }

    [TestMethod]
    public void DivisionTest()
    {
        SetupCalculation(6, 3, OperationType.Divide);
        Assert.AreEqual(2, calculator.Calculate());
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void DivisionByZeroTest()
    {
        SetupCalculation(5, 0, OperationType.Divide);
        calculator.Calculate();
    }

    [TestMethod]
    public void WholeNumberTest()
    {
        calculator.RoundResult = true;
        SetupCalculation(7, 3, OperationType.Divide);
        Assert.AreEqual(2, calculator.Calculate());
    }
}
