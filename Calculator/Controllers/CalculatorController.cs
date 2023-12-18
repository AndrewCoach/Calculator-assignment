using Calculator.Data;
using Calculator.Models;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Calculator.Controllers;

public class CalculatorController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly CalculatorService _calculatorService;

    public CalculatorController(ApplicationDbContext context, CalculatorService calculatorService)
    {
        _context = context;
        _calculatorService = calculatorService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var history = _context.CalculationHistory
                      .OrderByDescending(h => h.Timestamp)
                      .Take(10)
                      .ToList();
        return View(history);
    }

    [HttpPost]
    public IActionResult Calculate(CalculatorModel model)
    {
        try
        {
            var result = _calculatorService.PerformCalculation(model.Operand1, model.Operand2, model.Operation, model.RoundResult);
            var formattedCalculation = $"{model.Operand1} {OperationToSymbol(model.Operation)} {model.Operand2} = {result}";
            var history = new CalculationHistory
            {
                Calculation = formattedCalculation,
                Timestamp = DateTime.Now
            };
            _context.CalculationHistory.Add(history);
            _context.SaveChanges();

            return Json(new { success = true, result = result, calculation = formattedCalculation });
        }
        catch (Exception ex)
        {
            var errorMessage = SendError(ex);
            return Json(new { success = false, message = errorMessage });
        }
    }

    private string SendError(Exception exception)
    {
        var errorMessage = $"An error occurred: {exception.Message}";
        Log.Error(exception, errorMessage);
        return errorMessage;
    }

    private string OperationToSymbol(OperationType operation)
    {
        return operation switch
        {
            OperationType.Add => "+",
            OperationType.Subtract => "-",
            OperationType.Multiply => "*",
            OperationType.Divide => "/",
            _ => throw new InvalidOperationException("Invalid operation"),
        };
    }
}
