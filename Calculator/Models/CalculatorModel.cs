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
}

