using Calculator.Data;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Calculator.Controllers;

public class CalculatorController : Controller
{
    private readonly ApplicationDbContext _context;

    public CalculatorController(ApplicationDbContext context)
    {
        _context = context;
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
            var result = model.Calculate();
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
            SendError(ex);
            return Json(new { success = false, message = ex.Message });
        }
    }

    private void SendError(Exception exception)
    {
        Log.Error(exception, "An error occurred in the CalculatorController");
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
