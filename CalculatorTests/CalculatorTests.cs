using Calculator.Models;
using Calculator.Services;

namespace CalculatorTests;

[TestClass]
public class CalculatorServiceTests
{
    private CalculatorService calculatorService;

    [TestInitialize]
    public void Initialize()
    {
        calculatorService = new CalculatorService();
    }

    private decimal PerformCalculation(decimal operand1, decimal operand2, OperationType operation, bool roundResult = false)
    {
        return calculatorService.PerformCalculation(operand1, operand2, operation, roundResult);
    }

    [TestMethod]
    public void AdditionTest()
    {
        var result = PerformCalculation(5, 3, OperationType.Add);
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void SubtractionTest()
    {
        var result = PerformCalculation(5, 3, OperationType.Subtract);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void MultiplicationTest()
    {
        var result = PerformCalculation(5, 3, OperationType.Multiply);
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void DivisionTest()
    {
        var result = PerformCalculation(6, 3, OperationType.Divide);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void DivisionByZeroTest()
    {
        PerformCalculation(5, 0, OperationType.Divide);
    }

    [TestMethod]
    public void WholeNumberTest()
    {
        var result = PerformCalculation(7, 3, OperationType.Divide, true);
        Assert.AreEqual(2, result);
    }
}
