using Calculator.Models;

namespace Calculator.Services;

public class CalculatorService
{
    public decimal PerformCalculation(decimal operand1, decimal operand2, OperationType operation, bool roundResult)
    {
        decimal result = operation switch
        {
            OperationType.Add => operand1 + operand2,
            OperationType.Subtract => operand1 - operand2,
            OperationType.Multiply => operand1 * operand2,
            OperationType.Divide => operand2 != 0 ? operand1 / operand2 : throw new DivideByZeroException(),
            _ => throw new InvalidOperationException("Invalid operation"),
        };

        return roundResult ? Math.Round(result) : result;
    }
}
