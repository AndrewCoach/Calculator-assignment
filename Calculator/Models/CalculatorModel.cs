namespace Calculator.Models;

public enum OperationType
{
    Add,
    Subtract,
    Multiply,
    Divide
}

public class CalculatorModel
{
    public decimal Operand1 { get; set; }
    public decimal Operand2 { get; set; }
    public OperationType Operation { get; set; }
    public bool RoundResult { get; set; }

    public decimal Calculate()
    {
        decimal result = Operation switch
        {
            OperationType.Add => Operand1 + Operand2,
            OperationType.Subtract => Operand1 - Operand2,
            OperationType.Multiply => Operand1 * Operand2,
            OperationType.Divide => Operand2 != 0 ? Operand1 / Operand2 : throw new DivideByZeroException(),
            _ => throw new InvalidOperationException("Invalid operation"),
        };

        return RoundResult ? Math.Round(result) : result;
    }
}

