using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Calculator.Binders;

public class CustomDecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        var value = valueProviderResult.FirstValue;
        if (string.IsNullOrWhiteSpace(value))
        {
            return Task.CompletedTask;
        }

        value = value.Replace(",", ".");
        if (!decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var decimalValue))
        {
            bindingContext.ModelState.TryAddModelError(modelName, "Decimal value is not valid.");
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(decimalValue);
        return Task.CompletedTask;
    }
}

