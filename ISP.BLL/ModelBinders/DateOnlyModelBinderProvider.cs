using ISP.BLL.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ISP.API.ModelBinders;

public class DateOnlyModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(DateOnly) || 
            context.Metadata.ModelType == typeof(DateOnly?))
        {
            return new DateOnlyModelBinder();
        }

        return null;
    }
}