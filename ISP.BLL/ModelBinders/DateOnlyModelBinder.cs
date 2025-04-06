using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ISP.BLL.ModelBinders;

public class DateOnlyModelBinder : IModelBinder
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

        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        if (DateOnly.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateOnly))
        {
            bindingContext.Result = ModelBindingResult.Success(dateOnly);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(modelName, $"Could not parse {value} as a valid date.");
        }

        return Task.CompletedTask;
    }
}